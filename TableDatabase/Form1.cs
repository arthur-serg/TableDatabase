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
        private readonly DBCreator DbCreator = new DBCreator();

        private readonly DBWriter DbWriter = new DBWriter();

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

        private void saveToDatabaseButton_Click(object sender, EventArgs e)
        {
            if (!DbCreator.isDbExists())
            {
                DbCreator.Process();
            }

            DbWriter.Grid = this.dataGridView1;

            DbWriter.Process();
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
                        reader.GetValue(0), reader.GetValue(1),
                    });
                }
            }
        }
    }
}