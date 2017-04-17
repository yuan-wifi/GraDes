using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.IO;

namespace test
{
    class SqlConnector
    {
        public static string ConnStr;
        SqlConnection Conn = new SqlConnection(ConnStr);
        //连接数据库
        public bool Link()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(ConnStr);
                Conn.Open();
                Conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //校验邀请码
        public bool Checkcode(int code)
        {
            try
            {
                string loginsql = "Select users_status from users_infor where users_code=" + code + "update user_status from users_infor where user_code=" + code;
                SqlConnection Conn = new SqlConnection(ConnStr);
                SqlCommand com = new SqlCommand(loginsql, Conn);
                Conn.Open();
                SqlDataReader dr = com.ExecuteReader();
                dr.Read();//从dr对象中读取第一条数据
                if (dr.HasRows)
                {
                    if (dr["users_status"].ToString() == "0")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                Conn.Close();
            }
        }
    }
}
