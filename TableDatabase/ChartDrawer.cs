using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TableDatabase
{
    class ChartDrawer
    {
        public Chart Chart { get; set; } = new Chart();

        public bool Init(DataGridView dgv, DataTable dt)
        {
            Chart.DataSource = dt;
            Chart.DataBind();
            Chart.Series["Series1"].XValueMember = "X";
            Chart.Series["Series1"].YValueMembers = "Y";
            //TODO: рисовать данные нормально, а не в порядке строк БД.

            return true;
        }
    }
}