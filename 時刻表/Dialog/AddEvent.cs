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

namespace 時刻表.Dialog
{
    public partial class AddEvent : Form
    {
        public AddEvent(mode mode)
        {
            InitializeComponent();
            switch (mode)
            {
                case (mode.Add):
                    this.Text = "新增事件";
                    this.button1.Text = "新增";
                    break;
                case (mode.modify):
                    this.Text = "修改事件";
                    this.button1.Text = "修改";
                    break;
            }
            
        }
        public enum mode
        {
            Add,modify
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if(numericUpDown2.Value >= 60)
            {
                numericUpDown2.Value = 0;
            }
            else if(numericUpDown2.Value <= -1)
            {
                 numericUpDown2.Value = 59;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value >= 24)
            {
                numericUpDown1.Value =0;
            }
            else if (numericUpDown1.Value <= -1)
            {
                numericUpDown1.Value = 23;
            }
        }
        
       
       
        public string Event
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
            }
        }
        public string Week1
        {
            get
            {
                return textBox2.Text;
            }
            set
            {
                textBox2.Text = value;
            }
        }
        public string Week2
        {
            get
            {
                return textBox3.Text;
            }
            set
            {
                textBox3.Text = value;
            }
        }
        public string Time
        {
            get
            {
                return String.Format("{0}:{1}", numericUpDown1.Value.ToString().PadLeft(2, '0'), numericUpDown2.Value.ToString().PadLeft(2, '0'));
            }
            set
            {
                string[] split = System.Text.RegularExpressions.Regex.Split(value, ":");
                int hour = Convert.ToInt32(split[0]);
                int min = Convert.ToInt32(split[1]);
                numericUpDown1.Value = hour;
                numericUpDown2.Value = min;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if((textBox2.Text!=""|| textBox3.Text!="" )&& textBox1.Text !="")
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("該事件不成立。", "事件不成立", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (dayOfWeekSelecter1.Visible)
            {
                dayOfWeekSelecter1.Visible = false;
               Console.DayOfWeekSelecter.Week[] a =  dayOfWeekSelecter1.ReturnResult();
                List<string> temp = new List<string>();
                foreach (Console.DayOfWeekSelecter.Week b in a)
                {
                    switch (b)
                    {
                        case (Console.DayOfWeekSelecter.Week.Mon):
                            temp.Add("一");
                            break;
                        case (Console.DayOfWeekSelecter.Week.Tue):
                            temp.Add("二");
                            break;
                        case (Console.DayOfWeekSelecter.Week.Wed):
                            temp.Add("三");
                            break;
                        case (Console.DayOfWeekSelecter.Week.Thu):
                            temp.Add("四");
                            break;
                        case (Console.DayOfWeekSelecter.Week.Fri):
                            temp.Add("五");
                            break;
                        case (Console.DayOfWeekSelecter.Week.Sat):
                            temp.Add("六");
                            break;
                        case (Console.DayOfWeekSelecter.Week.Sun):
                            temp.Add("日");
                            break;
                    }
                    
                }
                textBox2.Text = String.Join("、", temp.ToArray());
            }
            else
            {
                dayOfWeekSelecter1.Visible = true;
            }
           
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            if (dayOfWeekSelecter2.Visible)
            {
                dayOfWeekSelecter2.Visible = false;
                Console.DayOfWeekSelecter.Week[] a = dayOfWeekSelecter2.ReturnResult();
                List<string> temp = new List<string>();
                foreach (Console.DayOfWeekSelecter.Week b in a)
                {
                    switch (b)
                    {
                        case (Console.DayOfWeekSelecter.Week.Mon):
                            temp.Add("一");
                            break;
                        case (Console.DayOfWeekSelecter.Week.Tue):
                            temp.Add("二");
                            break;
                        case (Console.DayOfWeekSelecter.Week.Wed):
                            temp.Add("三");
                            break;
                        case (Console.DayOfWeekSelecter.Week.Thu):
                            temp.Add("四");
                            break;
                        case (Console.DayOfWeekSelecter.Week.Fri):
                            temp.Add("五");
                            break;
                        case (Console.DayOfWeekSelecter.Week.Sat):
                            temp.Add("六");
                            break;
                        case (Console.DayOfWeekSelecter.Week.Sun):
                            temp.Add("日");
                            break;
                    }

                }
                textBox3.Text = String.Join("、", temp.ToArray());
            }
            else
            {
                dayOfWeekSelecter2.Visible = true;
            }
        }
    }
}
