using System;
using System.Data;
using System.Windows.Forms;
using TableDatabase.Properties;

namespace TableDatabase
{
    public partial class Form1 : Form
    {
        public TableWriter TableWriter { get; set; } = new TableWriter();

        public TableCreator TableCreator { get; set; } = new TableCreator();

        public TableUpdater TableUpdater { get; set; }

        private DataTable dataTable = new DataTable();

        public ChartDrawer chartDrawer { get; set; } = new ChartDrawer();

        public DataGridView Grid
        {
            get => this.dataGridView1;
            set => dataGridView1 = value;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDatabase();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void generateTableButton_Click(object sender, EventArgs e)
        {
            var isParsed = double.TryParse(this.textBox1.Text.ToString(), out var value);

            if (!isParsed || !(value > 0))
            {
                MessageBox.Show("Incorrect value of rows count.", "Incorrect value", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            this.Grid.Rows.Clear();
            for (int i = 0; i < value; ++i)
            {
                this.Grid.Rows.AddRange(new DataGridViewRow());
            }

            for (int i = 0; i < this.Grid.Rows.Count; ++i)
            {
                var row = this.Grid.Rows[i];
                row.Cells[0].Value = i;
            }
        }

        private async void saveToDatabaseButton_Click(object sender, EventArgs e)
        {
            var rewrite =
                MessageBox.Show(
                    "Are you sure? This action will delete current table in DB. If you want to add data to current table without deleting click No",
                    "Possible rewriting of table", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (rewrite == DialogResult.Yes)
            {
                TableCreator.Process();
                TableWriter.Grid = this.Grid;

                var writeTask = TableWriter.ProcessAsync();
                await writeTask;
                if (writeTask.IsCompleted)
                {
                    MessageBox.Show("Saved.", "Writing",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.None);
                }
            }
        }

        private void LoadDatabase()
        {
            var DbReader = new TableReader();
            DbReader.Process();
            var reader = DbReader.DataReader;
            if (reader == null) return;

            while (reader.Read())
            {
                this.Grid.Rows.Add(new object[]
                {
                    reader.GetValue(0), reader.GetValue(1), reader.GetValue(2),
                });
            }

            DbReader.FillDataTableFromGrid(this.Grid, out this.dataTable);
            chartDrawer.Chart = this.chart1;
            chartDrawer.Init(this.Grid, this.dataTable);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chartDrawer.Chart = this.chart1;
        }

        private void exportPlotButton_Click(object sender, EventArgs e)
        {
        }

        private void addRowsToTable_Click(object sender, EventArgs e)
        {
            var addRowsForm = new AddRowsForm(this);
            addRowsForm.ShowDialog();
        }

        private void removeSelectedRowButton_Click(object sender, EventArgs e)
        {
            var dataGridViewRow = this.Grid.CurrentRow;
            if (dataGridViewRow != null)
            {
                var selectedRowDeleter = new TableRowDeleter(dataGridViewRow, this.Grid);
                selectedRowDeleter.Process();
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

        private async void updateDataButton_Click(object sender, EventArgs e)
        {
            TableUpdater = new TableUpdater(this.dataGridView1);
            var updateTask = TableUpdater.ProcessAsync();

            await updateTask;
            if (updateTask.IsCompleted)
            {
                MessageBox.Show("Update is completed", "Update",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.None);
            }
        }
    }
}