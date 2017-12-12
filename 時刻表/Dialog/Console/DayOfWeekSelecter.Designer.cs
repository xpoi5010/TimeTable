namespace 時刻表.Dialog.Console
{
    partial class DayOfWeekSelecter
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.click = new System.Windows.Forms.Panel();
            this.everyday = new System.Windows.Forms.RadioButton();
            this.weekdays = new System.Windows.Forms.RadioButton();
            this.weekly = new System.Windows.Forms.RadioButton();
            this.weekends = new System.Windows.Forms.RadioButton();
            this.week = new System.Windows.Forms.Panel();
            this.Sun = new System.Windows.Forms.Label();
            this.Mon = new System.Windows.Forms.Label();
            this.Tue = new System.Windows.Forms.Label();
            this.Wed = new System.Windows.Forms.Label();
            this.Thu = new System.Windows.Forms.Label();
            this.Fri = new System.Windows.Forms.Label();
            this.Sat = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.click.SuspendLayout();
            this.week.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.panel1.Controls.Add(this.click);
            this.panel1.Controls.Add(this.week);
            this.panel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Location = new System.Drawing.Point(0, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(203, 109);
            this.panel1.TabIndex = 11;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // click
            // 
            this.click.Controls.Add(this.everyday);
            this.click.Controls.Add(this.weekdays);
            this.click.Controls.Add(this.weekly);
            this.click.Controls.Add(this.weekends);
            this.click.Location = new System.Drawing.Point(2, 2);
            this.click.Name = "click";
            this.click.Size = new System.Drawing.Size(197, 84);
            this.click.TabIndex = 23;
            // 
            // everyday
            // 
            this.everyday.AutoSize = true;
            this.everyday.Checked = true;
            this.everyday.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.everyday.Location = new System.Drawing.Point(0, 0);
            this.everyday.Name = "everyday";
            this.everyday.Size = new System.Drawing.Size(50, 20);
            this.everyday.TabIndex = 18;
            this.everyday.TabStop = true;
            this.everyday.Text = "每天";
            this.everyday.UseVisualStyleBackColor = true;
            this.everyday.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // weekdays
            // 
            this.weekdays.AutoSize = true;
            this.weekdays.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.weekdays.Location = new System.Drawing.Point(0, 22);
            this.weekdays.Name = "weekdays";
            this.weekdays.Size = new System.Drawing.Size(82, 20);
            this.weekdays.TabIndex = 19;
            this.weekdays.Text = "上班(課)日";
            this.weekdays.UseVisualStyleBackColor = true;
            this.weekdays.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // weekly
            // 
            this.weekly.AutoSize = true;
            this.weekly.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.weekly.Location = new System.Drawing.Point(0, 66);
            this.weekly.Name = "weekly";
            this.weekly.Size = new System.Drawing.Size(50, 20);
            this.weekly.TabIndex = 21;
            this.weekly.Text = "自訂";
            this.weekly.UseVisualStyleBackColor = true;
            this.weekly.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // weekends
            // 
            this.weekends.AutoSize = true;
            this.weekends.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.weekends.Location = new System.Drawing.Point(0, 44);
            this.weekends.Name = "weekends";
            this.weekends.Size = new System.Drawing.Size(50, 20);
            this.weekends.TabIndex = 20;
            this.weekends.Text = "週末";
            this.weekends.UseVisualStyleBackColor = true;
            this.weekends.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // week
            // 
            this.week.Controls.Add(this.Sun);
            this.week.Controls.Add(this.Mon);
            this.week.Controls.Add(this.Tue);
            this.week.Controls.Add(this.Wed);
            this.week.Controls.Add(this.Thu);
            this.week.Controls.Add(this.Fri);
            this.week.Controls.Add(this.Sat);
            this.week.Location = new System.Drawing.Point(3, 87);
            this.week.Name = "week";
            this.week.Size = new System.Drawing.Size(148, 19);
            this.week.TabIndex = 22;
            // 
            // Sun
            // 
            this.Sun.AutoSize = true;
            this.Sun.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Sun.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Sun.Location = new System.Drawing.Point(3, 3);
            this.Sun.Name = "Sun";
            this.Sun.Size = new System.Drawing.Size(20, 16);
            this.Sun.TabIndex = 17;
            this.Sun.Text = "日";
            this.Sun.Click += new System.EventHandler(this.Weekly_Click);
            // 
            // Mon
            // 
            this.Mon.AutoSize = true;
            this.Mon.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Mon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Mon.Location = new System.Drawing.Point(21, 3);
            this.Mon.Name = "Mon";
            this.Mon.Size = new System.Drawing.Size(20, 16);
            this.Mon.TabIndex = 11;
            this.Mon.Text = "一";
            this.Mon.Click += new System.EventHandler(this.Weekly_Click);
            // 
            // Tue
            // 
            this.Tue.AutoSize = true;
            this.Tue.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Tue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Tue.Location = new System.Drawing.Point(41, 3);
            this.Tue.Name = "Tue";
            this.Tue.Size = new System.Drawing.Size(20, 16);
            this.Tue.TabIndex = 12;
            this.Tue.Text = "二";
            this.Tue.Click += new System.EventHandler(this.Weekly_Click);
            // 
            // Wed
            // 
            this.Wed.AutoSize = true;
            this.Wed.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Wed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Wed.Location = new System.Drawing.Point(61, 3);
            this.Wed.Name = "Wed";
            this.Wed.Size = new System.Drawing.Size(20, 16);
            this.Wed.TabIndex = 13;
            this.Wed.Text = "三";
            this.Wed.Click += new System.EventHandler(this.Weekly_Click);
            // 
            // Thu
            // 
            this.Thu.AutoSize = true;
            this.Thu.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Thu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Thu.Location = new System.Drawing.Point(81, 3);
            this.Thu.Name = "Thu";
            this.Thu.Size = new System.Drawing.Size(20, 16);
            this.Thu.TabIndex = 14;
            this.Thu.Text = "四";
            this.Thu.Click += new System.EventHandler(this.Weekly_Click);
            // 
            // Fri
            // 
            this.Fri.AutoSize = true;
            this.Fri.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Fri.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Fri.Location = new System.Drawing.Point(100, 3);
            this.Fri.Name = "Fri";
            this.Fri.Size = new System.Drawing.Size(20, 16);
            this.Fri.TabIndex = 15;
            this.Fri.Text = "五";
            this.Fri.Click += new System.EventHandler(this.Weekly_Click);
            // 
            // Sat
            // 
            this.Sat.AutoSize = true;
            this.Sat.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Sat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Sat.Location = new System.Drawing.Point(120, 3);
            this.Sat.Name = "Sat";
            this.Sat.Size = new System.Drawing.Size(20, 16);
            this.Sat.TabIndex = 16;
            this.Sat.Text = "六";
            this.Sat.Click += new System.EventHandler(this.Weekly_Click);
            // 
            // DayOfWeekSelecter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "DayOfWeekSelecter";
            this.Size = new System.Drawing.Size(209, 115);
            this.panel1.ResumeLayout(false);
            this.click.ResumeLayout(false);
            this.click.PerformLayout();
            this.week.ResumeLayout(false);
            this.week.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Sun;
        private System.Windows.Forms.Label Sat;
        private System.Windows.Forms.Label Fri;
        private System.Windows.Forms.Label Thu;
        private System.Windows.Forms.Label Wed;
        private System.Windows.Forms.Label Tue;
        private System.Windows.Forms.Label Mon;
        private System.Windows.Forms.RadioButton weekly;
        private System.Windows.Forms.RadioButton weekends;
        private System.Windows.Forms.RadioButton weekdays;
        private System.Windows.Forms.RadioButton everyday;
        private System.Windows.Forms.Panel week;
        private System.Windows.Forms.Panel click;
    }
}
