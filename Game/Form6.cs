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
    public partial class Form6 : Form
    {
        public SQLiteConnection SQLiteConn;
        DataTable table = new DataTable();
        private DataTable dTable;
        public Form6()
        {
            InitializeComponent();
            dTable = new DataTable();
        }
        public void start()
        {
            dTable.Clear();
            dTable.Columns.Clear();
            SQLiteConn = Form1.SQLiteConn;
            dataGridView1.DataSource = null;
            string SQL = "SELECT * FROM Woprosi";
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
                dataGridView1.Rows.Add(dTable.Rows[row].ItemArray);
                dataGridView1.Rows[row].Cells[0].Style.BackColor = Color.LightSkyBlue;
                dataGridView1.Rows[row].Cells[1].Style.BackColor = Color.LightSkyBlue;

            }

        }
        private void Form6_Load(object sender, EventArgs e)
        {
            start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            SQLiteCommand command = new SQLiteCommand("DELETE FROM Woprosi WHERE id="+index+"", SQLiteConn);
            command.ExecuteNonQuery();
            Form1.list1.Remove(index.ToString());
            start();
        }
    }
}
