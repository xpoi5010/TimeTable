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

namespace 時刻表
{
    public partial class DateSelecter : UserControl
    {
        public DateSelecter()
        {
            InitializeComponent();
        }

        private void DateSelecter_Load(object sender, EventArgs e)
        {
            year_.Location = year.Location;
            month_.Location = month.Location;
            day_.Location = day.Location;
            year_.Size = year.Size;
            month_.Size = month.Size;
            day_.Size = day.Size;
        }

        private void year__KeyDown(object sender, KeyEventArgs e)
        {

        }
        public delegate void Down(object sender, DataSelecterEventArgs e);
        public event Down DownButtonClick;
        private void label1_Click(object sender, EventArgs e)
        {
            if(DownButtonClick!=null)
            DownButtonClick(this, new DataSelecterEventArgs(Convert.ToInt32(year.Text), Convert.ToInt32(month.Text), Convert.ToInt32(day.Text)));
        }

        private void year_DoubleClick(object sender, EventArgs e)
        {
            year_.Visible = true;
            year_.Text = year.Text;
        }
        private void month_DoubleClick(object sender, EventArgs e)
        {
            month_.Visible = true;
            month_.Text = month.Text;
        }
        private void day_DoubleClick(object sender, EventArgs e)
        {
            day_.Visible = true;
            day_.Text = day.Text;
        }

        private void year__KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                year_.Visible = false;
                year.Text = year_.Text;
            }
        }

        private void month__KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                month_.Visible = false;
                month.Text = month_.Text;
            }
        }
        public int Year
        {
            get
            {
                return Convert.ToInt32(year.Text);
            }
            set
            {
                year.Text = value.ToString().PadLeft(2,'0');
            }
        }
        public int Month
        {
            get
            {
                return Convert.ToInt32(month.Text);
            }
            set
            {
                month.Text = value.ToString().PadLeft(2, '0');
            }
        }
        public int Day
        {
            get
            {
                return Convert.ToInt32(day.Text);
            }
            set
            {
                day.Text = value.ToString().PadLeft(2, '0');
            }
        }
        private void day__KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                day_.Visible = false;
                day.Text = day_.Text;
            }
            
        }

        private void year_Click(object sender, EventArgs e)
        {
           
            
        }
    }
    public class DataSelecterEventArgs
    {
        private int year;
        private int month;
        private int day;
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }
        public int Month
        {
            get
            {
                return month;
            }
            set
            {
                month = value;
            }
        }
        public int Day
        {
            get
            {
                return day;
            }
            set
            {
                day = value;
            }
        }
        public DataSelecterEventArgs(int Year,int Month,int Day)
        {
            year = Year;
            month = Month;
            day = Day;
        }
    }
   
    
}
