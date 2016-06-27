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
                string netLocation = new WebClient().DownloadString("http://ip-api.com/json"); // First available free API found. Not the most accurate.
                string[] netLocationArray = netLocation.Split(','); // IDK why I am not allowed to do this on one line.
                location.Text = netLocationArray[1].Replace("\"city\":\"", "").TrimEnd('\"'); // Ugly AF, give me just the city.
            }
            catch (Exception)
            {
                location.Text = ""; // More than likely, you aren't connected to the internet.
            }
        }
    }
}
