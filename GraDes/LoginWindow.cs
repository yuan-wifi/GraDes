using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            Invitecode.Clear();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            //判断是否输入数字
            try
            {
                //某些操作
                int invcode = int.Parse(Invitecode.Text);
                //判断长度是否为6
                if (Invitecode.Text.Length == 6)
                {
                    VoteWindow vote = new VoteWindow();
                    this.Hide();
                    vote.ShowDialog();
                    Application.ExitThread();
                }
                else
                {
                    //提示输入长度不对
                    MessageBox.Show("请输入正确的邀请码！");
                }

            }
            catch
            {
                //提示输入不是数字
                MessageBox.Show("输入错误，请重新输入！");

            }
        }
    }
}
