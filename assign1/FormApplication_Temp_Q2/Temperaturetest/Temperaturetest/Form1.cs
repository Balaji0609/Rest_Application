using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Temperaturetest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double tempF = Convert.ToInt32(textBox1.Text);
                ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
                double tempC = service.FtoC(tempF);
                tempC = Math.Round(tempC, 1);
                textBox3.Text = tempC.ToString() + " Celsius";
            }
            catch (Exception)
            {
                textBox3.Text = "Enter valid value in the box";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double tempC = Convert.ToInt32(textBox2.Text);
                ServiceReference1.Service1Client serv = new ServiceReference1.Service1Client();
                double tempF = serv.CtoF(tempC);
                tempF = Math.Round(tempF, 1);
                textBox3.Text = tempF.ToString() + " Fahrenheit";
            }
            catch (Exception)
            {
                textBox3.Text = "Enter valid value in the box";
            }

        }
    }
}
