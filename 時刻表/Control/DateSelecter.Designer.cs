namespace 時刻表
{
    partial class DateSelecter
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.year = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.month = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.day = new System.Windows.Forms.Label();
            this.year_ = new System.Windows.Forms.TextBox();
            this.month_ = new System.Windows.Forms.TextBox();
            this.day_ = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // year
            // 
            this.year.AutoSize = true;
            this.year.Location = new System.Drawing.Point(5, 3);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(36, 16);
            this.year.TabIndex = 0;
            this.year.Text = "9998";
            this.year.Click += new System.EventHandler(this.year_Click);
            this.year.DoubleClick += new System.EventHandler(this.year_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "年";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "月";
            // 
            // month
            // 
            this.month.AutoSize = true;
            this.month.Location = new System.Drawing.Point(53, 3);
            this.month.Name = "month";
            this.month.Size = new System.Drawing.Size(22, 16);
            this.month.TabIndex = 2;
            this.month.Text = "12";
            this.month.Click += new System.EventHandler(this.year_Click);
            this.month.DoubleClick += new System.EventHandler(this.month_DoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(102, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "日";
            // 
            // day
            // 
            this.day.AutoSize = true;
            this.day.Location = new System.Drawing.Point(85, 3);
            this.day.Name = "day";
            this.day.Size = new System.Drawing.Size(22, 16);
            this.day.TabIndex = 4;
            this.day.Text = "31";
            this.day.Click += new System.EventHandler(this.year_Click);
            this.day.DoubleClick += new System.EventHandler(this.day_DoubleClick);
            // 
            // year_
            // 
            this.year_.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.year_.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.year_.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.year_.Location = new System.Drawing.Point(128, 6);
            this.year_.Name = "year_";
            this.year_.Size = new System.Drawing.Size(38, 16);
            this.year_.TabIndex = 6;
            this.year_.Visible = false;
            this.year_.KeyDown += new System.Windows.Forms.KeyEventHandler(this.year__KeyDown_1);
            // 
            // month_
            // 
            this.month_.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.month_.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.month_.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.month_.Location = new System.Drawing.Point(136, 3);
            this.month_.Name = "month_";
            this.month_.Size = new System.Drawing.Size(38, 16);
            this.month_.TabIndex = 7;
            this.month_.Visible = false;
            this.month_.KeyDown += new System.Windows.Forms.KeyEventHandler(this.month__KeyDown);
            // 
            // day_
            // 
            this.day_.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.day_.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.day_.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.day_.Location = new System.Drawing.Point(118, -1);
            this.day_.Name = "day_";
            this.day_.Size = new System.Drawing.Size(38, 16);
            this.day_.TabIndex = 8;
            this.day_.Visible = false;
            this.day_.KeyDown += new System.Windows.Forms.KeyEventHandler(this.day__KeyDown);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.label1.Location = new System.Drawing.Point(133, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "▼";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // DateSelecter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.day_);
            this.Controls.Add(this.month_);
            this.Controls.Add(this.year_);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.day);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.month);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.year);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DateSelecter";
            this.Size = new System.Drawing.Size(155, 21);
            this.Load += new System.EventHandler(this.DateSelecter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label year;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label month;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label day;
        private System.Windows.Forms.TextBox year_;
        private System.Windows.Forms.TextBox month_;
        private System.Windows.Forms.TextBox day_;
        private System.Windows.Forms.Label label1;
    }
}
