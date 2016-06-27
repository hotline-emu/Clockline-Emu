using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Device.Location;

namespace ClockLine_Emu
{
    public partial class Form1 : Form
    {
        public static string physicalLocation;

        public Form1()
        {
            InitializeComponent();
            initializeLocation();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("hh:mm tt");
        }

        private void initializeLocation()
        {
            GeoCoordinateWatcher myLocation = new GeoCoordinateWatcher(GeoPositionAccuracy.High);            
            myLocation.TryStart(false, TimeSpan.FromMilliseconds(1000));

            physicalLocation = "Norfolk, VA"; // TODO, actually get the location.

            var latitude = myLocation.Position.Location.Latitude;
            var longitude = myLocation.Position.Location.Longitude;
            
            location.Text = String.Format("{0}, {1}", latitude, longitude);

            
        }
    }
}
