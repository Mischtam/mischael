using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ThreadSpy
{
    public partial class ThreadSpyForm : Form
    {
        private Thread drawingThread;

        private char c = (char)('a' - 1);
        private object dr;
        
        public ThreadSpyForm()
        {
            InitializeComponent();
           
        }

        /// <summary>
        /// This method is called when the user clicks the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonStartThread_Click(object sender, EventArgs e)
        {
            c = (char)(c + 1);
           
            drawingThread = new Thread(()=>dr.Run());
            try
            {
                drawingThread.Start();
            }
            catch(Exception)
            {

            }
        }

        /// <summary>
        /// This method is called 10 times per second by the timer 
        /// to show the current status of the thread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (drawingThread != null)
                this.TextBoxStatus.Text = drawingThread.ThreadState.ToString();
        }

    }
    class Drawing
    {
        private TextBox tb;
        private char c;

        public Drawing(TextBox tb, char c)
        {
            this.tb = tb;
            this.c = c;
        }

        /// <summary>
        /// The method to be executed by the new thread
        /// It will print 20 times the character c into TextBox tb
        /// </summary>
        public void Run()
        {
            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(300);
                TextBoxHelper.AddChar(tb, c);
            }
        }
    }
}