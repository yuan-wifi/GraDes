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
    class DataBase
    {
        public static string ConnStr;
        SqlConnection Conn = new SqlConnection(ConnStr);
        //连接数据库
        public bool Link()
        {
            try
            {
                SqlConnection Conn = new SqlConnection(ConnStr);//测试数据库
                Conn.Open();
                Conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //校验邀请码&用户是否在线
        public bool Checkcode(int code)
        {
            try
            {
                string loginsql = "Select users_status from users_infor where users_code=" + code;
                SqlConnection Conn = new SqlConnection(ConnStr);
                SqlCommand com = new SqlCommand(loginsql, Conn);
                Conn.Open();
                SqlDataReader dr = com.ExecuteReader();
                dr.Read();//从dr对象中读取第一条数据
                if (dr.HasRows)//查询用户是否存在
                {
                    if (dr["users_status"].ToString() == "0")//检查用户是否已在线
                    {
                        Conn.Close();//关闭第一次查询
                        string upsql = "update users_infor set users_status = 1 where users_code =" + code;
                        DataSet ds = new DataSet();
                        Conn.ConnectionString = ConnStr;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = new SqlCommand(upsql, Conn);
                        da.Fill(ds);
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
        public string[] Loadvoteinfor(string sql)
        {
            string[] str = new string[8];
        }
    }
}
