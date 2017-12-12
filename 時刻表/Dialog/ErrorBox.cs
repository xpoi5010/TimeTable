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
using System.Diagnostics;
namespace 時刻表.Dialog
{
    public partial class ErrorBox : Form
    {
        public ErrorBox(int Errorcode,object source,Exception exception)
        {
            InitializeComponent();
            error_code.Text = $@"錯誤碼:0x{Convert.ToString(Errorcode,16)}";
            errorsource.Text = $@"問題發生原因:{exception.Message}";
        }

        private void ErrorBox_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "http://app.yuanstudio.cc/report";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("本軟體將無法正常運行直到重開以後，請您確認檔案已儲存後重新啟動本程式!","提示",MessageBoxButtons.OK,MessageBoxIcon.Information)== DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
