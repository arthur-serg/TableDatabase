﻿using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TableDatabase
{
    class ChartDrawer
    {
        public Chart Chart { get; set; } = new Chart();

        public bool Init(DataGridView dgv, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                Chart.DataSource = dt;
                for (int i = 0; i < dt.Rows.Count; ++i)
                {
                    var x = dgv.Rows[i].Cells[0].Value;
                    var y = dgv.Rows[i].Cells[1].Value;

                    Chart.Series["Series1"].Points.AddXY(x, y);
                }

                return true;
            }

            return false;
        }

        public void ExportChart()
        {
        }
    }
}