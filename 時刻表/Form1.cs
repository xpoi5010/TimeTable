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
using System.IO;
using System.Xml;
using System.Diagnostics;
namespace 時刻表
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string SavePath = "";
        private delegate Event[] getallevent(DateTime dt);
        public Event[] GetAllEvent(DateTime dt)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    Delegate delegate_ = new getallevent(GetAllEvent);
                    return (Event[])this.Invoke(delegate_, new object[] { dt });
                }
                else
                {
                    Event[] event_ = ToEventArray(dt);
                    if (event_.Count() > 0)
                    {
                        DateTime nextday = dt.AddDays(1);
                        Event[] NextDatEvent = ToEventArray(nextday);
                        while (NextDatEvent.Count() < 0)
                        {
                            nextday = dt.AddDays(1);
                            NextDatEvent = ToEventArray(nextday);
                        }
                        event_[event_.Count() - 1].StopTime = NextDatEvent[0].StartTime;
                    }
                    else
                    {
                        return null;
                    }
                    return event_;
                }
            }   
            catch(Exception ex)
            {
                Dialog.ErrorBox errorBox = new Dialog.ErrorBox(0x0001, this, ex);
                return null;
            }
            
        }
        private Event[] ToEventArray(DateTime dt)
        {
            try
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

                foreach (ListViewItem lvi in listView1.Items)
                {


                    string[] temp = Array.ConvertAll(lvi.SubItems.Cast<ListViewItem.ListViewSubItem>().ToArray(), ca => ca.Text);
                    string time = temp[0];
                    DateTime start = DateTime.ParseExact($"{time_.Year},{time_.Month},{time_.Day}::{time}", "yyyy,M,d::HH:mm", new System.Globalization.CultureInfo("zh-TW"));
                    time_.AddDays(1);
                    //Array.ConvertAll((listView1.Items[i + 1]).SubItems.Cast<ListViewItem.ListViewSubItem>().ToArray(), ca => ca.Text)[0]
                    DateTime stop = new DateTime(9999, 12, 31);
                    //TEST
                    if (i + 1 < listView1.Items.Count)
                    {
                        string[] temp1 = Array.ConvertAll((listView1.Items[i + 1]).SubItems.Cast<ListViewItem.ListViewSubItem>().ToArray(), ca => ca.Text);
                        string Event_ = temp[1];
                        string week1_ = temp[2];
                        string week2_ = temp[3];
                        int[] bcc = dowToXMLFormat(System.Text.RegularExpressions.Regex.Split((week_ ? week1_ : week2_), "、"));
                        stop = DateTime.ParseExact($"{time_.Year},{time_.Month},{time_.Day}::{Array.ConvertAll((listView1.Items[i + 1]).SubItems.Cast<ListViewItem.ListViewSubItem>().ToArray(), ca => ca.Text)[0]}", "yyyy,M,d::HH:mm", new System.Globalization.CultureInfo("zh-TW"));
                    }
                    string Event = temp[1];
                    string week1 = temp[2];
                    string week2 = temp[3];
                    int[] bc = dowToXMLFormat(System.Text.RegularExpressions.Regex.Split((week_ ? week1 : week2), "、"));
                    if (bc.Contains(((int)DateTime.Now.DayOfWeek)))
                    {
                        output.Add(new Event(Event, start, stop));
                    }
                    i++;

                }
                return output.ToArray();
            }
            catch (Exception ex)
            {
                Dialog.ErrorBox errorBox = new Dialog.ErrorBox(0x0002, this, ex);
                return null;
            }
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Dialog.AddEvent ae = new Dialog.AddEvent(Dialog.AddEvent.mode.Add);
                if (ae.ShowDialog() == DialogResult.OK)
                {
                    ListViewItem lvi = new ListViewItem(new string[] { ae.Time, ae.Event, ae.Week1, ae.Week2 });
                    int index = listView1.Items.Count;
                    int i = 0;
                    foreach (ListViewItem lvii in listView1.Items)
                    {
                        DateTime dt = DateTime.ParseExact(lvii.Text, "HH:mm", new System.Globalization.CultureInfo("zh-TW"));
                        DateTime dtt = DateTime.ParseExact(lvi.Text, "HH:mm", new System.Globalization.CultureInfo("zh-TW"));
                        if (dtt < dt)
                        {
                            index = i;
                            break;
                        }
                        else if (dtt == dt)
                        {
                            index = i + 1;
                            break;
                        }
                        i++;
                    }
                    listView1.Items.Insert(index, lvi);
                    Changed = true;
                }
            }
            catch(Exception ex)
            {
                Dialog.ErrorBox errorBox = new Dialog.ErrorBox(0x0003, this, ex);
            }
        }
        bool run = false;
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (!run)
                {
                    if (MessageBox.Show("您確定要進入實行模式嗎?", "詢問", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (listView1.Items.Count> 0)
                        {
                            toolStripButton4.CheckState = (run ? CheckState.Unchecked : CheckState.Checked);
                            toolStripButton3.CheckState = (run ? CheckState.Checked : CheckState.Unchecked);
                            run = !run;
                            Dialog.RunMode rm = new Dialog.RunMode(this);
                            DateTime dt = DateTime.ParseExact($@"{dateSelecter1.Year.ToString().PadLeft(4, '0')},{dateSelecter1.Month.ToString().PadLeft(2, '0')},{dateSelecter1.Day.ToString().PadLeft(2, '0')}", "yyyy,MM,dd", new System.Globalization.CultureInfo("zh-TW"));
                            dt.AddDays(0 - ((int)dt.DayOfWeek));
                            TimeSpan ts = DateTime.Now - dt;
                            int a = (int)Math.Floor((ts.TotalDays) / 7);
                            int b = 0;
                            Math.DivRem(a, 2, out b);
                            bool week_ = (b == 0);
                            rm.Start();
                            if (rm.ShowDialog() == DialogResult.OK)
                            {
                                toolStripButton4.CheckState = (run ? CheckState.Unchecked : CheckState.Checked);
                                toolStripButton3.CheckState = (run ? CheckState.Checked : CheckState.Unchecked);
                                run = !run;
                            }
                        }
                        else
                        {
                            MessageBox.Show("時刻表不得為空!", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Dialog.ErrorBox errorBox = new Dialog.ErrorBox(0x0004, this, ex);
            }
        }

        private void dateSelecter1_DownButtonClick(object sender, DataSelecterEventArgs e)
        {
            monthCalendar1.Visible = !monthCalendar1.Visible;
        }
        private void dateSelecter1_Load(object sender, EventArgs e)
        {
            dateSelecter1.Year = DateTime.Now.Year;
            dateSelecter1.Month = DateTime.Now.Month;
            dateSelecter1.Day = DateTime.Now.Day;
        }
        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            dateSelecter1.Year = e.Start.Year;
            dateSelecter1.Month = e.Start.Month;
            dateSelecter1.Day = e.Start.Day;
            monthCalendar1.Visible = false;
        }
        bool Changed = false;
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems != null)
            {
                ListViewItem lvi = listView1.SelectedItems[0];
                int index = lvi.Index;
                string[] temp = new string[lvi.SubItems.Count];
                temp[0] = lvi.Text;
                Array.ConvertAll(lvi.SubItems.Cast<ListViewItem.ListViewSubItem>().ToArray(), a => a.Text).CopyTo(temp, 0);
                Dialog.AddEvent ae = new Dialog.AddEvent(Dialog.AddEvent.mode.modify);
                ae.Time = temp[0];
                ae.Event = temp[1];
                ae.Week1 = temp[2];
                ae.Week2 = temp[3];
                if (ae.ShowDialog()== DialogResult.OK)
                {
                    listView1.Items.RemoveAt(index);
                    ListViewItem lvii = new ListViewItem(new string[] { ae.Time, ae.Event, ae.Week1, ae.Week2 });
                    int index_ = listView1.Items.Count;
                    int i = 0;
                    foreach (ListViewItem lviii in listView1.Items)
                    {
                        DateTime dt = DateTime.ParseExact(lviii.Text, "HH:mm", new System.Globalization.CultureInfo("zh-TW"));
                        DateTime dtt = DateTime.ParseExact(lvii.Text, "HH:mm", new System.Globalization.CultureInfo("zh-TW"));
                        if (dtt < dt)
                        {
                            index_ = i;
                            break;
                        }
                        else if (dtt == dt)
                        {
                            index_ = i + 1;
                            break;
                        }
                        i++;
                    }
                    listView1.Items.Insert(index_, lvii);
                    Changed = true;
                }
            }
        }
        private void 儲存ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (SavePath != "")
            {
                SaveXML(SavePath);
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "XML文件|*.xml";
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    SavePath = sfd.FileName;
                    SaveXML(SavePath);
                }
            }
            Changed = false;
        }
        private void SaveXML(string path)
        {
            string output = $"<xml version=\"1.0\" encoding=\"UTF-8\">\r\n  <Timetable start=\"{dateSelecter1.Year.ToString().PadLeft(2,'0')},{dateSelecter1.Month.ToString().PadLeft(2, '0')},{dateSelecter1.Day.ToString().PadLeft(2, '0')}\">\r\n";
            string lastTime = "";
            foreach (ListViewItem lvi in listView1.Items)
            {
                string[] temp = Array.ConvertAll(lvi.SubItems.Cast<ListViewItem.ListViewSubItem>().ToArray(),a=>a.Text);
                string Time  = temp[0];
                string Event = temp[1];
                string Week1 = temp[2];
                string Week2 = temp[3];
                if (lastTime == "")
                {
                    output += $"    <Time time=\"{Time}\">\r\n";
                    output += $"      <Event>\r\n        <Name>{Event}</Name>\r\n";
                    if (Week1 != "" && Week1!=Week2)
                    {
                        output += $"        <Repeat week=\"1\">{String.Join(":",dowToXMLFormat(System.Text.RegularExpressions.Regex.Split(Week1,"、")))}</Repeat>\r\n";
                        if (Week2 != "")
                        {
                            output += $"        <Repeat week=\"2\">{String.Join(":", dowToXMLFormat(System.Text.RegularExpressions.Regex.Split(Week2, "、")))}</Repeat>\r\n";
                        }
                    }
                    else if (Week2 != "" && Week1 != Week2)
                    {
                        output += $"        <Repeat week=\"2\">{String.Join(":", dowToXMLFormat(System.Text.RegularExpressions.Regex.Split(Week2, "、")))}</Repeat>\r\n";
                    }
                    else if(Week1 == Week2)
                    {
                        output += $"        <Repeat>{String.Join(":", dowToXMLFormat(System.Text.RegularExpressions.Regex.Split(Week1, "、")))}</Repeat>\r\n";
                    }
                    output += "      </Event>\r\n";
                    lastTime = Time;
                }
                else if(Time != lastTime)
                {
                    output += "    </Time>\r\n";
                    output += $"    <Time time=\"{Time}\">\r\n";
                    output += $"      <Event>\r\n        <Name>{Event}</Name>\r\n";
                    if (Week1 != "" && Week1 != Week2)
                    {
                        output += $"        <Repeat week=\"1\">{String.Join(":", dowToXMLFormat(System.Text.RegularExpressions.Regex.Split(Week1, "、")))}</Repeat>\r\n";
                        if (Week2 != "")
                        {
                            output += $"        <Repeat week=\"2\">{String.Join(":", dowToXMLFormat(System.Text.RegularExpressions.Regex.Split(Week2, "、")))}</Repeat>\r\n";
                        }
                    }
                    else if (Week2 != "" && Week1 != Week2)
                    {
                        output += $"        <Repeat week=\"2\">{String.Join(":", dowToXMLFormat(System.Text.RegularExpressions.Regex.Split(Week2, "、")))}</Repeat>\r\n";
                    }
                    else if (Week1 == Week2)
                    {
                        output += $"        <Repeat>{String.Join(":", dowToXMLFormat(System.Text.RegularExpressions.Regex.Split(Week1, "、")))}</Repeat>\r\n";
                    }
                    output += "      </Event>\r\n";
                    lastTime = Time;
                }
                else if(Time == lastTime)
                {
                    output += $"      <Event>\r\n        <Name>{Event}</Name>\r\n";
                    if (Week1 != "" && Week1 != Week2)
                    {
                        output += $"        <Repeat week=\"1\">{String.Join(":", dowToXMLFormat(System.Text.RegularExpressions.Regex.Split(Week1, "、")))}</Repeat>\r\n";
                        if (Week2 != "")
                        {
                            output += $"        <Repeat week=\"2\">{String.Join(":", dowToXMLFormat(System.Text.RegularExpressions.Regex.Split(Week2, "、")))}</Repeat>\r\n";
                        }
                    }
                    else if (Week2 != "" && Week1 != Week2)
                    {
                        output += $"        <Repeat week=\"2\">{String.Join(":", dowToXMLFormat(System.Text.RegularExpressions.Regex.Split(Week2, "、")))}</Repeat>\r\n";
                    }
                    else if (Week1 == Week2)
                    {
                        output += $"        <Repeat>{String.Join(":", dowToXMLFormat(System.Text.RegularExpressions.Regex.Split(Week1, "、")))}</Repeat>\r\n";
                    }
                    output += "      </Event>\r\n";
                    lastTime = Time;
                }
            }
            output += $@"    </Time>
  </Timetable>
</xml>";
            FileStream fs = new FileStream(path, FileMode.Create);
            byte[] data = Encoding.UTF8.GetBytes(output);
            fs.Write(data, 0, data.Length);
            fs.Close();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
            if (listView1.SelectedItems != null && listView1.Items.Count>0 && listView1.SelectedItems.Count>0)
                
            {
                if(MessageBox.Show("您確定要刪除該事件嗎?", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int index = listView1.SelectedItems[0].Index;
                    listView1.Items.RemoveAt(index);
                    Changed = true;
                }
                
            }
            
        }
        private int[] dowToXMLFormat(string[] input)
        {
            int[] output = Array.ConvertAll(input, temp => Array.FindIndex(DayOfWeekChinese, h => h == temp));
            return output;
        }
        private void 關閉ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private string[] DayOfWeekChinese = new string[] {"日", "一", "二", "三", "四", "五", "六"};
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Changed)
            {
                e.Cancel = true;
                if(MessageBox.Show("您要儲存後再離開嗎?","詢問",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (SavePath != "")
                    {
                        SaveXML(SavePath);
                    }
                    else
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "XML文件|*.xml";
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            SavePath = sfd.FileName;
                            SaveXML(SavePath);
                            Changed = false;
                            e.Cancel = false;
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                    
                }
                else
                {
                    e.Cancel = false;
                }
            }
        }

        private void xMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML文件|*.xml";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                SavePath = sfd.FileName;
                SaveXML(SavePath);
            }
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Changed)
            {
                if (MessageBox.Show("您要保存目前的時刻表嗎?", "詢問", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (SavePath != "")
                    {
                        SaveXML(SavePath);
                    }
                    else
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "XML文件|*.xml";
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            SavePath = sfd.FileName;
                            SaveXML(SavePath);
                        }

                    }
                    Changed = false;
                }
            }
            if (!Changed)
            {
                Clear();
            }
        }
        private void Clear()
        {
            listView1.Items.Clear();
            dateSelecter1.Year = DateTime.Now.Year;
            dateSelecter1.Month = DateTime.Now.Month;
            dateSelecter1.Day = DateTime.Now.Day;
        }
        private void xML格式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Changed)
            {
                if (MessageBox.Show("您要保存目前的時刻表嗎?", "詢問", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (SavePath != "")
                    {
                        SaveXML(SavePath);
                    }
                    else
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "XML文件|*.xml";
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            SavePath = sfd.FileName;
                            SaveXML(SavePath);
                        }

                    }
                    Changed = false;
                }
            }
            if (!Changed)
            {
                Clear();
                OpenFileDialog ofd = new OpenFileDialog() { Filter="XML檔案|*.xml"};
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    System.Xml.XmlDocument xd = new System.Xml.XmlDocument();
                    SavePath = ofd.FileName;
                    xd.Load(SavePath);
                    System.Xml.XmlNodeReader xnr = new System.Xml.XmlNodeReader(xd);
                    string Time = "";
                    string element = "";
                    bool IsEvent = false;
                    string[] temp = new string[4];
                    string start = "";
                    string week = "";
                    while (xnr.Read())
                    {
                        switch (xnr.NodeType)
                        {
                            case (XmlNodeType.Element):
                                element = xnr.Name;
                                switch(element)
                                {
                                   case ("Timetable"):
                                        start = xnr.GetAttribute("start");
                                        string[] split = System.Text.RegularExpressions.Regex.Split(start, ",");
                                        dateSelecter1.Year = Convert.ToInt32(split[0]);
                                        dateSelecter1.Month = Convert.ToInt32(split[1]);
                                        dateSelecter1.Day = Convert.ToInt32(split[2]);
                                        break;

                                   case ("Event"):
                                        IsEvent = true;
                                        week = "";
                                        start = "";
                                        temp = new string[4];
                                        break;
                                    case ("Time"):
                                        Time = xnr.GetAttribute("time");
                                        break;
                                    case ("Repeat"):
                                        week = xnr.GetAttribute("week");

                                        break;
                                }
                                break;
                            case (XmlNodeType.Text):
                                if(IsEvent)
                                {
                                    if (element == "Name")
                                    {
                                        temp[0] = Time;
                                        temp[1] = xnr.Value;
                                    }
                                    else if(element == "Repeat")
                                    {
                                        string[] Split = System.Text.RegularExpressions.Regex.Split(xnr.Value, ":");
                                        int[] w_ = Array.ConvertAll(Split, item => Convert.ToInt32(item));
                                        if (week == "" || week == null)
                                        {
                                            temp[2] = String.Join("、",Array.ConvertAll(w_, item => DayOfWeekChinese[item]));
                                            temp[3] = temp[2];
                                        }
                                        if(week=="1")
                                        {
                                            temp[2] = String.Join("、", Array.ConvertAll(w_, item => DayOfWeekChinese[item]));
                                        }
                                        if (week == "2")
                                        {
                                            temp[3] = String.Join("、", Array.ConvertAll(w_, item => DayOfWeekChinese[item]));
                                        }
                                    }
                                }
                                break;
                            case (XmlNodeType.EndElement):
                                switch (xnr.Name)
                                {
                                    case ("Event"):
                                        IsEvent = false;
                                        ListViewItem lvi = new ListViewItem(temp);
                                        listView1.Items.Add(lvi);
                                        temp = new string[4];
                                        break;
                                }
                                break;
                                
                        }
                    }
                    xnr.Close();
                }
            }

        }

        private void toolStripButton3_Click_1(object sender, EventArgs e)
        {
            if (run)
            {
                if (MessageBox.Show("您確定要進入編輯模式，並離開實行模式嗎?", "詢問", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    toolStripButton4.CheckState = (run ? CheckState.Unchecked : CheckState.Checked);
                    toolStripButton3.CheckState = (run ? CheckState.Checked : CheckState.Unchecked);
                    run = !run;
                }
            }
        }
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            
            
        }

        private void 關於本程式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialog.About about = new Dialog.About();
            about.Show();
        }

        private void 使用手冊ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "http://app.yuanstudio.cc/help";
        }

        private void 回報BugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "http://app.yuanstudio.cc/report";
        }

        private void sourceCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
