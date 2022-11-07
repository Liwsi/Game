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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int max2 = Convert.ToInt32(Form1.list1[Form1.list1.Count-1]);
            max2++; 

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                string SQL = "INSERT INTO [Woprosi] ('id','Вопрос','1 вариант','2 вариант','3 вариант','4 вариант','Правильный ответ') VALUES ('" + max2 + "', '" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                SQLiteCommand command = new SQLiteCommand(SQL, Form1.SQLiteConn);
                command.ExecuteNonQuery();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
            }
            else
                MessageBox.Show("Нужно заполнить все поля!");
            Form1.list1.Add(max2.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
           Form6 form6 = new Form6();
            form6.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
