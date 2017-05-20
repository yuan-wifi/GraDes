using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace test
{
    public partial class VoteWindow : Form
    {
        public VoteWindow(int pici, int turn, int invcode, int level)
        {
            this.pici = pici;
            this.turn = turn;
            this.invcode = invcode;
            this.level = level;
            InitializeComponent();
        }

        public static int RowCount = 0;
        private int invcode;
        private int pici;
        private int turn;
        private int level;
        DataBase db = new DataBase();
        DataTable dt = new DataTable();



        #region 窗体载入
        private void VoteWindow_Load(object sender, EventArgs e)
        {
            if (level == 1)
            {
                BGW2.RunWorkerAsync();
                openwindow();
                //设置DataGridView控件外观
                dataGridView1.Columns[0].HeaderText = "姓名";
                dataGridView1.Columns[1].HeaderText = "身份证号";
                dataGridView1.Columns[2].HeaderText = "地市州";
                dataGridView1.Columns[3].HeaderText = "所在单位";
                dataGridView1.Columns[4].HeaderText = "拟评审专业技术职务";
                dataGridView1.Columns[5].HeaderText = "学科组";
                //添加同意CheckBox
                DataGridViewCheckBoxColumn agreeCheckBox = new DataGridViewCheckBoxColumn();
                agreeCheckBox.Name = "agree";
                agreeCheckBox.HeaderText = "赞成";
                this.dataGridView1.Columns.Insert(6, agreeCheckBox);
                //添加不同意CheckBox
                DataGridViewCheckBoxColumn disagreeCheckBox = new DataGridViewCheckBoxColumn();
                disagreeCheckBox.Name = "disagree";
                disagreeCheckBox.HeaderText = "反对";
                this.dataGridView1.Columns.Insert(7, disagreeCheckBox);
                //添加弃权CheckBox
                DataGridViewCheckBoxColumn giveupCheckBox = new DataGridViewCheckBoxColumn();
                giveupCheckBox.Name = "giveup";
                giveupCheckBox.HeaderText = "放弃";
                this.dataGridView1.Columns.Insert(8, giveupCheckBox);
                //不允许自增行
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.CellClick += DataG_CellClick;
                //表头不换行
                dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
                //循环前6列禁止点击
                for (int i = 0; i < 6; i++)
                {
                    this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    dataGridView1.Columns[i].ReadOnly = true;
                }
                //设置DataGridView控件在自动调整列宽时使用的模式
                dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            }
            else
            {
                dt = db.Loaduserinfor().Tables[0];
                dataGridView1.DataSource = dt;
                //设置DataGridView控件外观
                dataGridView1.Columns[0].HeaderText = "邀请码";
                dataGridView1.Columns[1].HeaderText = "身份等级";
                dataGridView1.Columns[2].HeaderText = "用户登录状态";
                dataGridView1.Columns[3].HeaderText = "用户投票状态";
                //邀请码和等级无法更改
                dataGridView1.Columns[0].ReadOnly = true;
                dataGridView1.Columns[1].ReadOnly = true;
                //登录状态和投票状态可以更改
                dataGridView1.Columns[2].ReadOnly = false;
                dataGridView1.Columns[3].ReadOnly = false;
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.AllowUserToDeleteRows = false;
                //设置DataGridView控件在自动调整列宽时使用的模式
                dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                button6.Visible = false;
                button1.Text = "删除此数据";
                button2.Text = "更新此数据";
                button3.Text = "全部删除";
                button4.Text = "全部更新";
            }
        }

        //实现复选框单选功能
        private void DataG_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int row = e.RowIndex;
            int col = e.ColumnIndex;
            if (col >= 6)
            {
                dataGridView1.Rows[row].Cells[6].Value = false;
                dataGridView1.Rows[row].Cells[7].Value = false;
                dataGridView1.Rows[row].Cells[8].Value = false;
                dataGridView1.Rows[row].Cells[col].Value = true;
            }

        }

        #endregion

        #region 全部赞成
        private void button6_Click(object sender, EventArgs e)
        {
            int count = dataGridView1.RowCount;
            for (int i = 0; i < count; i++)
            {
                dataGridView1.Rows[i].Cells[6].Value = true;
                dataGridView1.Rows[i].Cells[7].Value = false;
                dataGridView1.Rows[i].Cells[8].Value = false;
            }
        }
        #endregion

        #region 全部反对/删除单个user(管理员)
        private void button1_Click(object sender, EventArgs e)
        {
            if (level == 1)
            {
                int count = dataGridView1.RowCount;
                for (int i = 0; i < count; i++)
                {
                    dataGridView1.Rows[i].Cells[6].Value = false;
                    dataGridView1.Rows[i].Cells[7].Value = true;
                    dataGridView1.Rows[i].Cells[8].Value = false;
                }
            }
            else
            {
                int row = this.dataGridView1.CurrentCell.RowIndex;//获取选中单元格的行号
                string code = dataGridView1.Rows[row].Cells[0].Value.ToString();//获取选中单元格行号的邀请码
                MessageBox.Show(db.Deleteauserinfor(int.Parse(code)));
                dt = db.Loaduserinfor().Tables[0];
                dataGridView1.DataSource = dt;
            }

        }
        #endregion

        #region 全部放弃/删除全部user(管理员)
        private void button3_Click(object sender, EventArgs e)
        {
            if (level == 1)
            {
                int count = dataGridView1.RowCount;
                for (int i = 0; i < count; i++)
                {
                    dataGridView1.Rows[i].Cells[6].Value = false;
                    dataGridView1.Rows[i].Cells[7].Value = false;
                    dataGridView1.Rows[i].Cells[8].Value = true;
                }
            }
            else
            {
                MessageBox.Show(db.Deletealluserinfor());
                dt = db.Loaduserinfor().Tables[0];
                dataGridView1.DataSource = dt;
            }
        }
        #endregion

        #region 全部重选/更新单个user(管理员)
        private void button2_Click(object sender, EventArgs e)
        {
            if (level == 1)
            {
                int count = dataGridView1.RowCount;
                for (int i = 0; i < count; i++)
                {
                    dataGridView1.Rows[i].Cells[6].Value = false;
                    dataGridView1.Rows[i].Cells[7].Value = false;
                    dataGridView1.Rows[i].Cells[8].Value = false;
                }
            }
            else
            {
                int row = this.dataGridView1.CurrentCell.RowIndex;//获取选中单元格的行号
                string code = dataGridView1.Rows[row].Cells[0].Value.ToString();//获取选中单元格行号的邀请码
                string level = dataGridView1.Rows[row].Cells[1].Value.ToString();//获取选中单元格行号的用户等级
                string status = dataGridView1.Rows[row].Cells[2].Value.ToString();//获取选中单元格行号的登录状态
                string active = dataGridView1.Rows[row].Cells[3].Value.ToString();//获取选中单元格行号的投票状态
                MessageBox.Show(db.Updateauserinfor(int.Parse(code), int.Parse(level), int.Parse(status), int.Parse(active)));
                dt = db.Loaduserinfor().Tables[0];
                dataGridView1.DataSource = dt;
            }

        }
        #endregion

        #region 提交投票/更新全部user(管理员)
        private void button4_Click(object sender, EventArgs e)
        {
            if (level == 1)
            {
                BGW1.RunWorkerAsync();
                openwindow();
            }
            else
            {
                List<string> listcode = new List<string>();//邀请码
                List<string> liststatus = new List<string>();//登录状态
                List<string> listactive = new List<string>();//投票状态
                string sql = "";
                for (int i=0; i< dataGridView1.RowCount; i++)
                {
                    listcode.Add(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    liststatus.Add(dataGridView1.Rows[i].Cells[2].Value.ToString());
                    listactive.Add(dataGridView1.Rows[i].Cells[3].Value.ToString());
                }
                
                for(int j=0 ; j < listcode.Count ; j++)
                {
                    //拼update语句
                    sql = "update users_infor set users_status="+liststatus[j]+",users_act="+listactive[j]+" where users_code = "+listcode[j]+";"+sql;
                }
                MessageBox.Show(db.Updatealluserinfor(sql));
                dt = db.Loaduserinfor().Tables[0];
                dataGridView1.DataSource = dt;

            }

        }
        #endregion

        #region 搜索功能

        //记录已查找过的行数
        public static int SetGetRow
        {
            set
            {
                if (RowCount != value) { RowCount = value; }
            }
            get { return RowCount; }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            int row = dataGridView1.Rows.Count;//得到总行数
            int cell = dataGridView1.Rows[1].Cells.Count;//得到总列数
            int _length = this.textBox1.Text.Trim().Length;
            if (_length > 0)
            {
                for (int i = SetGetRow; i < row; i++)//得到总行数并在之内循环
                {
                    for (int j = 0; j < cell; j++)//得到总列数并在之内循环
                    {
                        //精确查找
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                        {
                            //对比TexBox中的值是否与dataGridView中的值相同
                            if (this.textBox1.Text.Trim() == dataGridView1.Rows[i].Cells[j].Value.ToString().Trim())
                            {
                                dataGridView1.CurrentCell = dataGridView1[j, i];//定位到相同的单元格
                                dataGridView1.Rows[i].Selected = true;//定位到行
                                SetGetRow = i + 1; return;//返回
                            }
                            //模糊查找定位（连续长度相同才认为是相似）
                            /*模糊查找定位算法 
                              从1到对应的表格内容长度查找 
                              先找到第一个字符与要查找的内容对应的第一个字符相同
                              然后查找后面的相同长度的内容是否相同，
                              相同则定位到此行 */
                        }
                        //模糊查找
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                        {
                            for (int k = 0; k < dataGridView1.Rows[i].Cells[j].Value.ToString().Trim().Length; k++)
                            {
                                if (_length <= dataGridView1.Rows[i].Cells[j].Value.ToString().Trim().Length - k)//判断要查找内容的长度是否小于对比的内容的长度
                                {
                                    if (this.textBox1.Text.Trim().Substring(0, 1) == dataGridView1.Rows[i].Cells[j].Value.ToString().Trim().Substring(k, 1))//判断第一个字符是否与要对比的内容的第一个字符相同
                                    {
                                        if (this.textBox1.Text.Trim() == dataGridView1.Rows[i].Cells[j].Value.ToString().Trim().Substring(k, _length))//判断是查找内容与对比内容否相等
                                        {
                                            dataGridView1.CurrentCell = dataGridView1[j, i];//定位到相同的单元格
                                            dataGridView1.Rows[i].Selected = true;//定位到行
                                            SetGetRow = i + 1; return;//返回
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                SetGetRow = 0;
                MessageBox.Show("没有再次找到相关记录，或没有与之相似的记录！", "搜索结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("输入搜索条件有误！", "搜索结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        #endregion

        #region 双击单元格
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (level == 1)
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)   //双击标题不出错
                    return;

                string idcard = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                //实例化子窗体
                ViewInforWindow viewinfor = new ViewInforWindow(idcard);
                //弹出模式对话框（子窗体）
                viewinfor.ShowDialog();
            }
            else
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0)   //双击标题不出错
                    return;
            }

        }
        #endregion

        //打开loading窗口
        public void openwindow()
        {
            try
            {
                Loading loading = new Loading();
                loading.ShowDialog();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        #region 提交按钮backgroundWork
        private void BGW1_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> listcell6 = new List<string>();//同意
            List<string> listcell7 = new List<string>();//反对
            List<string> listcell8 = new List<string>();//弃权
            int count = dataGridView1.RowCount;
            bool isallcheck = true;
            for (int i = 0; i < count; i++)
            {
                if (!Convert.ToBoolean(dataGridView1.Rows[i].Cells[6].Value)
                    && !Convert.ToBoolean(dataGridView1.Rows[i].Cells[7].Value)
                    && !Convert.ToBoolean(dataGridView1.Rows[i].Cells[8].Value)
                    )
                {
                    isallcheck = false;
                    break;
                }
                else
                {
                    continue;
                }
            }
            if (isallcheck)
            {
                string where6 = " ";
                string where7 = " ";
                string where8 = " ";
                for (int i = 0; i < count; i++)
                {
                    if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[6].Value))
                    {
                        listcell6.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
                        continue;
                    }
                    else if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[7].Value))
                    {
                        listcell7.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
                        continue;
                    }
                    else if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[8].Value))
                    {
                        listcell8.Add(dataGridView1.Rows[i].Cells[1].Value.ToString());
                        continue;
                    }
                    else
                    {
                        MessageBox.Show("提交失败", "提交结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }

                if (listcell6.Count != 0)
                {
                    where6 = "'" + listcell6[0] + "'";
                    for (int x = 1; x < listcell6.Count; x++)
                    {
                        where6 = "'" + listcell6[x] + " '" + "," + where6;
                    }
                    string update6 = "update 中学人员信息表 set 评委会同意人数 +=1 where 身份证号码 in(" + where6 + ")";
                    //string msg =  db.Submitvoteinfor(update6);
                    //MessageBox.Show(msg);
                    db.Submitvoteinfor(update6);

                }

                if (listcell7.Count != 0)
                {
                    where7 = "'" + listcell7[0] + "'";
                    for (int y = 1; y < listcell7.Count; y++)
                    {
                        where7 = "'" + listcell7[y] + " '" + "," + where7;
                    }
                    string update7 = "update 中学人员信息表 set 评委会不同意人数 +=1 where 身份证号码 in(" + where7 + ")";
                    db.Submitvoteinfor(update7);
                }

                if (listcell8.Count != 0)
                {
                    where8 = "'" + listcell8[0] + "'";
                    for (int z = 1; z < listcell8.Count; z++)
                    {
                        where8 = "'" + listcell8[z] + " '" + "," + where8;
                    }
                    string update8 = "update 中学人员信息表 set 评委会弃权人数 +=1 where 身份证号码 in(" + where8 + ")";
                    db.Submitvoteinfor(update8);
                }

                //更新用户状态
                db.Updatestatus(invcode);
                MessageBox.Show("你已成功提交投票", "提交结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Control.CheckForIllegalCrossThreadCalls = false;
                Application.OpenForms["loading"].Close();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void BGW1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Control.CheckForIllegalCrossThreadCalls = false;
                Application.OpenForms["loading"].Close();
                MessageBox.Show("你有未完成的投票，请完成投票");
            }
            else
            {
                // 实例化子窗体
                WaittingWindow waittingwindow = new WaittingWindow(pici, turn, invcode);
                this.Hide();
                //弹出模式对话框（子窗体）
                waittingwindow.ShowDialog();
                Application.ExitThread();
            }

        }
        #endregion

        #region 加载数据backgroundWork
        private void BGW2_DoWork(object sender, DoWorkEventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            dt = db.Loadvoteinfor(pici).Tables[0];
        }

        private void BGW2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = true;
            Application.OpenForms["loading"].Close();
            dataGridView1.DataSource = dt;
        }
        #endregion

    }
}
