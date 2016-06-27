using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace ClockLine_Emu
{
    public partial class Form1 : Form
    {
        public static string physicalLocation;

        public Form1()
        {
            InitializeComponent();
            initializeLocation(); // Set the location on the clock.
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Update the timer on each tick.
        /// Currently set to only report Hours:Minutes, but easily configurable to whatever.
        /// View MSDN documentation if you want to modify this yourself.
        /// 
        /// The currently used API key is free, and keyless.  As this is stored publically, it was a design decision to not
        /// leave a key issued by someone else, leading to their API, open for everyone to see.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("hh:mm tt");
        }

        /// <summary>
        /// When starting the program, get the city based off of your IP.
        /// </summary>
        private void initializeLocation()
        {
            try
            {
                string[] netLocation = new WebClient().DownloadString("http://ip-api.com/json").Split(','); // First available free API found. Not the most accurate.                
                location.Text = netLocation[1].Replace("\"city\":\"", "").TrimEnd('\"'); // All I care about is the city.
            }
            catch (Exception)
            {
                location.Text = ""; // More than likely, you aren't connected to the internet.
            }
        }
    }
}
