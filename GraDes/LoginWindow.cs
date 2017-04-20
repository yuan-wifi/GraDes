using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class LoginForm : Form
    {
        DataBase sql = new DataBase();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void Invitecode_KeyPress(object sender, KeyPressEventArgs e)
        {
            //判断是否输入数字
            if (e.KeyChar != '\b')//这是允许输入退格键  
            {
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字  
                {
                    e.Handled = true;
                }
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            Invitecode.Clear();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (Invitecode.Text.Length == 6)
            {
                //某些操作
                int invcode = int.Parse(Invitecode.Text);

                //数据库字符串拼接
                DataBase.ConnStr = "Data Source=.;Initial Catalog=gra_des;Trusted_Connection=True";
                if (sql.Link())
                {
                    if (sql.Checkcode(invcode))
                    {
                        VoteWindow vote = new VoteWindow();
                        this.Hide();
                        vote.ShowDialog();
                        Application.ExitThread();
                    }
                    else
                    {
                        MessageBox.Show("账户已登录或不存在！");
                    }
                }
                else
                {
                    MessageBox.Show("连接数据库失败！");
                }
            }
            else
            {
                MessageBox.Show("输入长度有误！");
            }
        }
    }
}

