using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NetdiskClient
{
    public partial class NetdiskForm : Form
    {
        

        
        private static readonly HttpClient client = new HttpClient();
        private static MsgData hp;
        private string[] friends;
        private int friendCnt = 0;
        private static string UserId = "laotou";
        private RespFileList info;

        
        
        // 获取用户的好友列表
        private string getFriends()
        {
            string msg = hp.getHttpRequest(hp.BaseUrl + "user/friends/" + UserId);
            Console.WriteLine("baseurl:", hp.BaseUrl);
            RespUserFriends p = JsonConvert.DeserializeObject<RespUserFriends>(msg);
            friendCnt = p.friends.Length;
            if(friendListBox.Items.Count > 0)
            {
                friendListBox.Items.Clear();
            }
            for(int i = 0; i < friendCnt; i++)
            {
                friends[i] = p.friends[i];
                friendListBox.Items.Add(friends[i]);
            }
            return msg;
        }
        public NetdiskForm(string user_id)
        {
            hp = new MsgData();
            hp.BaseUrl = File.ReadAllText("config.txt");
            if (hp.BaseUrl.Length == 0)
            {
                MessageBox.Show("请检查config.txt确保输入了服务器地址", "配置问题");
            }
            UserId = user_id;
            friends = new string[10];
            InitializeComponent();
            getFriends();
            freshFormData();
            this.Text = "你好," + UserId;
        }

        // 重新获取用户可以下载的文件
        private void freshFormData()
        {
            try
            {
                string msg = hp.getHttpRequest(hp.BaseUrl + "user/files/" + UserId);

                info = JsonConvert.DeserializeObject<RespFileList>(msg);

                if (fileListBox.Items.Count > 0)
                {
                    fileListBox.Items.Clear();
                }
                for (int i = 0; i < info.my_file.Length; i++)
                {
                    fileListBox.Items.Add(info.my_file[i].file_path);
                }
                for (int i = 0; i < info.other_file.Length; i++)
                {
                    fileListBox.Items.Add(info.other_file[i].file_path);
                }
                uploadedFileNumLabel.Text = "已上传文件数:" + info.file_num.ToString();
                restspaceLabel.Text = "空间使用:" + info.space_used;
                fileListBox.SelectedIndex = 0;
            }
            catch(Exception err)
            {
                Console.WriteLine(err.ToString());
            }
        }

        // 下载并保存文件到本地
        private void downloadButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                string remote = fileListBox.SelectedItem.ToString();

                // 截取网盘文件的后缀作为默认文件名
                string suffix = "";
                int last = 0, i;
                for (i = 0; i < remote.Length; i++)
                {
                    if (remote[i] == '/')
                    {
                        last = i;
                    }
                }
                for (i = last + 1; i < remote.Length; i++)
                {
                    suffix += remote[i];
                }

                // 打开保存对话框
                Thread t = new Thread(new ThreadStart(() =>
                {
                    SaveFileDialog dialog = new SaveFileDialog();
                    dialog.FileName = suffix;
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        ReqFileTarget req = new ReqFileTarget();
                        req.user_id = UserId;
                        req.path = remote;
                        byte[] res = hp.downloadReq(hp.BaseUrl + "file/download", req);
                        File.WriteAllBytes(dialog.FileName, res);
                    }
                }));
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
                t.Join();
            }
            catch(Exception err)
            {
                Console.WriteLine(err.ToString());
            }
            finally
            {
                this.Enabled = true;
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            freshFormData();
        }

        // 添加好友，添加结束后刷新好友列表
        private void addFriendButton_Click(object sender, EventArgs e)
        {
            try
            {
                ReqUserUpdateFriend req = new ReqUserUpdateFriend();
                req.friend = friendIdTextBox.Text;
                req.me = UserId;
                string msg = hp.postHttpRequest(hp.BaseUrl + "user/update/friend", req);
                RespUserCommon resp = JsonConvert.DeserializeObject<RespUserCommon>(msg);
                if (resp.status == "success")
                {
                    MessageBox.Show("成功添加好友" + req.friend, "添加好友");
                }
                else
                {
                    MessageBox.Show("添加失败，原因:" + resp.reason, "添加好友");
                }
                getFriends();
            }
            catch(Exception err)
            {
                MessageBox.Show(err.ToString(), "未知错误");
            }
        }

        // 上传文件按钮功能实现
        private void uploadButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 防止重复点击按钮
                uploadButton.Enabled = false;
                this.Enabled = false;
                string path = "";
                // 这里需要开线程打开文件对话框
                Thread t = new Thread(new ThreadStart(() =>
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    DialogResult result = dialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        path = dialog.FileName;
                    }
                }));
                t.SetApartmentState(ApartmentState.STA);
                t.Start();
                t.Join();
                uploadButton.Enabled = true;
                if(path == "")
                {
                    return;
                }

                // 截取文件名
                string suffix = "";
                int last = 0, i;
                for (i = 0; i < path.Length; i++)
                {
                    if(path[i] == '\\')
                    {
                        last = i;
                    }
                }
                for(i = last + 1; i < path.Length; i++)
                {
                    suffix += path[i];
                }

                // 上传文件
                string msg = hp.webUploadFile(hp.BaseUrl + "file/upload/" + UserId + "/" + suffix, path);
                RespUserCommon resp = JsonConvert.DeserializeObject<RespUserCommon>(msg);
                if (resp.status == "success")
                {
                    MessageBox.Show("文件名" + suffix, "上传完成");
                } else
                {
                    MessageBox.Show(resp.reason, "上传失败");
                }
                freshFormData();
            }
            catch(Exception err)
            {
                MessageBox.Show(err.ToString(), "未知错误");
            }
            finally
            {
                this.Enabled = true;
            }
        }

        // 分享文件给好友
        private void shareButton_Click(object sender, EventArgs e)
        {
            try
            {
                int i;
                string path = fileListBox.SelectedItem.ToString();
                string target = "";

                // 把选中的好友添加到target中
                for (i = 0; i < friendListBox.CheckedItems.Count; i++)
                {
                    if (target.Length > 0)
                    {
                        target += ",";
                    }
                    target += friendListBox.CheckedItems[i].ToString();
                }
                ReqFileTarget req = new ReqFileTarget();
                req.user_id = UserId;
                req.target = target;
                req.path = path;

                // 发送请求
                string msg = hp.postHttpRequest(hp.BaseUrl + "file/target", req);
                RespUserCommon resp = JsonConvert.DeserializeObject<RespUserCommon>(msg);
                if(resp.status == "fail")
                {
                    MessageBox.Show(resp.reason, "分享失败");
                } else
                {
                    MessageBox.Show(path, "分享成功");
                }
                freshFormData();
            }
            catch(Exception err)
            {
                MessageBox.Show(err.ToString(), "未知错误");
            }
        }

        // 选中文件，如果是自己上传的文件，可以选择分享目标
        // 如果是别人分享给自己的文件，那么分享列表被禁用
        private void fileListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // 获取选中文件的序号
                int sid = fileListBox.SelectedIndex, i, j;
                string curFriend;

                // 判断是否由自己上传
                if (sid >= info.my_file.Length)
                {
                    // 不是自己上传，没有权限删除和分享
                    friendListBox.Enabled = false;
                    shareButton.Enabled = false;
                    deleteButton.Enabled = false;
                }
                else
                {
                    friendListBox.Enabled = true;
                    shareButton.Enabled = true;
                    deleteButton.Enabled = true;

                    // 获取当前选中文件的分享目标，更新好友状态
                    string[] targets = info.my_file[sid].target;
                    for (i = 0; i < friendListBox.Items.Count; i++)
                    {
                        friendListBox.SetItemChecked(i, false);
                        curFriend = friendListBox.Items[i].ToString();
                        for (j = 0; j < targets.Length; j++)
                        {
                            if (targets[j] == curFriend)
                            {
                                friendListBox.SetItemChecked(i, true);
                                break;
                            }
                        }
                    }
                }
            }
            catch(Exception err)
            {
                Console.WriteLine(err.ToString());
            }
        }

        // 删除文件
        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                string path = fileListBox.SelectedItem.ToString();
                ReqFileTarget req = new ReqFileTarget();
                req.user_id = UserId;
                req.path = path;

                string msg = hp.postHttpRequest(hp.BaseUrl + "file/delete", req);
                RespUserCommon resp = JsonConvert.DeserializeObject<RespUserCommon>(msg);
                string cap = "删除失败";
                if (resp.status == "success")
                {
                    cap = "删除成功";
                }
                freshFormData();
                MessageBox.Show(resp.reason, cap);
            }
            catch(Exception err)
            {
                MessageBox.Show(err.ToString(), "未知错误");
            }
        }

        private void NetdiskForm_Load(object sender, EventArgs e)
        {
            hp.BaseUrl = File.ReadAllText("config.txt");
        }
    }
}
