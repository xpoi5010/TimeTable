namespace 時刻表.Dialog
{
    partial class ErrorBox
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.error_code = new System.Windows.Forms.Label();
            this.errorsource = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(12, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(307, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "很不幸的，本軟體發生了些錯誤，以至於本軟體部分\r\n功能無法繼續運行，我們在這裡感到深感抱歉。\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 40);
            this.label2.TabIndex = 1;
            this.label2.Text = "錯誤";
            // 
            // error_code
            // 
            this.error_code.AutoSize = true;
            this.error_code.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.error_code.Location = new System.Drawing.Point(16, 119);
            this.error_code.Name = "error_code";
            this.error_code.Size = new System.Drawing.Size(57, 19);
            this.error_code.TabIndex = 2;
            this.error_code.Text = "錯誤碼:";
            // 
            // errorsource
            // 
            this.errorsource.AutoSize = true;
            this.errorsource.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.errorsource.Location = new System.Drawing.Point(16, 146);
            this.errorsource.Name = "errorsource";
            this.errorsource.Size = new System.Drawing.Size(102, 19);
            this.errorsource.TabIndex = 3;
            this.errorsource.Text = "問題發生原因:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.button1.Location = new System.Drawing.Point(15, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(304, 25);
            this.button1.TabIndex = 4;
            this.button1.Text = "回報給YuanApplicationStudio";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.button2.Location = new System.Drawing.Point(15, 311);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(304, 25);
            this.button2.TabIndex = 5;
            this.button2.Text = "關閉視窗";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ErrorBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(333, 348);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.errorsource);
            this.Controls.Add(this.error_code);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Name = "ErrorBox";
            this.Text = "ErrorBox";
            this.Load += new System.EventHandler(this.ErrorBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label error_code;
        private System.Windows.Forms.Label errorsource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}