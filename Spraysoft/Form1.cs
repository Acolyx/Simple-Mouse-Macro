using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace Spraysoft
{
  
    public partial class Form1 : Form
    {
        int delay = Properties.Settings.Default.delay;
        int mpospx = 0;
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);
        int multiplier = Properties.Settings.Default.mutliplier;
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);
        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, int dx, int dy, uint dwData,
   int dwExtraInfo);
        public Form1()
        {
            InitializeComponent();
        }

        void lclick(int multiplier,int delay)
        {
            for (int i = 0; i < multiplier; i++)
            {
                mouse_event(0x02, 0, 0, 0, 0);
                mouse_event(0x04, 0, 0, 0, 0);
            }
           


        }
        void rclick(int multiplier, int delay)
        {
            for (int i = 0; i < multiplier; i++)
            {
                mouse_event(0x08, 0, 0, 0, 0);
                mouse_event(0x10, 0, 0, 0, 0);
            }
           


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = delay.ToString();
            textBox2.Text = multiplier.ToString();
        }
        void cursorp(int mpospx)
        {

            SetCursorPos(Cursor.Position.X, Cursor.Position.Y + mpospx);



        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (GetAsyncKeyState(Keys.XButton2) == -32768) 
            {
                lclick(multiplier, 1);
                Thread.Sleep(delay);
                cursorp(mpospx);
                
            }
            if (GetAsyncKeyState(Keys.XButton1) == -32768)
            {
                rclick(multiplier, 1);
                Thread.Sleep(delay);
                cursorp(mpospx);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                delay = int.Parse(textBox1.Text);
                Properties.Settings.Default.delay = delay;
                Properties.Settings.Default.Save();
            }
            catch (Exception)
            {

             
            }
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                
                multiplier = int.Parse(textBox2.Text);
                Properties.Settings.Default.mutliplier = multiplier;
                Properties.Settings.Default.Save();

            }
            catch (Exception)
            {

              
            }

        }
       
        private void textBox3_TextChanged(object sender , EventArgs e)
        {
            try
            {
                mpospx = Convert.ToInt32(textBox3.Text);
            }
            catch (Exception)
            {

                
            }

        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (GetAsyncKeyState(Keys.F7) == -32768)
            {

                timer1.Enabled = false;
                Thread.Sleep(3000);

            }
            if (GetAsyncKeyState(Keys.F8) == -32768)
            {


                timer1.Enabled = true;
                Thread.Sleep(3000);


            }
        }
    }
}
