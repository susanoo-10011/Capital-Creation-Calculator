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
            investmentRate = values[4] / 100;
            inflation = values[5] / 100;


            monthlyIncomeYear1.Text = Convert.ToString(income);
            MonthlyIncome(income, incomeGrowth);

            expensesYear1.Text = Convert.ToString(expenses);
            Expenses(expenses, inflation);

            deltaYear1.Text = Convert.ToString(income - expenses);
            Delta(expenses, inflation, income, incomeGrowth);

            AccumulatedCapitalYear();

            lastYearCapitalYear1.Text = startUpCapital.ToString();

            percentageOfLastYear1.Text = Convert.ToString(investmentRate *
                    Convert.ToDouble(lastYearCapitalYear1.Text));

            percentageYear1.Text = Convert.ToString(Convert.ToDouble(accumulatedCapitalYear1.Text)
                    * investmentRate / 2);

            double accumulatedCapital = Convert.ToDouble(accumulatedCapitalYear1.Text);
            double lastYearCapital = Convert.ToDouble(lastYearCapitalYear1.Text);
            double percentageOfLast = Convert.ToDouble(percentageOfLastYear1.Text);
            double percentage = Convert.ToDouble(percentageYear1.Text);
            double sum = accumulatedCapital + lastYearCapital + percentageOfLast + percentage;
            currentCapital1.Text = Convert.ToString(sum);

            CurrentCapital();
        }

        public void MonthlyIncome(double income, double incomeGrowth)
        {
            for (int i = 2; i <= 8; i++)
            {
                income += income * (incomeGrowth / 100);
                Label monthlyIncomeYear = Controls.Find("monthlyIncomeYear" + i, true).FirstOrDefault() as Label;
                monthlyIncomeYear.Text = Convert.ToString(income);
                // производим подсчет дохода каждый год. Также в цикле мы меняем переменную на значение i.
            }
        }

        public void Expenses(double expenses, double inflation)
        {
            for (int i = 2; i <= 8; i++)
            {
                expenses *= (1 + inflation);
                Label expensesYear1 = Controls.Find("expensesYear" + i, true).FirstOrDefault() as Label;
                expensesYear1.Text = Convert.ToString(expenses);
            }
        }

        public void Delta(double expenses, double inflation, double income, double incomeGrowth)
        {
            for (int i = 2; i <= 8; i++)
            {
                expenses *= (1 + inflation);
                income += income * (incomeGrowth / 100);

                double delta = income - expenses;
                Label deltaYear = Controls.Find("deltaYear" + i, true).FirstOrDefault() as Label;
                deltaYear.Text = Convert.ToString(delta);
            }
        }

        public void AccumulatedCapitalYear()
        {
            for (int i = 1; i <= 8; i++)
            {
                Label accumulatedCapitalYear = Controls.Find("accumulatedCapitalYear" + i, true).
                        FirstOrDefault() as Label;
                Label deltaYear = Controls.Find("deltaYear" + i, true).
                        FirstOrDefault() as Label;
                accumulatedCapitalYear.Text = Convert.ToString(Convert.ToDouble(deltaYear.Text) * 12);
            }
        }
        public void CurrentCapital()
        {
            Label currentCapital1 = Controls.Find("currentCapital1", true).
                        FirstOrDefault() as Label;
            double[] currentCapitalArray = new double[11]; // создаем массив для двух лет
            currentCapitalArray[0] = Convert.ToDouble(currentCapital1.Text); // сохраняем текущее значение капитала
            for (int i = 2; i <= 8; i++)
            {
                Label lastYearCapitalYear = Controls.Find("lastYearCapitalYear" + i, true).
                        FirstOrDefault() as Label;
                lastYearCapitalYear.Text = Convert.ToString(currentCapitalArray[0]);
                // присваивает значение капитала с первого года

                Label percentageOfLastYear = Controls.Find("percentageOfLastYear" + i, true).
                        FirstOrDefault() as Label;
                percentageOfLastYear.Text = Convert.ToString(investmentRate * 
                    Convert.ToDouble(lastYearCapitalYear.Text));

                Label percentageYear = Controls.Find("percentageYear" + i, true).
                        FirstOrDefault() as Label;
                Label accumulatedCapitalYear = Controls.Find("accumulatedCapitalYear" + i, true).
                        FirstOrDefault() as Label;
                percentageYear.Text = Convert.ToString(Convert.ToDouble(accumulatedCapitalYear.Text)
                    * investmentRate / 2);

                Label currentCapital = Controls.Find("currentCapital" + i, true).
                        FirstOrDefault() as Label;
                double accumulatedCapital = Convert.ToDouble(accumulatedCapitalYear.Text);
                double lastYearCapital = Convert.ToDouble(lastYearCapitalYear.Text);
                double percentageOfLast = Convert.ToDouble(percentageOfLastYear.Text);
                double percentage = Convert.ToDouble(percentageYear.Text);
                double sum = accumulatedCapital + lastYearCapital + percentageOfLast + percentage;
                currentCapital.Text = Convert.ToString(sum);

                currentCapitalArray[0] = Convert.ToDouble(currentCapital.Text);
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
