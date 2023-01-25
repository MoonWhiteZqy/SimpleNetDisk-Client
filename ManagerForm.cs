using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NetdiskClient
{
    public partial class ManagerForm : Form
    {
        MsgData hp;
        UserDetail[] info;
        public ManagerForm()
        {
            hp = new MsgData();
            hp.BaseUrl = File.ReadAllText("config.txt");
            if (hp.BaseUrl.Length == 0)
            {
                MessageBox.Show("请检查config.txt确保输入了服务器地址", "配置问题");
            }
            InitializeComponent();
            if (userListBox.Items.Count > 0)
            {
                userListBox.Items.Clear();
            }
        }

        // 查询用户
        // 如果存在用户id，那么将用户id作为唯一条件，因为id是唯一的
        // 否则，需要满足下面的四个条件
        private void queryUserButton_Click(object sender, EventArgs e)
        {
            ReqQuery req = new ReqQuery();
            if(useridTextBox.Text.Length > 0)
            {
                req.user_id = useridTextBox.Text;
            } else
            {
                // 文件数量和占用空间
                req.lower_file_num = lowerFileNum.Text;
                req.higher_file_num = higherFileNum.Text;
                req.lower_space = lowerSpace.Text;
                req.higher_space = higherSpace.Text;
            }
            string res = hp.postHttpRequest(hp.BaseUrl + "manager/query", req);
            RespQuery resp = JsonConvert.DeserializeObject<RespQuery>(res);
            UserDetail[] users = resp.users;
            info = users;
            if(userListBox.Items.Count > 0)
            {
                userListBox.Items.Clear();
            }
            for(int i = 0; i < info.Length; i++)
            {
                userListBox.Items.Add(info[i].Id);
            }
        }

        // 从返回的用户好友列表中，提取好友的数量
        private int getFriendCnt(string friends)
        {
            int res = 1;
            if(friends.Length == 0) return 0;
            for(int i = 0; i < friends.Length; i++)
            {
                if (friends[i] == ',') res++;
            }
            return res;
        }

        // 选中用户时，展示他的对应数据
        private void userListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int sid = userListBox.SelectedIndex;
                if (sid >= info.Length)
                {
                    return;
                }
                else
                {
                    spaceInfoLabel.Text = "使用空间:" + info[sid].Diskused.ToString();
                    friendNumLabel.Text = "好友数:" + getFriendCnt(info[sid].Friends).ToString();
                    uploadFileNumLabel.Text = "上传文件数:" + info[sid].Filenum.ToString();
                }
            }
            catch(Exception err)
            {
                Console.WriteLine(err.ToString());
            }
        }


        // 删除选中的用户
        private void deleteUserButton_Click(object sender, EventArgs e)
        {
            try
            {
                ReqDeleteUser req = new ReqDeleteUser();
                req.manager_id = "my";
                req.user_id = "";
                for (int i = 0; i < userListBox.CheckedItems.Count; i++)
                {
                    if (req.user_id.Length > 0) req.user_id += ",";
                    req.user_id += userListBox.CheckedItems[i].ToString();
                }
                string msg = hp.postHttpRequest(hp.BaseUrl + "manager/delete", req);
                RespUserCommon resp = JsonConvert.DeserializeObject<RespUserCommon>(msg);
                if (resp.status == "fail")
                {
                    MessageBox.Show(resp.reason, "删除失败");
                }
                else
                {
                    MessageBox.Show(req.user_id, "删除成功");
                }
            }
            catch(Exception err)
            {
                Console.WriteLine(err.ToString());
            }
        }
        
    }
}
