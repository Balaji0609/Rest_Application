using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(txtURL.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EncryptionService.ServiceClient Service = new EncryptionService.ServiceClient();
            String str = textBox1.Text;
            String Estr = Service.Encrypt(str);
            String Dstr = Service.Decrypt(Estr);
            label3.Text = "\""+Dstr+"\"";
            textBox4.Text = Estr;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            StockService.ServiceClient Service = new StockService.ServiceClient();
            String str = textBox2.Text;
            String res = Service.getStockquote(str);
            double val = Int32.MinValue;
            try
            {
                val = Convert.ToDouble(res);
            }
            catch(Exception exc)
            {
                textBox3.Text = "Input " + str + " is not valid";
            }
            if(val > 0.0)
            {
                textBox3.Text = res;
            }
            else
            {
                textBox3.Text = "Input " + str + " is not valid";
            }
        }
    }
}
