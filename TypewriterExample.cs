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

        private void Typewriter(string text, int delay)
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
            int length = text.Length;   // Length of text, to measure loops.
            string written = "";        // Already written text.
            string currentletter = "";  // Current letter to append written text with
            int currentlength = 0;      // Current letter index.

            do
            {
                currentletter = text[currentlength].ToString();     // Current letter equals current index, string.
                if (currentletter != " ")                           // If current letter is space, do not wait ( optional, i thought it looks better )
                    Wait(delay);                                    // Utilizing previously defined wait, for the next letter.
                written = written + currentletter;                  // Written text appended by current letter.

                currentlength = currentlength + 1;                  // Current index increases by one.
                Console.Write(written);                             // Logging current text.
                // If you want the typewriter to target an element, like a label, replace line above with:
                label1.Text = written;
            }
            while (length != currentlength);                        // Repeat until length is equal current letter.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Typewriter(textBox2.Text, Convert.ToInt32(textBox1.Text));
        }
    }
}
