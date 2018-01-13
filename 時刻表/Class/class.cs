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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 時刻表
{
    public static class function
    {
        public static Event[] GetAllEvent(DateTime dt,EventInfo[] input)
        {
           
                
                    Event[] event_ = ToEventArray(dt, input);
                    if (event_.Count() > 0)
                    {
                        DateTime nextday = dt.AddDays(1);
                        Event[] NextDatEvent = ToEventArray(nextday, input);
                        while (NextDatEvent.Count() < 0)
                        {
                            nextday = dt.AddDays(1);
                            NextDatEvent = ToEventArray(nextday, input);
                        }
                        event_[event_.Count() - 1].StopTime = NextDatEvent[0].StartTime;
                    }
                    else
                    {
                        return null;
                    }
                    return event_;
                

        }
        private static Event[] ToEventArray(DateTime dt,EventInfo[] input)
        {

            List<Event> list = new List<Event>();
            DateTime time_ = DateTime.ParseExact(dt.ToString("yyyy,MM,dd"), "yyyy,MM,dd", new System.Globalization.CultureInfo("zh-TW"));
            dt.AddDays(0 - ((int)dt.DayOfWeek));
            TimeSpan ts = DateTime.Now - dt;
            int a = (int)Math.Floor((ts.TotalDays) / 7);
            int b = 0;
            Math.DivRem(a, 2, out b);
            bool week_ = (b == 0);
            List<Event> output = new List<Event>();
            int i = 0;

            foreach (EventInfo lvi in input)
            {


                string[] temp = new string[] {lvi.starttime.ToString(),lvi.EventName};
                string time = temp[0];
                DateTime start = DateTime.ParseExact($"{time_.Year},{time_.Month},{time_.Day}::{time}", "yyyy,M,d::HH:mm", new System.Globalization.CultureInfo("zh-TW"));
                time_.AddDays(1);
                //Array.ConvertAll((listView1.Items[i + 1]).SubItems.Cast<ListViewItem.ListViewSubItem>().ToArray(), ca => ca.Text)[0]
                DateTime stop = new DateTime(9999, 12, 31);
                //TEST
                if (i + 1 < input.Count())
                {
                    string[] temp1 = new string[] { input[i + 1].starttime.ToString(), input[i + 1].EventName };
                    string Event_ = temp[1];
                    int[] week1_ = lvi.Repeat_OneWeek;
                    int[] week2_ = lvi.Repeat_Biweekly;
                    int[] bcc = (week_ ? week1_ : week2_);
                    stop = DateTime.ParseExact($"{time_.Year},{time_.Month},{time_.Day}::{input[i + 1].starttime.ToString()}", "yyyy,M,d::HH:mm", new System.Globalization.CultureInfo("zh-TW"));
                }
                string Event = temp[1];
                int[] week1 = lvi.Repeat_OneWeek;
                int[] week2 = lvi.Repeat_Biweekly;
                int[] bc = (week_ ? week1 : week2);
                if (bc.Contains(((int)DateTime.Now.DayOfWeek)))
                {
                    output.Add(new Event(Event, start, stop));
                }
                i++;

            }
            return output.ToArray();

        }
        private static int[] dowToXMLFormat(string[] input)
        {
            int[] output = Array.ConvertAll(input, temp => Array.FindIndex(DayOfWeekChinese, h => h == temp));
            return output;
        }
        private static string[] DayOfWeekChinese = new string[] { "日", "一", "二", "三", "四", "五", "六" };
    }
    public class Event
    {
        private string name = "";
        private DateTime starttime;
        private DateTime stoptime;
        public Event()
        {

        }
        public Event(string name,DateTime starttime,DateTime stoptime)
        {
            Name = name;
            StartTime = starttime;
            StopTime = stoptime;
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }

        }
        public DateTime StartTime
        {
            get
            {
                return starttime;
            }
            set
            {
                starttime = value;
            }

        }
        public DateTime StopTime
        {
            get
            {
                return stoptime;
            }
            set
            {
                stoptime = value;
            }

        }
        
    }
    public class EventInfo
    {
        public EventInfo()
        {

        }
        public string EventName { get; set; }
        public int[] Repeat_OneWeek { get; set; }
        public int[] Repeat_Biweekly { get; set; }
        public Time starttime { get; set; }
        public EventInfo(string EventName,int[] Repeat_OneWeek,int[] Repeat_Biweekly,Time starttime)
        {
            this.EventName = EventName;
            this.Repeat_OneWeek = Repeat_OneWeek;
            this.Repeat_Biweekly = Repeat_Biweekly;
            this.starttime = starttime;
        }
    }
    public class Time
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }
        public Time(string Time)
        {
            string[] split = System.Text.RegularExpressions.Regex.Split(Time, ":");
            Hours = Convert.ToInt32(split[0], 10);
            Minutes = Convert.ToInt32(split[1], 10);
        }
        public Time()
        {

        }
        public new string ToString()
        {
            return $@"{Hours.ToString().PadLeft(2,'0')}:{Minutes.ToString().PadLeft(2, '0')}";
        }
    }
}
