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

        private void login_Click(object sender, EventArgs e)
        {
            //判断是否输入数字
            try
            {   //某些操作
                int invcode = int.Parse(Invitecode.Text);
                MessageBox.Show(invcode.ToString());
                
            }
            catch
            {   //提示输入不是数字
                MessageBox.Show("输入错误，请重新输入！");
                
            }
        }
    }
}
