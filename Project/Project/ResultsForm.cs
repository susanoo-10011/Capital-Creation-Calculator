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
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public string Value3 { get; set; }
        public string Value4 { get; set; }
        public string Value5 { get; set; }
        public string Value6 { get; set; }
        public ResultsForm()
        {
            InitializeComponent();
        }


        private void ResultsForm_Load(object sender, EventArgs e)
        {
            label1.Text = Value1;
            label2.Text = Value2;
            label3.Text = Value3;
            label4.Text = Value4;
            label5.Text = Value5;
            label6.Text = Value6;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
