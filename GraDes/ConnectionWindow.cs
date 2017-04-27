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
    public partial class ConnectionWindow : Form
    {
        DataBase sql = new DataBase();
        public ConnectionWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ip = ipaddress.Text;
            string db = database.Text;
            string uid = userid.Text;
            string pw = password.Text;
            //数据库字符串拼接
            //DataBase.ConnStr = "Data Source=.;Initial Catalog=gra_des;Trusted_Connection=True";
            //DataBase.ConnStr = "server=123.207.250.201;database=gra_des;user=sa;pwd=LUBOYAN960908`";
            String conn = "server=";
            conn += ip;
            conn += ";database=";
            conn += db;
            conn += ";uid=";
            conn += uid;
            conn += ";pwd=";
            conn += pw;
            DataBase.ConnStr = conn;
            if (sql.Link())
            {
                LoginForm vote = new LoginForm();
                this.Hide();
                vote.ShowDialog();
                Application.ExitThread();
            }
            else
            {
                MessageBox.Show("连接数据库失败！");
            }
        }
    }
}
