using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Newtonsoft;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NetdiskClient
{
    public partial class LoginForm : Form
    {
        private static MsgData hp;

        // 初始化
        public LoginForm()
        {
            hp = new MsgData();
            InitializeComponent();
        }

        // 普通用户注册
        private void registerButton_Click(object sender, EventArgs e)
        {
            UserLogin("register");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("Hello");
        }

        // 用户登录或注册
        private void UserLogin(string url)
        {
            ReqUserLoginRegister reqobj = new ReqUserLoginRegister();
            reqobj.user_id = usernameTextBox.Text;
            reqobj.password = passwordTextBox.Text;
            reqobj.disk = 1000000000;
            string msg = hp.postHttpRequest(hp.BaseUrl + "user/" + url, reqobj);

            RespUserCommon resp = JsonConvert.DeserializeObject<RespUserCommon>(msg);
            /*
            Console.WriteLine(resp.status);
            Console.WriteLine(resp.reason);
            Console.WriteLine(resp.user_id);
            */

            if (resp.status == "success")
            {
                ChangeForm(new NetdiskForm(resp.user_id));
            }
            else
            {
                string cap;
                if(url == "register")
                {
                    cap = "注册失败";
                }
                else
                {
                    cap = "登录失败";
                }
                MessageBox.Show(resp.reason, cap);
            }
            
        }

        // 根据传入的参数，决定切换到用户界面或是管理员界面
        private void ChangeForm(Form nextform)
        {
            Thread th = new Thread(delegate () {
                nextform.ShowDialog();
            });
            th.Start();
            this.Close();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if(roleBox.SelectedIndex == 0)
            {
                UserLogin("login");
            }else
            {
                if (usernameTextBox.Text == "dz" && passwordTextBox.Text == "sazi")
                {
                    ChangeForm(new ManagerForm());
                } else
                {
                    MessageBox.Show("管理员不存在", "登录失败");
                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            roleBox.SelectedIndex = 0;
            hp.BaseUrl = File.ReadAllText("config.txt");
            if(hp.BaseUrl.Length == 0)
            {
                MessageBox.Show("请检查config.txt确保输入了服务器地址", "配置问题");
            }
        }

        private void roleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(roleBox.SelectedIndex == 0)
            {
                registerButton.Enabled = true;
            }
            else
            {
                registerButton.Enabled = false;
            }
        }
    }
}
