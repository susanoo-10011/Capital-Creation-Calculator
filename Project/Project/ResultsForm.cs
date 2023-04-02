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

            deltaYear1.Text = Convert.ToString(income - expenses);
            Delta(expenses, inflation, income, incomeGrowth);

            accumulatedCapitalYear1.Text = Convert.ToString((income - expenses) * 12);
            AccumulatedCapitalYear(expenses, inflation, income, incomeGrowth);

            LastYearCapital();

            PercentageOfLastYear(startUpCapital);

            PercentageYear();

            CurrentCapital1();
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
            for (int i = 2; i <= 3; i++)
            {
                expenses *= (1 + inflation / 100);
                Label expensesYear1 = Controls.Find("expensesYear" + i, true).FirstOrDefault() as Label;
                expensesYear1.Text = Convert.ToString(expenses);
            }
        }

        public void Delta(double expenses, double inflation, double income, double incomeGrowth)
        {
            for (int i = 2; i <= 3; i++)
            {
                expenses *= (1 + inflation / 100);
                income += income * (incomeGrowth / 100);

                double delta = income - expenses;
                Label deltaYear = Controls.Find("deltaYear" + i, true).FirstOrDefault() as Label;
                deltaYear.Text = Convert.ToString(delta);
            }
        }

        public void AccumulatedCapitalYear(double expenses, double inflation, double income, double incomeGrowth)
        {
            for (int i = 2; i <= 3; i++)
            {
                expenses *= (1 + inflation / 100);
                income += income * (incomeGrowth / 100);

                double delta = (income - expenses) * 12;
                Label accumulatedCapitalYear = Controls.Find("accumulatedCapitalYear"
                    + i, true).FirstOrDefault() as Label;
                accumulatedCapitalYear.Text = Convert.ToString(delta);
            }
        }

        
        public void PercentageOfLastYear(double startUpCapital)
        {
            percentageOfLastYear1.Text = Convert.ToString(startUpCapital * investmentRate / 100);


        }

        public void PercentageYear()
        {
            for (int i = 1; i <= 3; i++)
            {
                Label accumulatedCapitalYear = Controls.Find("accumulatedCapitalYear"
                + i, true).FirstOrDefault() as Label;
                Label percentageYear = Controls.Find("percentageYear"
                    + i, true).FirstOrDefault() as Label;
                double accumulatedCapital = double.Parse(accumulatedCapitalYear.Text);
                double result = accumulatedCapital * investmentRate / 100 / 2;
                percentageYear.Text = Convert.ToString(result);
            }
        }

        public void LastYearCapital()
        {
            lastYearCapitalYear1.Text = Convert.ToString(startUpCapital);

            for (int i = 2; i <= 3; i++)
            {
                Label currentCapital = Controls.Find("currentCapital" + i, true).
                    FirstOrDefault() as Label;
                Label lastYearCapitalYear = Controls.Find("lastYearCapitalYear" + i, true).
                    FirstOrDefault() as Label;
                lastYearCapitalYear.Text = Convert.ToString(currentCapital);

            }
        }

        double LastCapital;
        public void CurrentCapital1()
        {
            for (int i = 1; i <= 3; i++)
            {
                Label accumulatedCapitalYear = Controls.Find("accumulatedCapitalYear" + i, true).
                    FirstOrDefault() as Label;
                double accumulatedCapital = double.Parse(accumulatedCapitalYear.Text);

                Label lastYearCapitalYear = Controls.Find("lastYearCapitalYear" + i, true).
                    FirstOrDefault() as Label;
                lastYearCapitalYear.Text = Convert.ToString(LastCapital);


                Label percentageOfLastYear = Controls.Find("percentageOfLastYear" + i, true).
                    FirstOrDefault() as Label;
                double percentageLastYear = double.Parse(percentageOfLastYear.Text);

                Label percentageYear = Controls.Find("percentageYear" + i, true).
                    FirstOrDefault() as Label;
                double percentageCurrentYear = double.Parse(percentageYear.Text);

                double capital = accumulatedCapital + LastCapital + percentageLastYear + percentageCurrentYear;
                Label currentCapital = Controls.Find("currentCapital" + i, true).
                    FirstOrDefault() as Label;

                LastCapital = Convert.ToDouble(capital);
                currentCapital.Text = Convert.ToString(capital);
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
