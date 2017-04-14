namespace test
{
    partial class VoteWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DataG = new System.Windows.Forms.DataGridView();
            this.姓名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.身份证 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.地市州 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.所在单位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.拟评审专业技术职务 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.学科组 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.赞成 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.反对 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.弃权 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DataG)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataG
            // 
            this.DataG.AllowUserToAddRows = false;
            this.DataG.AllowUserToDeleteRows = false;
            this.DataG.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.DataG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.姓名,
            this.身份证,
            this.地市州,
            this.所在单位,
            this.拟评审专业技术职务,
            this.学科组,
            this.赞成,
            this.反对,
            this.弃权});
            this.DataG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataG.Location = new System.Drawing.Point(0, 0);
            this.DataG.MultiSelect = false;
            this.DataG.Name = "DataG";
            this.DataG.RowHeadersWidth = 60;
            this.DataG.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.DataG.RowTemplate.Height = 23;
            this.DataG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataG.Size = new System.Drawing.Size(962, 595);
            this.DataG.TabIndex = 1;
            // 
            // 姓名
            // 
            this.姓名.FillWeight = 85.84549F;
            this.姓名.Frozen = true;
            this.姓名.HeaderText = "姓名";
            this.姓名.Name = "姓名";
            this.姓名.ReadOnly = true;
            // 
            // 身份证
            // 
            this.身份证.Frozen = true;
            this.身份证.HeaderText = "身份证";
            this.身份证.Name = "身份证";
            this.身份证.ReadOnly = true;
            // 
            // 地市州
            // 
            this.地市州.FillWeight = 110.5806F;
            this.地市州.Frozen = true;
            this.地市州.HeaderText = "地市州";
            this.地市州.Name = "地市州";
            this.地市州.ReadOnly = true;
            // 
            // 所在单位
            // 
            this.所在单位.FillWeight = 148.7989F;
            this.所在单位.Frozen = true;
            this.所在单位.HeaderText = "所在单位";
            this.所在单位.Name = "所在单位";
            this.所在单位.ReadOnly = true;
            // 
            // 拟评审专业技术职务
            // 
            this.拟评审专业技术职务.FillWeight = 148.7989F;
            this.拟评审专业技术职务.Frozen = true;
            this.拟评审专业技术职务.HeaderText = "拟评审专业技术职务";
            this.拟评审专业技术职务.Name = "拟评审专业技术职务";
            this.拟评审专业技术职务.ReadOnly = true;
            this.拟评审专业技术职务.Width = 152;
            // 
            // 学科组
            // 
            this.学科组.FillWeight = 148.7989F;
            this.学科组.HeaderText = "学科组";
            this.学科组.Name = "学科组";
            this.学科组.ReadOnly = true;
            // 
            // 赞成
            // 
            this.赞成.FillWeight = 52.79188F;
            this.赞成.HeaderText = "赞成";
            this.赞成.Name = "赞成";
            this.赞成.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // 反对
            // 
            this.反对.FillWeight = 52.79188F;
            this.反对.HeaderText = "反对";
            this.反对.Name = "反对";
            this.反对.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // 弃权
            // 
            this.弃权.FillWeight = 52.79188F;
            this.弃权.HeaderText = "弃权";
            this.弃权.Name = "弃权";
            this.弃权.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel1.Controls.Add(this.button1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.button4, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.button5, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 549);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(962, 46);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(387, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "全部同意";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(502, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 40);
            this.button2.TabIndex = 1;
            this.button2.Text = "全部反对";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(617, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(109, 40);
            this.button3.TabIndex = 2;
            this.button3.Text = "全部放弃";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(732, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(109, 40);
            this.button4.TabIndex = 3;
            this.button4.Text = "全部重选";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(847, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(112, 40);
            this.button5.TabIndex = 4;
            this.button5.Text = "列出未选";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(254, 41);
            this.textBox1.TabIndex = 5;
            // 
            // VoteWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 595);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.DataG);
            this.Name = "VoteWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "四川省教育厅全省中小学高级职称高评委网络投票系统";
            ((System.ComponentModel.ISupportInitialize)(this.DataG)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataG;
        private System.Windows.Forms.DataGridViewTextBoxColumn 姓名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 身份证;
        private System.Windows.Forms.DataGridViewTextBoxColumn 地市州;
        private System.Windows.Forms.DataGridViewTextBoxColumn 所在单位;
        private System.Windows.Forms.DataGridViewTextBoxColumn 拟评审专业技术职务;
        private System.Windows.Forms.DataGridViewTextBoxColumn 学科组;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 赞成;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 反对;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 弃权;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox1;
    }
}