namespace 時刻表.Dialog
{
    partial class FullScreen
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.event_name = new System.Windows.Forms.Label();
            this.next_event = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "您已進入實作模式中的全螢幕模式";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.button1.Location = new System.Drawing.Point(15, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 26);
            this.button1.TabIndex = 1;
            this.button1.Text = "取消全螢幕模式";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // event_name
            // 
            this.event_name.AutoSize = true;
            this.event_name.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.event_name.Location = new System.Drawing.Point(13, 57);
            this.event_name.Name = "event_name";
            this.event_name.Size = new System.Drawing.Size(293, 85);
            this.event_name.TabIndex = 2;
            this.event_name.Text = "事件名稱";
            // 
            // next_event
            // 
            this.next_event.AutoSize = true;
            this.next_event.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.next_event.Location = new System.Drawing.Point(193, 142);
            this.next_event.Name = "next_event";
            this.next_event.Size = new System.Drawing.Size(74, 21);
            this.next_event.TabIndex = 3;
            this.next_event.Text = "下個事件";
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 50.75F);
            this.time.Location = new System.Drawing.Point(410, 109);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(193, 90);
            this.time.TabIndex = 4;
            this.time.Text = "00:00";
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FullScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ClientSize = new System.Drawing.Size(583, 390);
            this.Controls.Add(this.time);
            this.Controls.Add(this.next_event);
            this.Controls.Add(this.event_name);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FullScreen";
            this.Text = "FullScreen";
            this.Load += new System.EventHandler(this.FullScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label event_name;
        private System.Windows.Forms.Label next_event;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Timer timer1;
    }
}