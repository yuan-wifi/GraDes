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
        public VoteWindow()
        {
            InitializeComponent();
        }
        DataBase db = new DataBase();
        int pici = 1;
        private void VoteWindow_Load(object sender, EventArgs e)
        {
            DataG.DataSource = db.Loadvoteinfor(pici).Tables[0];
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
            //表头不换行
            DataG.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            //循环前6列禁止点击表头
            for (int i = 0; i < 6; i++)
            {
                this.DataG.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                DataG.Columns[i].ReadOnly = true;
            }
            //设置DataGridView控件在自动调整列宽时使用的模式
            DataG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        }
        //全部赞成按钮事件
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

        //全部反对按钮事件
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

        //全部放弃按钮事件
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

        //全部重选按钮事件
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

        private void button4_Click(object sender, EventArgs e)
        {
            int count = DataG.RowCount;
            bool isallcheck = true;
            for (int i = 0; i < count; i++)
            {
                bool cell6 = Convert.ToBoolean(DataG.Rows[i].Cells[6].Value);
                bool cell7 = Convert.ToBoolean(DataG.Rows[i].Cells[7].Value);
                bool cell8 = Convert.ToBoolean(DataG.Rows[i].Cells[8].Value);
                if (!cell6 && !cell7 && !cell8)
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
                MessageBox.Show("OK!");
            }
            else
            {
                MessageBox.Show("你有未完成的投票，请完成投票");
            }
        }
    }
}
