using System;
using System.Data;
using System.Windows.Forms;
using TableDatabase.Properties;

namespace TableDatabase
{
    public partial class Form1 : Form
    {
        private readonly DBWriter DbWriter = new DBWriter();

        private DataTable dataTable = new DataTable();

        private readonly ChartDrawer chartDrawer = new ChartDrawer();

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
            var dbCreator = new DBCreator();
            dbCreator.Process();
            this.dataGridView1.Rows.Clear();
            var isParsed = double.TryParse(this.textBox1.Text.ToString(), out var value);

            if (!isParsed || !(value > 0)) return;
            for (int i = 0; i < value; ++i)
            {
                this.dataGridView1.Rows.AddRange(new DataGridViewRow());
            }
        }

        private async void saveToDatabaseButton_Click(object sender, EventArgs e)
        {
            DbWriter.Grid = this.dataGridView1;

            await DbWriter.ProcessAsync();
        }

        private void LoadDatabase()
        {
            var DbReader = new DBReader();
            DbReader.Process();
            var reader = DbReader.DataReader;
            if (reader == null) return;

            while (reader.Read())
            {
                this.dataGridView1.Rows.Add(new object[]
                {
                    reader.GetValue(1), reader.GetValue(2),
                });
            }

            DbReader.FillDataTableFromGrid(this.dataGridView1, out this.dataTable);
            chartDrawer.Chart = this.chart1;
            chartDrawer.Init(this.dataGridView1, this.dataTable);
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
            var addRowsForm = new AddRowsForm();
            addRowsForm.Show();
        }
    }
}