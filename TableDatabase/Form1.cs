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
            var text = this.textBox1.Text.ToString();
            double value;
            var isParsed = Double.TryParse(text, out value);

            if (!isParsed)
            {
                return;
            }

            this.dataGridView1.Rows.AddRange(new DataGridViewRow());
        }
    }
}
