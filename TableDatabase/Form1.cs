﻿using System;
using System.Data;
using System.Windows.Forms;
using TableDatabase.Properties;

namespace TableDatabase
{
    public partial class Form1 : Form
    {
        public DBWriter DbWriter { get; set; } = new DBWriter();

        public DBCreator DbCreator { get; set; } = new DBCreator();

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
                DbCreator.Process();
                DbWriter.Grid = this.Grid;

                await DbWriter.ProcessAsync();
            }
        }

        private void LoadDatabase()
        {
            var DbReader = new DBReader();
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
            var selectedRowId = this.Grid.CurrentRow.Cells["id"].Value;
            var selectedRowDeleter = new DBRowByIDDeleter((int)selectedRowId);

            selectedRowDeleter.Process();
        }
    }
}