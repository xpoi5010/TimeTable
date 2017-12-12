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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 時刻表.Dialog.Console
{
    public partial class DayOfWeekSelecter : UserControl
    {
        public DayOfWeekSelecter()
        {
            InitializeComponent();
            radioButton2_Click(everyday, new EventArgs());
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public Week[] ReturnResult()
        {
            List<Week> temp = new List<Week>();
            foreach(Control lb in week.Controls)
            {
                if (lb.BackColor == Color.White)
                {
                    switch (lb.Name)
                    {
                        case ("Sun"):
                            temp.Add(Week.Sun);
                            break;
                        case ("Mon"):
                            temp.Add(Week.Mon);
                            break;
                        case ("Tue"):
                            temp.Add(Week.Tue);
                            break;
                        case ("Wed"):
                            temp.Add(Week.Wed);
                            break;
                        case ("Thu"):
                            temp.Add(Week.Thu);
                            break;
                        case ("Fri"):
                            temp.Add(Week.Fri);
                            break;
                        case ("Sat"):
                            temp.Add(Week.Sat);
                            break;
                    }
                }
                
            }
            return temp.ToArray();
        }
        public enum Week
        {
            Sun,Mon,Tue,Wed,Thu,Fri,Sat
        }
        private void Weekly_Click(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            if(lb.BackColor == Color.White)
            {
                Color cl = Color.FromArgb(45, 45, 45);
                lb.BackColor = cl;
                cl = Color.FromArgb(224, 224,224);
                lb.ForeColor = cl;
            }
            else
            {
                lb.BackColor = Color.White;
                lb.ForeColor = Color.Black;
            }
            weekly.Checked = true;
            
        }
        private void Clickbox(RadioButton rb)
        {
            foreach(Control ct in click.Controls)
            {
                RadioButton rbb = (RadioButton)ct;
                
                    rbb.Checked = false;
            }
            
        }
        private void radioButton2_Click(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            Clickbox(rb);
            rb.Checked = true;
            switch (rb.Name)
            {
                case ("everyday"):
                    foreach(Control ct in week.Controls)
                    {
                        ct.BackColor = Color.White;
                        ct.ForeColor = Color.Black;
                    }
                    break;
                case ("weekdays"):
                    Mon.BackColor = Color.White;
                    Mon.ForeColor = Color.Black;
                    Thu.BackColor = Color.White;
                    Thu.ForeColor = Color.Black;
                    Wed.BackColor = Color.White;
                    Wed.ForeColor = Color.Black;
                    Tue.ForeColor = Color.Black;
                    Tue.BackColor = Color.White;
                    Fri.BackColor = Color.White;
                    Fri.ForeColor = Color.Black;
                    Sat.BackColor = Color.FromArgb(45, 45, 45);
                    Sat.ForeColor = Color.FromArgb(224, 224, 224);
                    Sun.BackColor = Color.FromArgb(45, 45, 45);
                    Sun.ForeColor = Color.FromArgb(224, 224, 224); ;

                    break;
                case ("weekends"):
                    Mon.BackColor = Color.FromArgb(45, 45, 45);
                    Mon.ForeColor = Color.FromArgb(224, 224, 224);
                    Thu.BackColor = Color.FromArgb(45, 45, 45);
                    Thu.ForeColor = Color.FromArgb(224, 224, 224);
                    Wed.BackColor = Color.FromArgb(45, 45, 45);
                    Wed.ForeColor = Color.FromArgb(224, 224, 224);
                    Tue.ForeColor = Color.FromArgb(224, 224, 224);
                    Tue.BackColor = Color.FromArgb(45, 45, 45);
                    Fri.BackColor = Color.FromArgb(45, 45, 45);
                    Fri.ForeColor = Color.FromArgb(224, 224, 224);
                    Sat.BackColor = Color.White;
                    Sat.ForeColor = Color.Black;
                    Sun.BackColor = Color.White;
                    Sun.ForeColor = Color.Black;
                    break;
            }
            //weekdays 1~5
            //everyday 1~7
            //weekends 6~7
            
        }
    }
}
