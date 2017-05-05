﻿using System;
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
        public VoteWindow(int pici, int turn, int invcode)
        {
            this.pici = pici;
            this.turn = turn;
            this.invcode = invcode;
            InitializeComponent();
        }

        public static int RowCount = 0;
        private int invcode;
        private int pici;
        private int turn;
        DataBase db = new DataBase();
        DataTable dt = new DataTable();

        #region 窗体载入
        private void VoteWindow_Load(object sender, EventArgs e)
        {
            BGW2.RunWorkerAsync();
            openwindow();
            //设置DataGridView控件外观
            DataG.Columns[0].HeaderText = "姓名";
            DataG.Columns[1].HeaderText = "身份证号";
            DataG.Columns[2].HeaderText = "地市州";
            DataG.Columns[3].HeaderText = "所在单位";
            DataG.Columns[4].HeaderText = "拟评审专业技术职务";
            DataG.Columns[5].HeaderText = "学科组";
            //添加同意CheckBox
            DataGridViewCheckBoxColumn agreeCheckBox = new DataGridViewCheckBoxColumn();
            agreeCheckBox.Name = "agree";
            agreeCheckBox.HeaderText = "赞成";
            this.DataG.Columns.Insert(6, agreeCheckBox);
            //添加不同意CheckBox
            DataGridViewCheckBoxColumn disagreeCheckBox = new DataGridViewCheckBoxColumn();
            disagreeCheckBox.Name = "disagree";
            disagreeCheckBox.HeaderText = "反对";
            this.DataG.Columns.Insert(7, disagreeCheckBox);
            //添加弃权CheckBox
            DataGridViewCheckBoxColumn giveupCheckBox = new DataGridViewCheckBoxColumn();
            giveupCheckBox.Name = "giveup";
            giveupCheckBox.HeaderText = "放弃";
            this.DataG.Columns.Insert(8, giveupCheckBox);
            //不允许自增行
            DataG.AllowUserToAddRows = false;
            DataG.CellClick += DataG_CellClick;
            //表头不换行
            DataG.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            //循环前6列禁止点击
            for (int i = 0; i < 6; i++)
            {
                this.DataG.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                DataG.Columns[i].ReadOnly = true;
            }
            //设置DataGridView控件在自动调整列宽时使用的模式
            DataG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

        }
        //实现复选框单选功能
        private void DataG_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int row = e.RowIndex;
            int col = e.ColumnIndex;
            if (col >= 6)
            {
                DataG.Rows[row].Cells[6].Value = false;
                DataG.Rows[row].Cells[7].Value = false;
                DataG.Rows[row].Cells[8].Value = false;
                DataG.Rows[row].Cells[col].Value = true;
            }

        }

        #endregion

        #region 全部赞成
        private void button6_Click(object sender, EventArgs e)
        {
            int count = DataG.RowCount;
            for (int i = 0; i < count; i++)
            {
                DataG.Rows[i].Cells[6].Value = true;
                DataG.Rows[i].Cells[7].Value = false;
                DataG.Rows[i].Cells[8].Value = false;
            }
        }
        #endregion

        #region 全部反对
        private void button1_Click(object sender, EventArgs e)
        {
            int count = DataG.RowCount;
            for (int i = 0; i < count; i++)
            {
                DataG.Rows[i].Cells[6].Value = false;
                DataG.Rows[i].Cells[7].Value = true;
                DataG.Rows[i].Cells[8].Value = false;
            }
        }
        #endregion

        #region 全部放弃
        private void button3_Click(object sender, EventArgs e)
        {
            int count = DataG.RowCount;
            for (int i = 0; i < count; i++)
            {
                DataG.Rows[i].Cells[6].Value = false;
                DataG.Rows[i].Cells[7].Value = false;
                DataG.Rows[i].Cells[8].Value = true;
            }
        }
        #endregion

        #region 全部重选
        private void button2_Click(object sender, EventArgs e)
        {
            int count = DataG.RowCount;
            for (int i = 0; i < count; i++)
            {
                DataG.Rows[i].Cells[6].Value = false;
                DataG.Rows[i].Cells[7].Value = false;
                DataG.Rows[i].Cells[8].Value = false;
            }
        }
        #endregion

        #region 提交投票
        private void button4_Click(object sender, EventArgs e)
        {
            BGW1.RunWorkerAsync();
            openwindow();
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

            int row = DataG.Rows.Count;//得到总行数
            int cell = DataG.Rows[1].Cells.Count;//得到总列数
            int _length = this.textBox1.Text.Trim().Length;
            if (_length > 0)
            {
                for (int i = SetGetRow; i < row; i++)//得到总行数并在之内循环
                {
                    for (int j = 0; j < cell; j++)//得到总列数并在之内循环
                    {
                        //精确查找
                        if (DataG.Rows[i].Cells[j].Value != null)
                        {
                            //对比TexBox中的值是否与dataGridView中的值相同
                            if (this.textBox1.Text.Trim() == DataG.Rows[i].Cells[j].Value.ToString().Trim())
                            {
                                DataG.CurrentCell = DataG[j, i];//定位到相同的单元格
                                DataG.Rows[i].Selected = true;//定位到行
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
                        if (DataG.Rows[i].Cells[j].Value != null)
                        {
                            for (int k = 0; k < DataG.Rows[i].Cells[j].Value.ToString().Trim().Length; k++)
                            {
                                if (_length <= DataG.Rows[i].Cells[j].Value.ToString().Trim().Length - k)//判断要查找内容的长度是否小于对比的内容的长度
                                {
                                    if (this.textBox1.Text.Trim().Substring(0, 1) == DataG.Rows[i].Cells[j].Value.ToString().Trim().Substring(k, 1))//判断第一个字符是否与要对比的内容的第一个字符相同
                                    {
                                        if (this.textBox1.Text.Trim() == DataG.Rows[i].Cells[j].Value.ToString().Trim().Substring(k, _length))//判断是查找内容与对比内容否相等
                                        {
                                            DataG.CurrentCell = DataG[j, i];//定位到相同的单元格
                                            DataG.Rows[i].Selected = true;//定位到行
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
        private void DataG_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string idcard = DataG.Rows[e.RowIndex].Cells[1].Value.ToString();
            //实例化子窗体
            ViewInforWindow viewinfor = new ViewInforWindow(idcard);
            //弹出模式对话框（子窗体）
            viewinfor.ShowDialog();
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
            int count = DataG.RowCount;
            bool isallcheck = true;
            for (int i = 0; i < count; i++)
            {
                if (!Convert.ToBoolean(DataG.Rows[i].Cells[6].Value)
                    && !Convert.ToBoolean(DataG.Rows[i].Cells[7].Value)
                    && !Convert.ToBoolean(DataG.Rows[i].Cells[8].Value)
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
                    if (Convert.ToBoolean(DataG.Rows[i].Cells[6].Value))
                    {
                        listcell6.Add(DataG.Rows[i].Cells[1].Value.ToString());
                        continue;
                    }
                    else if (Convert.ToBoolean(DataG.Rows[i].Cells[7].Value))
                    {
                        listcell7.Add(DataG.Rows[i].Cells[1].Value.ToString());
                        continue;
                    }
                    else if (Convert.ToBoolean(DataG.Rows[i].Cells[8].Value))
                    {
                        listcell8.Add(DataG.Rows[i].Cells[1].Value.ToString());
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
                    where6 = listcell6[0];
                    for (int x = 1; x < listcell6.Count; x++)
                    {
                        where6 = listcell6[x] + "," + where6;
                    }
                    string update6 = "update 中学人员信息表 set 评委会同意人数 +=1 where 身份证号码 in(" + where6 + ")";
                    db.Submitvoteinfor(update6);
                }

                if (listcell7.Count != 0)
                {
                    where7 = listcell7[0];
                    for (int y = 1; y < listcell7.Count; y++)
                    {
                        where7 = listcell7[y] + "," + where7;
                    }
                    string update7 = "update 中学人员信息表 set 评委会不同意人数 +=1 where 身份证号码 in(" + where7 + ")";
                    db.Submitvoteinfor(update7);
                }

                if (listcell8.Count != 0)
                {
                    where8 = listcell8[0];
                    for (int z = 1; z < listcell8.Count; z++)
                    {
                        where8 = listcell8[z] + "," + where8;
                    }
                    string update8 = "update 中学人员信息表 set 评委会弃权人数 +=1 where 身份证号码 in(" + where8 + ")";
                    db.Submitvoteinfor(update8);
                }

                //更新用户状态
                db.Updatestatus(invcode);
                MessageBox.Show("你已成功提交投票", "提交结果", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void BGW1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            Application.OpenForms["loading"].Close();
            if (e.Cancelled)
            {
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
            Control.CheckForIllegalCrossThreadCalls = false;
            Application.OpenForms["loading"].Close();
            DataG.DataSource = dt;
        }
#endregion
    }
}
