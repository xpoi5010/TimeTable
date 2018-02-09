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
    public partial class RunMode : Form
    {
        EventInfo[] LoadEI;
        DateTime StartDoingTime;
        public RunMode(object sender,EventInfo[] input,DateTime StartTime)
        {
            InitializeComponent();
            this.sender = sender;
            ni.Icon = this.Icon;
            ni.Visible = true;
            ni.DoubleClick += Ni_DoubleClick;
            LoadEI = input;
            StartDoingTime = StartTime;
        }
        bool fullscreenmode = false;
        object sender;
       
        public T Test<T>(T[] a)
        {
            return a[0];
        }
        private void Ni_DoubleClick(object sender, EventArgs e)
        {
            if (Hiddened)
            {
                ((Form)this.sender).Show();
                Hiddened = false;
                //RunMode rm = this;
                //this.DialogResult = rm.ShowDialog();
                this.Show();
            }
        }

        bool Enable = false;
        int index = 0;
        public Event[] events;
        private Task ts;
        public void Start()
        {
            events = function.GetAllEvent(DateTime.Now,LoadEI, StartDoingTime);
            Array.ForEach(events, item => listView1.Items.Add(new ListViewItem(new string[] { $"{item.StartTime.ToString("HH:mm")}~{item.StopTime.ToString("HH:mm")}", item.Name })));
            Enable = true;
            ts = new Task(() => Run());
            ts.Start();
        }
        public void Stop()
        {
            Enable = false;
            ts.GetAwaiter();
        }
        ~RunMode()
        {
            if (Enable)
            {
                Stop();
            }
        }
        bool Next = false;
        NotifyIcon ni = new NotifyIcon();
        FullScreen fullScreen;
        int fullscreen_index=0;
        public void Run()
        {
            
            ni.Icon = this.Icon;
            bool doing = false;
            int Nowindex = 0;
            while (Enable)
            {
                
               for(int i =0;i<events.Count(); i++)
                {
                    Event temp = events[i];
                    Event temp_ = events[Nowindex];
                    if (DateTime.Now >=temp.StartTime && DateTime.Now < temp.StopTime && !doing)
                    {
                        DateTime dtt = temp.StopTime;
                        ChangeBackColorColor(listView1, i, Color.FromArgb(224, 224, 224));
                        ChangeForeColorColor(listView1, i, Color.FromArgb(35, 35, 35));
                        doing = true;
                        if (fullscreenmode)
                        {
                            fullScreen.EventName = events[i].Name;
                            if (i + 1 < events.Count())
                            {
                                fullScreen.NextEventName = events[i + 1].Name;
                            }
                            else
                            {
                                Event[] nextdayevent = function.GetAllEvent(events[events.Count() - 1].StopTime, LoadEI, StartDoingTime);
                                fullScreen.NextEventName = nextdayevent[0].Name;
                            }
                        }
                        Nowindex = i;
                        index = i;
                        temp_ = events[Nowindex];
                        if (i == events.Count() - 1)
                        {
                            NewDay(Nowindex, temp_,events[events.Count()-1].StopTime);
                            Nowindex = 0;
                            doing = false;
                        }
                        break;
                    }
                    else if(!doing)
                    {
                        ChangeBackColorColor(listView1, i, Color.FromArgb(35, 35, 35));
                        ChangeForeColorColor(listView1, i, Color.FromArgb(224, 224, 224));
                    }
                    else if(DateTime.Now >= temp_.StartTime && DateTime.Now > temp_.StopTime && doing)
                    {
                        doing = false;
                        ChangeBackColorColor(listView1, index, Color.FromArgb(35, 35, 35));
                        ChangeForeColorColor(listView1, index, Color.FromArgb(224, 224, 224));
                    }
                }
                    
                   
            }
        }
        private void RunMode_Load(object sender, EventArgs e)
        {

        }
        public delegate void del(int index, Event temp_,DateTime time);
        public delegate void GetAllEvent_(DateTime dt);
        public void NewDay(int index,Event temp_, DateTime time)
        {
            if (this.InvokeRequired)
            {
                del del = new del(NewDay);
                this.Invoke(del, index, temp_, time);
            }
            else
            {
                ListViewItem templvi = listView1.Items[index];
                
                Event[] tempp = function.GetAllEvent(time, LoadEI, StartDoingTime);
                events = new Event[tempp.Count()+1];
                Array.Copy(tempp, 0, events, 1, tempp.Count());
                events[0] = temp_;
                index = 0;
                listView1.Items.Clear();
                Array.ForEach(events, item => listView1.Items.Add(new ListViewItem(new string[] { $"{item.StartTime.ToString("HH:mm")}~{item.StopTime.ToString("HH:mm")}", item.Name })));
            }
        }
        private delegate void ChangeForeColorColor_(ListView control,int index, Color value);
        private void ChangeForeColorColor(ListView control, int index, Color value)
        {
            if (this.InvokeRequired)
            {
                ChangeForeColorColor_ cfcc = new ChangeForeColorColor_(ChangeForeColorColor);
                this.Invoke(cfcc, control, index, value);
            }
            else
            {
                control.Items[index].ForeColor = value;
            }
        }
        private void ChangeBackColorColor(ListView control, int index, Color value)
        {
            if (this.InvokeRequired)
            {
                ChangeForeColorColor_ cfcc = new ChangeForeColorColor_(ChangeBackColorColor);
                this.Invoke(cfcc, control, index,value);
            }
            else
            {
                control.Items[index].BackColor = value;
            }
        }
        private void RunMode_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Hiddened)
            {

                this.DialogResult = DialogResult.OK;
               
                Enable =  (MessageBox.Show("您要離開實行模式並回到編輯模式嗎?", "詢問", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No);
                e.Cancel = Enable;
            }
            
        }
        bool Hiddened = false;
        private void button1_Click(object sender, EventArgs e)
        {
            Hiddened = true;
            ((Form)this.sender).Hide();
            this.Hide();
        }
        private void Hide()
        {
            ni.BalloonTipText = "時刻表已縮小至系統匣裡。";
            ni.Text = "時刻表";
            ni.BalloonTipTitle = "時刻表:實行模式";
            ni.ShowBalloonTip(1000, ni.BalloonTipTitle, ni.BalloonTipText, ToolTipIcon.Info);
            this.Opacity = 0;
            this.Enable = false;
            this.Size = new Size(0, 0);
            this.FormBorderStyle = FormBorderStyle.None;

            //his.WindowState = FormWindowState.Minimized;
            pt = this.Location;
            this.Location = new Point(0, 0);
           
        }
        Point pt=new Point(0,0);
        private void Show()
        {
            
            this.Opacity = 100;
            this.Enable = true;
            this.ClientSize = new System.Drawing.Size(331, 375);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.Location=pt;
            
            //this.WindowState = FormWindowState.Normal;
        }

        private void button2_Click(object sender, EventArgs e)
        {
           fullScreen = new FullScreen(events[index].Name);
            if (index + 1 < events.Count())
            {
                fullScreen.NextEventName = events[index + 1].Name;
            }
            else
            {
                Event[] nextdayevent = function.GetAllEvent(events[events.Count() - 1].StopTime, LoadEI, StartDoingTime);
                fullScreen.NextEventName = nextdayevent[0].Name;
            }
            fullscreenmode = true;
            fullScreen.Show();
        }
    }
}
