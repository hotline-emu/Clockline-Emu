using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void label1_Click(object sender, EventArgs e)
        {
            //TODO, remove this bullshit.
        }

        private void initializeLocation()
        {
            physicalLocation = "Norfolk, VA"; // TODO, actually get the location.
            location.Text = physicalLocation;
        }
    }
}
