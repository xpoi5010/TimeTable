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
    }
}
