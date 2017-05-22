using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
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
        //生成邀请码,插入数据,并取出生成的邀请码
        public DataSet insertcode()
        {
            DataSet ds = new DataSet();
            try
            {
                Conn.ConnectionString = ConnStr;
                Conn.Open();
                SqlCommand comm = new SqlCommand("insertcode", Conn);
                comm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(comm);
                da.Fill(ds);
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.Message);                  
            }
            finally
            {
                Conn.Close();
            }
            return ds;
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
                        string upsql = "update users_infor set users_status = 1,users_act = 1 where users_code != 123456 and users_code =" + code;
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
        //查询用户等级
        public int Selectlevel(int code)
        {
            int msg;
            try
            {
                string sql = "select users_level from users_infor where users_code= "+code;
                SqlConnection Conn = new SqlConnection(ConnStr);
                SqlCommand com = new SqlCommand(sql, Conn);
                Conn.Open();
                msg = int.Parse(com.ExecuteScalar().ToString());
            }
            finally
            {
                Conn.Close();
            }
            return msg;
        }
        //加载user信息(管理员)
        public DataSet Loaduserinfor()
        {
            string sel = "select * from users_infor where users_code != 123456 ";
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
        //删除单个user信息(管理员)
        public string Deleteauserinfor(int code)
        {
            string msg;
            string deletesql = "delete from users_infor where users_code = " + code;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                Conn.ConnectionString = ConnStr;
                da.SelectCommand = new SqlCommand(deletesql, Conn);
                da.Fill(ds);
            }
            catch(Exception error)
            {
                return msg = error.ToString();
            }
            finally
            {
                Conn.Close();
            }
            return msg = "成功删除此条数据!";
        }
        //删除全部user信息(管理员)
        public  string Deletealluserinfor()
        {
            string msg;
            string deletesql = "delete from users_infor where users_level =1 ";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                Conn.ConnectionString = ConnStr;
                da.SelectCommand = new SqlCommand(deletesql, Conn);
                da.Fill(ds);
            }
            catch (Exception error)
            {
                return msg = error.ToString();
            }
            finally
            {
                Conn.Close();
            }
            return msg = "成功删除!";
        }
        //更新单个user信息(管理员)
        public string Updateauserinfor(int code,int level,int status,int active)
        {
            string msg;
            string deletesql = @"update users_infor set users_status ="+status+",users_act="+active+"where users_code = " + code;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                Conn.ConnectionString = ConnStr;
                da.SelectCommand = new SqlCommand(deletesql, Conn);
                da.Fill(ds);
            }
            catch (Exception error)
            {
                return msg = error.ToString();
            }
            finally
            {
                Conn.Close();
            }
            return msg = "成功更新此条数据!";
        }
        //更新全部user信息(管理员)
        public string Updatealluserinfor(string sql)
        {
            string msg;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                Conn.ConnectionString = ConnStr;
                da.SelectCommand = new SqlCommand(sql, Conn);
                da.Fill(ds);
            }
            catch (Exception error)
            {
                return msg = error.ToString();
            }
            finally
            {
                Conn.Close();
            }
            return msg = "成功更新!";
        }
        //查询总共的批次数批次
        public int Selectturn()
        {
            int msg;
            try
            {
                string sql = "select count(distinct 轮次) from 中学人员信息表";
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
            string sql = "update users_infor set users_act = 2 where users_code=" + code;
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
                msg = "提交数据失败！";
                return msg;
            }
            finally
            {
                Conn.Close();
            }
            return msg = "";
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
        //更新参与投票人数和投票总人数
        public bool updatevotecount(int turn)
        {
            bool msg = false;
            string updatesql = @"update 中学人员信息表 set 
                                 评委会总人数 = (select count(*) from users_infor where users_level = 1),
                                 评委会参加投票人数 = (select count(*) from users_infor where users_act = 2), 
                                 评委会表决结果 = case when 评委会参加投票人数/ 2 < 评委会同意人数 then '通过'
                                 else '未通过'
                                 end where 轮次=" + turn + ";";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            try
            {
                Conn.ConnectionString = ConnStr;
                da.SelectCommand = new SqlCommand(updatesql, Conn);
                da.Fill(ds);
            }
            catch
            {
                return msg;
            }
            finally
            {
                Conn.Close();
            }
            return msg = true;
        }
        //查询投票结果
        public DataSet selectresult(int turn)
        {
            string sel = @"select 姓名,身份证号码,单位所在区域,单位名称,拟评审专业技术职务,
                           评委会名称,评委会总人数,评委会参加投票人数,评委会同意人数,评委会不同意人数,
                           评委会弃权人数,评委会表决结果 
                           from 中学人员信息表 where 轮次=" + turn + " order by 身份证号码 ";
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
    }
}
