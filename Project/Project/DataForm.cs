using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class DataForm : Form
    {
        double SumStartupCapital;
        public DataForm()
        {
            InitializeComponent();
        }

        Point lastPoint;
        private void MainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void MainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void Calculate_Click(object sender, EventArgs e)
        {
            this.Hide();
            ResultsForm resultsForm = new ResultsForm();

            resultsForm.Value1 = StartUpCapital.Text;
            resultsForm.Value2 = Income.Text;
            resultsForm.Value3 = Expenses.Text;
            resultsForm.Value4 = IncomeGrowth.Text;
            resultsForm.Value5 = InvestmentRate.Text;
            resultsForm.Value6 = Inflation.Text;


            resultsForm.Show();

        }
    }
}
