using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableDatabase.Properties
{
    public partial class AddRowsForm : Form
    {
        public Form1 mainForm { get; set; }

        public AddRowsForm()
        {
            InitializeComponent();
        }

        public AddRowsForm(Form1 form1)
        {
            mainForm = form1;
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var isParsed = double.TryParse(this.textBox1.Text.ToString(), out var value);

            if (!isParsed || !(value > 0))
            {
                MessageBox.Show("Incorrect value of rows count.", "Incorrect value", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            this.dataGridView1.Rows.Clear();
            for (int i = 0; i < value; ++i)
            {
                this.dataGridView1.Rows.AddRange(new DataGridViewRow());
            }
        }

        private async void addDataToTableButton_Click(object sender, EventArgs e)
        {
            var dbWriter = new DBWriter
            {
                Grid = this.dataGridView1
            };

            await dbWriter.ProcessAsync();
            addRowsToGrid(dbWriter.Grid, this.dataGridView1);
            this.Close();
        }

        private void addRowsToGrid(DataGridView dgv1, DataGridView dgv2)
        {
            //TODO: stackoverflow ??? debug this shit.

            for (int i = 0; i < dgv2.Rows.Count; ++i)
            {
                var row = (DataGridViewRow)dgv2.Rows[i].Clone();
                row.Cells[0].Value = dgv2.Rows[i].Cells[0].Value;
                row.Cells[1].Value = dgv2.Rows[i].Cells[1].Value;
                dgv1.Rows.Add(row);
            }
        }
    }
}