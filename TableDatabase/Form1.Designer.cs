
namespace TableDatabase
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.exitButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.generateTableButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.saveToDatabaseButton = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new System.Windows.Forms.Button();
            this.exportPlotButton = new System.Windows.Forms.Button();
            this.addRowsToTable = new System.Windows.Forms.Button();
            this.removeSelectedRowButton = new System.Windows.Forms.Button();
            this.updateDataButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(1086, 498);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.X,
            this.Y});
            this.dataGridView1.Location = new System.Drawing.Point(12, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 516);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // X
            // 
            this.X.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.X.HeaderText = "X";
            this.X.Name = "X";
            // 
            // Y
            // 
            this.Y.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            // 
            // generateTableButton
            // 
            this.generateTableButton.Location = new System.Drawing.Point(258, 38);
            this.generateTableButton.Name = "generateTableButton";
            this.generateTableButton.Size = new System.Drawing.Size(170, 33);
            this.generateTableButton.TabIndex = 3;
            this.generateTableButton.Text = "Create new table";
            this.generateTableButton.UseVisualStyleBackColor = true;
            this.generateTableButton.Click += new System.EventHandler(this.generateTableButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(349, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(79, 20);
            this.textBox1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Number of rows:";
            // 
            // saveToDatabaseButton
            // 
            this.saveToDatabaseButton.Location = new System.Drawing.Point(258, 75);
            this.saveToDatabaseButton.Name = "saveToDatabaseButton";
            this.saveToDatabaseButton.Size = new System.Drawing.Size(170, 33);
            this.saveToDatabaseButton.TabIndex = 6;
            this.saveToDatabaseButton.Text = "Save as new table";
            this.saveToDatabaseButton.UseVisualStyleBackColor = true;
            this.saveToDatabaseButton.Click += new System.EventHandler(this.saveToDatabaseButton_Click);
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(435, 4);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(726, 487);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(258, 418);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(170, 33);
            this.button1.TabIndex = 8;
            this.button1.Text = "Plot data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // exportPlotButton
            // 
            this.exportPlotButton.Location = new System.Drawing.Point(258, 458);
            this.exportPlotButton.Name = "exportPlotButton";
            this.exportPlotButton.Size = new System.Drawing.Size(170, 33);
            this.exportPlotButton.TabIndex = 9;
            this.exportPlotButton.Text = "Export plot";
            this.exportPlotButton.UseVisualStyleBackColor = true;
            this.exportPlotButton.Click += new System.EventHandler(this.exportPlotButton_Click);
            // 
            // addRowsToTable
            // 
            this.addRowsToTable.Location = new System.Drawing.Point(258, 112);
            this.addRowsToTable.Name = "addRowsToTable";
            this.addRowsToTable.Size = new System.Drawing.Size(170, 33);
            this.addRowsToTable.TabIndex = 10;
            this.addRowsToTable.Text = "Add data to table";
            this.addRowsToTable.UseVisualStyleBackColor = true;
            this.addRowsToTable.Click += new System.EventHandler(this.addRowsToTable_Click);
            // 
            // removeSelectedRowButton
            // 
            this.removeSelectedRowButton.Location = new System.Drawing.Point(258, 186);
            this.removeSelectedRowButton.Name = "removeSelectedRowButton";
            this.removeSelectedRowButton.Size = new System.Drawing.Size(170, 33);
            this.removeSelectedRowButton.TabIndex = 11;
            this.removeSelectedRowButton.Text = "Remove selected row";
            this.removeSelectedRowButton.UseVisualStyleBackColor = true;
            this.removeSelectedRowButton.Click += new System.EventHandler(this.removeSelectedRowButton_Click);
            // 
            // updateDataButton
            // 
            this.updateDataButton.Location = new System.Drawing.Point(258, 149);
            this.updateDataButton.Name = "updateDataButton";
            this.updateDataButton.Size = new System.Drawing.Size(170, 33);
            this.updateDataButton.TabIndex = 12;
            this.updateDataButton.Text = "Update data in table";
            this.updateDataButton.UseVisualStyleBackColor = true;
            this.updateDataButton.Click += new System.EventHandler(this.updateDataButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 533);
            this.Controls.Add(this.updateDataButton);
            this.Controls.Add(this.removeSelectedRowButton);
            this.Controls.Add(this.addRowsToTable);
            this.Controls.Add(this.exportPlotButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.saveToDatabaseButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.generateTableButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.exitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button generateTableButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveToDatabaseButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button exportPlotButton;
        private System.Windows.Forms.Button addRowsToTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.Button removeSelectedRowButton;
        private System.Windows.Forms.Button updateDataButton;
    }
}

