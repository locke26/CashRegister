using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;


namespace CashRegister
{

    public partial class Form1 : Form
    {       
        // variables
        double iPhone;
        double iPad;
        double AirPods;
        double subtotal;
        double tax = 0.13;
        double total;
        double tendered;
        double change;
        double iPhonePrice = 400;
        double iPadPrice = 500;
        double AirPodsPrice = 200;
        string date = DateTime.Now.ToString("MMMM dd, yyyy");
        
        // sound players
        SoundPlayer Cashregister = new SoundPlayer(Properties.Resources.cash);
        SoundPlayer Reciept = new SoundPlayer(Properties.Resources.printer);
        SoundPlayer Bell = new SoundPlayer(Properties.Resources.bell);

        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void calculateButton1_Click(object sender, EventArgs e)
        {
            changeButton.Enabled = true;
            Cashregister.Play();
            iPhone = Convert.ToDouble(itemBox1.Text);
            iPhonePrice = iPhone * iPhonePrice;
            iPad = Convert.ToDouble(itemBox2.Text);
            iPadPrice = iPad * iPadPrice;
            AirPods = Convert.ToDouble(itemBox3.Text);
            AirPodsPrice = AirPods * AirPodsPrice;
            subtotal = iPhonePrice + iPadPrice + AirPodsPrice;
            tax = tax * subtotal;
            total = tax + subtotal;

            subtotalLabel.Text = $"Subtotal  {subtotal.ToString("$0.00")}";
            taxLabel.Text = $"Tax       {tax.ToString("$0.00")}";
            totalLabel.Text = $"Total     {total.ToString("$0.00")}";
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            printButton.Enabled = true;
            tendered = Convert.ToDouble(tenderedBox.Text);
            change = tendered - total;

            changeLabel.Text = $"Change    {change.ToString("$0.00")}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reciept.Play();
            neworderButton.Enabled = true;
            receiptLabel.Text = "Apple";
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n\n{date}";
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n\niPhone(s) x{iPhone} @ {iPhonePrice.ToString("$0.00")}";
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n\niPad(s) x{iPad} @ {iPadPrice.ToString("$0.00")}";
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n\nAirPods x{AirPods} @ {AirPodsPrice.ToString("$0.00")}";
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n\nSubtotal {subtotal.ToString("$0.00")}";
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n\nTax {tax.ToString("$0.00")}";
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n\nTotal {total.ToString("$0.00")}";
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += "\n\nThank you!";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Bell.Play();
            changeButton.Enabled = false;
            printButton.Enabled = false;
            neworderButton.Enabled = false;
        }

        private void neworderButton_Click(object sender, EventArgs e)
        {
            changeButton.Enabled = false;
            printButton.Enabled = false;
            neworderButton.Enabled = false;
            iPhone = default(double);
            iPhonePrice = 400;
            iPad = default(double);
            iPadPrice = 500;
            AirPods = default(double);
            AirPodsPrice = 200;
            tax = 0.13;

            itemBox1.Text = "";
            itemBox2.Text = "";
            itemBox3.Text = "";
            subtotalLabel.Text = "Subtotal";
            taxLabel.Text = "Tax";
            totalLabel.Text = "Total";
            tenderedBox.Text = "";
            changeLabel.Text = "";
            receiptLabel.Text = "Welcome!";
        }
    }

}

    
