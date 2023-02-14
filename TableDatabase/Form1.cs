using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TableDatabase
{
    public partial class Form1 : Form
    {
        private readonly DBCreator DbCreator = new DBCreator();

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
            if (!DbCreator.isDbExists())
            {
                DbCreator.Process();
            }

            DbWriter.Grid = this.dataGridView1;

            await DbWriter.ProcessAsync();
            //TODO: запретить изменять гридвью, пока в БД вставляются данные
        }

        private void LoadDatabase()
        {
            if (DbCreator.isDbExists())
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chartDrawer.Chart = this.chart1;
        }
    }
}