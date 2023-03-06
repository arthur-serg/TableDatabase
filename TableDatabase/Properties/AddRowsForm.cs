using System;
using System.Windows.Forms;

namespace TableDatabase.Properties
{
    public partial class AddRowsForm : Form
    {
        public Form1 MainForm { get; set; }

        public AddRowsForm()
        {
            InitializeComponent();
        }

        public AddRowsForm(Form1 form1)
        {
            MainForm = form1;
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

            for (int i = 0; i < this.dataGridView1.Rows.Count; ++i)
            {
                var row = this.dataGridView1.Rows[i];
                row.Cells[0].Value = i + (int)MainForm.Grid.Rows[MainForm.Grid.Rows.Count - 1].Cells[0].Value + 1;
            }
        }

        private async void addDataToTableButton_Click(object sender, EventArgs e)
        {
            var dbWriter = new DBWriter
            {
                Grid = this.dataGridView1
            };

            await dbWriter.ProcessAsync();

            addRowsToGrid(MainForm.Grid, this.dataGridView1);
            this.Close();
        }

        private void addRowsToGrid(DataGridView mainGrid, DataGridView sideGrid)
        {
            for (int i = 0; i < sideGrid.Rows.Count; ++i)
            {
                var row = (DataGridViewRow)sideGrid.Rows[i].Clone();
                for (int j = 0; j < row.Cells.Count; ++j)
                {
                    row.Cells[j].Value = sideGrid.Rows[i].Cells[j].Value;
                }

                mainGrid.Rows.Add(row);
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (double.TryParse(e.FormattedValue.ToString(), out _) ||
                e.FormattedValue.ToString() == string.Empty) return;
            MessageBox.Show("Cell can contain only numerical value. Check your data.", "Incorrect value",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            e.Cancel = true;
        }
    }
}