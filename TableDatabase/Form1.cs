using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void generateTableButton_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();
            double value;
            var isParsed = Double.TryParse(this.textBox1.Text.ToString(), out value);

            if (isParsed && value > 0)
            {
                for (int i = 0; i < value - 1; ++i)
                {
                    this.dataGridView1.Rows.AddRange(new DataGridViewRow() { });
                }
            }
        }
    }
}
