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
    public partial class ResultsForm : Form
    {
        double startUpCapital, income, expenses, incomeGrowth, investmentRate, inflation;


        public ResultsForm()
        {
            InitializeComponent();
        }

        private void ResultsForm_Load(object sender, EventArgs e)
        {
            double[] values = (double[])Tag;

            startUpCapital = values[0];
            income = values[1];
            expenses = values[2];
            incomeGrowth = values[3];
            investmentRate = values[4];
            inflation = values[5];
        }


        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
