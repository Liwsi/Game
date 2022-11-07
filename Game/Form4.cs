using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;
using System.Threading;
namespace Game
{
   
    public partial class Form4 : Form
    {
        public SQLiteConnection SQLiteConn; 
        DataTable table = new DataTable();
        private DataTable dTable;
        public Form4()
        {
            InitializeComponent();
            dTable = new DataTable();

        }
        List<string> list = new List<string>();
        private void Form4_Load(object sender, EventArgs e)
        {
            SQLiteConn = Form1.SQLiteConn;
            dataGridView1.DataSource = null;
            string SQL = "SELECT * FROM Rating";
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(SQL, SQLiteConn);
            adapter.Fill(dTable);
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            for (int col = 0; col < dTable.Columns.Count; col++)
            {
                string ColName = dTable.Columns[col].ColumnName;
                dataGridView1.Columns.Add(ColName, ColName);
                dataGridView1.Columns[col].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            for (int row = 0; row < dTable.Rows.Count; row++)
            {
                list.Add(dTable.Rows[row].ItemArray.ToString());
                dataGridView1.Rows.Add(dTable.Rows[row].ItemArray);
                dataGridView1.Rows[row].Cells[0].Style.BackColor = Color.LightSkyBlue;
                dataGridView1.Rows[row].Cells[1].Style.BackColor = Color.LightSkyBlue;

            }

        }
    }
}
