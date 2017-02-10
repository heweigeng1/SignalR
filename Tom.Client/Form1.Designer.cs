namespace Tom.Client
{
    partial class Form1
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
            this.msg = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.RTB_MSG = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // msg
            // 
            this.msg.Location = new System.Drawing.Point(12, 40);
            this.msg.Name = "msg";
            this.msg.Size = new System.Drawing.Size(178, 21);
            this.msg.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(196, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "发送";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // RTB_MSG
            // 
            this.RTB_MSG.Location = new System.Drawing.Point(13, 80);
            this.RTB_MSG.Name = "RTB_MSG";
            this.RTB_MSG.Size = new System.Drawing.Size(259, 169);
            this.RTB_MSG.TabIndex = 7;
            this.RTB_MSG.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.msg);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.RTB_MSG);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox msg;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox RTB_MSG;
    }
}

