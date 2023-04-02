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

        Point lastPoint;

        private void ResultsForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            // Получаем текущее значение ползунка
            int value = ((ScrollBar)sender).Value;
            // Изменяем положение видимой части содержимого формы
            this.VerticalScroll.Value = value;
        }
        private void ResultsForm_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
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


            monthlyIncomeYear1.Text = Convert.ToString(income);
            MonthlyIncome(income, incomeGrowth);

            expensesYear1.Text = Convert.ToString(expenses);
            Expenses(expenses, inflation);
        }

        public void MonthlyIncome(double income, double incomeGrowth)
        {
            for (int i = 2; i <= 3; i++)
            {
                income += income * (incomeGrowth / 100);
                Label monthlyIncomeYear = Controls.Find("monthlyIncomeYear" + i, true).FirstOrDefault() as Label;
                monthlyIncomeYear.Text = Convert.ToString(income);
                // производим подсчет дохода каждый год. Также в цикле мы меняем переменную на значение i.
            }
        }

        public void Expenses(double expenses, double inflation)
        {
            for (int i = 2;i <= 3; i++)
            {
                expenses *= (1+ inflation / 100);
                Label expensesYear1 = Controls.Find("expensesYear" + i, true).FirstOrDefault() as Label;
                expensesYear1.Text = Convert.ToString(expenses);
            }
        }

        public ResultsForm()
        {
            InitializeComponent();
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
