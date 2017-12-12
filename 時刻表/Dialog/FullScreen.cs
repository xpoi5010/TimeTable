/*
 *  This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace 時刻表.Dialog
{
    public partial class FullScreen : Form
    {
        public FullScreen(string EventName)
        {
            InitializeComponent();
            this.Size = Screen.PrimaryScreen.Bounds.Size;
            this.Location = new Point(0, 0);
            event_name.Location = new Point((int)(this.Width * 0.3), (int)(this.Height * 0.3));
            next_event.Location = new Point((int)(this.Width * 0.3)+((int)(event_name.Size.Width*0.5)), (int)(this.Height * 0.3)+ ((int)(event_name.Size.Height)));
            this.TopMost = true;
            time.Location = new Point(this.Width - time.Size.Width - 6, 7);
            this.EventName = EventName;
            timer1.Start();
        }
        private string eventname = "";
        private string nexteventname = "";
        private delegate void ChangeTime();
        private void UpdataTime()
        {
            try
            {
                if (InvokeRequired)
                {
                    Delegate delegate_ = new ChangeTime(UpdataTime);
                    Invoke(delegate_, new object[] { });
                    Thread.Sleep(300);
                }
                else
                {
                    time.Text = DateTime.Now.ToString("hh:mm");
                    
                }
            }
            catch(Exception ex)
            {
                Dialog.ErrorBox errorBox = new ErrorBox(0x0302, this, ex);
                errorBox.Show();
            }
        }
        private delegate void changeControlText(Control control, string Text);
        private void ChangeControlText(Control control, string Text)
        {
            if (this.InvokeRequired)
            {
                Delegate delegate_ = new changeControlText(ChangeControlText);
                this.Invoke(delegate_, new object[] { control, Text });
            }
            else
            {
                control.Text = Text;
                event_name.Location = new Point((int)(this.Width * 0.3), (int)(this.Height * 0.3));
                next_event.Location = new Point((int)(this.Width * 0.3) + ((int)(event_name.Size.Width * 0.5)), (int)(this.Height * 0.3) + ((int)(event_name.Size.Height)));
            }
        }
        public string EventName
        {
            get
            {
                return eventname;
            }
            set
            {
                eventname = value;
                ChangeControlText(event_name,value);

            }
        }
        public string NextEventName
        {
            get
            {
                return nexteventname;
            }
            set
            {
                nexteventname = value;
                ChangeControlText(next_event,$@"下一個事件:{value}");
            }
        }
        private void FullScreen_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdataTime();
        }
    }
}
