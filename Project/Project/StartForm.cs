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
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        Point lastPoint;
        private void MainPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button  == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void MainPanel_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint  = new Point(e.X, e.Y);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            // this.Close(); //this обращается к текущему окну
            Application.Exit();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            this.Hide(); //прячем это окно при нажатии кнопки
            DataForm dataForm = new DataForm();
            dataForm.Show(); //отображает окно.
        }
    }
}
