namespace test
{
    partial class LoginForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.title = new System.Windows.Forms.Label();
            this.Invitecode = new System.Windows.Forms.TextBox();
            this.Login = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("宋体", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title.Location = new System.Drawing.Point(183, 77);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(360, 56);
            this.title.TabIndex = 0;
            this.title.Text = "请输入邀请码";
            // 
            // Invitecode
            // 
            this.Invitecode.Font = new System.Drawing.Font("宋体", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Invitecode.ImeMode = System.Windows.Forms.ImeMode.AlphaFull;
            this.Invitecode.Location = new System.Drawing.Point(204, 186);
            this.Invitecode.MaxLength = 6;
            this.Invitecode.Name = "Invitecode";
            this.Invitecode.Size = new System.Drawing.Size(304, 62);
            this.Invitecode.TabIndex = 1;
            this.Invitecode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Invitecode_KeyPress);
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(204, 302);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(121, 46);
            this.Login.TabIndex = 2;
            this.Login.Text = "登录";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(386, 302);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(122, 46);
            this.reset.TabIndex = 3;
            this.reset.Text = "重置";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 449);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.Invitecode);
            this.Controls.Add(this.title);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "四川省教育厅全省中小学高级职称高评委网络投票系统";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.TextBox Invitecode;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.Button reset;
    }
}

