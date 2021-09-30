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
        double mask;
        double sanitizer;
        double gloves;
        double subtotal;
        double tax = 0.13;
        double total;
        double tendered;
        double change;
        double maskprice = 4.50;
        double sanitizerprice = 7.50;
        double glovesprice = 3.25;
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
            mask = Convert.ToDouble(itemBox1.Text);
            maskprice = mask * maskprice;
            sanitizer = Convert.ToDouble(itemBox2.Text);
            sanitizerprice = sanitizer * sanitizerprice;
            gloves = Convert.ToDouble(itemBox3.Text);
            glovesprice = gloves * glovesprice;
            subtotal = maskprice + sanitizerprice + glovesprice;
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
            receiptLabel.Text = "The COVID Shop";
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n\n{date}";
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n\nMasks x{mask} @ {maskprice.ToString("$0.00")}";
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n\nSanitizer x{sanitizer} @ {sanitizerprice.ToString("$0.00")}";
            Refresh();
            Thread.Sleep(500);
            receiptLabel.Text += $"\n\nGloves x{gloves} @ {glovesprice.ToString("$0.00")}";
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
            receiptLabel.Text += "\n\nHave a great day! :)";

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
            mask = default(double);
            maskprice = 4.50;
            sanitizer = default(double);
            sanitizerprice = 7.50;
            gloves = default(double);
            glovesprice = 3.25;
            tax = 0.13;

            itemBox1.Text = "";
            itemBox2.Text = "";
            itemBox3.Text = "";
            subtotalLabel.Text = "Subtotal";
            taxLabel.Text = "Tax";
            totalLabel.Text = "Total";
            tenderedBox.Text = "";
            changeLabel.Text = "";
            receiptLabel.Text = "Anything else?";
        }
    }

}

    
