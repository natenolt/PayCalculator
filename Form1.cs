using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace PayCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static decimal computePay(decimal hour, decimal rate)
        {
            if (hour > 40)
            {
                decimal OThour = hour - 40;
                decimal OTsum = OThour * ((decimal)1.5 * rate);
                hour = hour - OThour;
                decimal sum = hour * rate;
                sum = OTsum + sum;
                return sum;
            }
            else
            {
                decimal sum = hour * rate;
                return sum;
            }
        } // end of computePay

        private void ComputePayBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //string name = nameTxtBox.Text;
                //int employeeID = Convert.ToInt32(empIDTxtBox.Text);
                decimal hour = Convert.ToDecimal(hourTxtBox.Text);
                decimal rate = Convert.ToDecimal(rateTxtBox.Text);
                decimal sum = computePay(hour, rate);
                MessageBox.Show(Convert.ToString(sum));
            }
            catch (Exception wrongInput)
            {
                MessageBox.Show("Please check input and try again.");
            }
        }


        private void SaveBtn_Click(object sender, EventArgs e)
        {
            //TextWriter txt = new StreamWriter("C:\\demo\\demo.txt");
            //C:\Users\new user\Desktop\c#projects\PayCalculator
            TextWriter txt = new StreamWriter("C:\\Users\\new user\\Desktop\\c#projects\\PayCalculator\\test.txt", true);
            //TextWriter txt = new StreamWriter("C:\\PayCalculator\\test.txt");
            txt.Write(nameTxtBox.Text + "\t");
            txt.Write(empIDTxtBox.Text + "\t");
            txt.Write(hourTxtBox.Text + "\t");
            txt.Write(rateTxtBox.Text + "\t");
            decimal hour = Convert.ToDecimal(hourTxtBox.Text); //Clean this up - shorten, make more elegant 
            decimal rate = Convert.ToDecimal(rateTxtBox.Text); //
            decimal sum = computePay(hour, rate);
            txt.Write(sum);
            txt.Write("\n");
            txt.Close();
            nameTxtBox.Clear();
            empIDTxtBox.Clear();
            hourTxtBox.Clear();
            rateTxtBox.Clear();


        }


        //Menu Options
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nameTxtBox.Clear();
            empIDTxtBox.Clear();
            hourTxtBox.Clear();
            rateTxtBox.Clear();
        }

        private void AboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Calculates paycheck and stores to database.\nAuthor: Nate Nolting");
                
        }

        
    }
}
