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
            double[] values = new double[6];
            bool valid = true;

            // Проверка правильности введения данных
            valid &= Double.TryParse(StartUpCapital.Text, out values[0]);
            valid &= Double.TryParse(Income.Text, out values[1]);
            valid &= Double.TryParse(Expenses.Text, out values[2]);
            valid &= Double.TryParse(IncomeGrowth.Text, out values[3]);
            valid &= Double.TryParse(InvestmentRate.Text, out values[4]);
            valid &= Double.TryParse(Inflation.Text, out values[5]);

            if (!valid)
            {
                MessageBox.Show("Неверный формат данных", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Передача значений в ResultsForm
            this.Hide();
            ResultsForm resultsForm = new ResultsForm();
            resultsForm.Tag = values;
            resultsForm.Show();

        }
    }
}
