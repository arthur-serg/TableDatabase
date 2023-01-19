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
        readonly DatabaseManager dbm = new DatabaseManager();

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
            dbm.CreateDatabase();
        }

        private void LoadDatabase()
        {
            dbm.DataReader = dbm.ReadDatabase();
            while (dbm.DataReader.Read())
            {
                this.dataGridView1.Rows.Insert(0, dbm.DataReader.GetString(0), dbm.DataReader.GetString(1));
            }
        }
    }
}