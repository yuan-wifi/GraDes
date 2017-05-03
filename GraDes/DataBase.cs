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
            catch (Exception e)
            {
                return false;
                throw new Exception(e.Message);
            }
        }
        //校验邀请码&用户是否在线
        public bool Checkcode(int code)
        {
            try
            {
                string loginsql = "Select users_status,users_act from users_infor where users_code=" + code;
                SqlConnection Conn = new SqlConnection(ConnStr);
                SqlCommand com = new SqlCommand(loginsql, Conn);
                Conn.Open();
                SqlDataReader dr = com.ExecuteReader();
                dr.Read();
                if (dr.HasRows)//查询用户是否存在
                {
                    //检查用户在线和判断用户状态
                    if (dr["users_status"].ToString() == "0" && (dr["users_act"].ToString()=="0" || dr["users_act"].ToString() == "2"))
                    {
                        Conn.Close();//关闭第一次查询
                        string upsql = "update users_infor set users_status = 1,users_act = 1 where users_code =" + code;
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
        //加载投票信息
        public DataSet Loadvoteinfor(int sql)
        {
            string sel = "select 姓名,身份证号码,单位所在区域,单位名称,拟评审专业技术职务,评委会名称 from 中学人员信息表 where 轮次="+sql+ " order by 身份证号码 ";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                Conn.ConnectionString = ConnStr;
                da.SelectCommand = new SqlCommand(sel, Conn);
                da.Fill(ds);
            }
            finally
            {
                Conn.Close();
            }
            return ds;
        }
        //提交投票结果
        public string Submitvoteinfor(string sql)
        {
            string msg = "";

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                Conn.ConnectionString = ConnStr;
                da.SelectCommand = new SqlCommand(sql, Conn);
                da.Fill(ds);
            }
            catch
            {
                msg = "修改失败！";
                return msg;
            }
            finally
            {
                Conn.Close();
            }
            return msg;
        }
        //提交完成更新用户状态
        public string Updatestatus(int code)
        {
            string msg = "";
            string sql = "update users_infor set users_status = 0,users_act = 2 where users_code=" + code;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                Conn.ConnectionString = ConnStr;
                da.SelectCommand = new SqlCommand(sql, Conn);
                da.Fill(ds);
            }
            catch
            {
                msg = "修改失败！";
                return msg;
            }
            finally
            {
                Conn.Close();
            }
            return msg;
        }
        //查询其余用户是否完成投票 
        public int Selectissubmit()
        {
            int msg;
            try
            {
                string sql = "select count(*) from users_infor where users_act = 1";
                SqlConnection Conn = new SqlConnection(ConnStr);
                SqlCommand com = new SqlCommand(sql, Conn);
                Conn.Open();
                object obj = com.ExecuteScalar();
                msg = (int)obj;
            }
            finally
            {
                Conn.Close();
            }
            return msg;
        }
    }
}
