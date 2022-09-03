using System;
using System.Windows.Forms;

namespace typewriter
{
    public partial class TypewriterExample : Form
    {

        public TypewriterExample()
        {
            InitializeComponent();
        }

        private void Typewriter(string text, int delay, string controlname)
        {
            // Typewriter function by shdwrv
            // Call example:
            // private void button1_Click(object sender, EventArgs e)
            // {
            //     Typewriter(label1.Text, 100);
            // }

            void Wait(int milliseconds)
            {
                // Wait function
                // Taken from: https://stackoverflow.com/a/52906286

                var timer = new System.Windows.Forms.Timer();

                timer.Interval = milliseconds;
                timer.Enabled = true;
                timer.Start();

                timer.Tick += (s, e) =>
                {
                    timer.Enabled = false;
                    timer.Stop();
                };

                while (timer.Enabled)
                {
                    Application.DoEvents();
                }
            }

            Control ctrl = this.Controls[controlname];
            int length = text.Length;   // Length of text, to measure loops.
            string written = "";        // Already written text.
            string currentletter = "";  // Current letter to append written text with
            int currentlength = 0;      // Current letter index.

            do
            {
                currentletter = text[currentlength].ToString();     // Current letter equals current index, string.
                currentlength = currentlength + 1;                  // Current index increases by one.

                if (currentletter != " ")                           // If current letter is space, do not wait ( optional, i thought it looks better )
                    Wait(delay);                                    // Utilizing previously defined wait, for the next letter.

                written = written + currentletter;                  // Written text appended by current letter.
                //Console.Write(written);                           // (Optional) Logging current text.
                ctrl.Text = written;                                // !!! (Optional) Updating label with each letter, this is probably what you want to do.
            }
            while (length != currentlength);                        // Repeat until length is equal current letter.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Typewriter(textBox2.Text, Convert.ToInt32(textBox1.Text), "label2");
        }
    }
}
