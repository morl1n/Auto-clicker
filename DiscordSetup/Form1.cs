using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DiscordSetup
{

    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        [DllImport("user32", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Auto)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr intptr_0, out int int_0);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowTextLength(IntPtr intptr_0);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowText(IntPtr intptr_0, StringBuilder stringBuilder_0, int int_0);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private string method_0()
        {
            string result = string.Empty;
            IntPtr foregroundWindow = Form1.GetForegroundWindow();
            int num = Form1.GetWindowTextLength(foregroundWindow) + 1;
            StringBuilder stringBuilder = new StringBuilder(num);
            if (Form1.GetWindowText(foregroundWindow, stringBuilder, num) > 0)
            {
                result = stringBuilder.ToString();
            }
            return result;
        }

        private void siticoneTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label1.Text = siticoneTrackBar1.Value.ToString();
        }

        private void siticoneTrackBar2_Scroll(object sender, ScrollEventArgs e)
        {
            label2.Text = siticoneTrackBar2.Value.ToString();
        }

        private void AC_Tick(object sender, EventArgs e)
        {
            if ((this.method_0().Contains("Minecraft") || this.method_0().Contains("Badlion") || this.method_0().Contains("Lunar Client") || this.method_0().Contains("Labymod") || this.method_0().Contains("OCMC") || this.method_0().Contains("Cheatbreaker") || this.method_0().Contains("J3Ultimate")))
            {
                bool flag = Control.MouseButtons == MouseButtons.Left;
                int interval = 1000 / this.siticoneTrackBar1.Value - 2;
                if (flag)
                {
                    IntPtr foregroundWindow = Form1.GetForegroundWindow();
                    Form1.PostMessage(foregroundWindow, 513u, 0, 0);
                    Form1.PostMessage(foregroundWindow, 514u, 0, 0);
                    this.AC.Interval = interval;
                }
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            bool flag = this.siticoneButton1.Text == "OFF";
            if (flag)
            {
                this.siticoneButton1.Text = "ON";
                this.siticoneButton1.BackColor = Color.FromArgb(50, 2, 70);
                AC.Start();
            }
            else
            {
                this.siticoneButton1.Text = "OFF";
                this.siticoneButton1.BackColor = Color.FromArgb(15, 15, 15);
                AC.Stop();
            }
        }
    }
}
