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
using System.Media;



namespace Game
{
    public partial class Form1 : Form
    {
        
        SoundPlayer player = new SoundPlayer();
        SoundPlayer player2 = new SoundPlayer();
        SoundPlayer player3 = new SoundPlayer();
        string otvet;
        List<string> list = new List<string>();
        public static SQLiteConnection SQLiteConn;
        int hp,hp2;

        public Form1()
        {

            InitializeComponent();
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            button6.Enabled = false;
            radioButton1.Checked = true;
            player.SoundLocation = "super-mario-fanfara-okonchaniya-urovnya-muzyka-iz-igry-nintendo.wav";
            player2.SoundLocation = "mario-smert.wav";
            player3.SoundLocation = "q1-5-bed-2008.wav";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "")
            {
                button8.Enabled = true;
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                if (radioButton1.Checked == true)
                {
                    hp = 1;
                    pictureBox1.Visible = true;
                }
                if (radioButton2.Checked == true)
                {
                    hp = 2;
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                }
                if (radioButton3.Checked == true)
                {
                    hp = 3;
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = true;
                    pictureBox3.Visible = true;
                }
                label7.Text = (count + 1).ToString() + "/" + label3.Text;
                vopros();
                if (tabControl1.SelectedIndex < tabControl1.TabPages.Count)
                    tabControl1.SelectedIndex++;
                SQLiteCommand command1 = new SQLiteCommand("SELECT COUNT(*) FROM [Woprosi]", SQLiteConn);
                max = command1.ExecuteScalar().ToString();
                checkBox1.Checked = true;
                player3.PlayLooping();
            }
            else
                MessageBox.Show("Введите своё имя!");
            textBox2.SelectionLength = 0;


        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label3.Text = trackBar1.Value.ToString();
        }

        private bool OpenDBFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.db|*.db|Все файлы (*.*)|*.*";
            SQLiteConn = new SQLiteConnection("Data Source=" + "Woprosi.db" +
                ";Version=3");
            SQLiteConn.Open();
            SQLiteCommand command = new SQLiteCommand();
            command.Connection = SQLiteConn;
            return true;
        }
        private void vopros()
        {
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;
            button6.Enabled = false;
            int id = 0;
            Random rnd = new Random();
            int randIndex = rnd.Next(list1.Count);
            int random = Convert.ToInt32(list1[randIndex]);
            id = random;
            for (int j = 0; j < list.Count; j++)
            {
                if (Convert.ToInt32(list[j]) == id)
                {
                    randIndex = rnd.Next(list1.Count);
                    random = Convert.ToInt32(list1[randIndex]);
                    id = random;
                    j = 0;
                }
            }
            list.Add(id.ToString());

            SQLiteCommand command = new SQLiteCommand("SELECT [Вопрос] FROM [Woprosi] WHERE id = " + id + "", SQLiteConn);
            textBox2.Text = command.ExecuteScalar().ToString();

            SQLiteCommand command1 = new SQLiteCommand("SELECT [1 вариант] FROM [Woprosi] WHERE id = " + id + "", SQLiteConn);
            button2.Text = command1.ExecuteScalar().ToString();

            SQLiteCommand command2 = new SQLiteCommand("SELECT [2 вариант] FROM [Woprosi] WHERE id = " + id + "", SQLiteConn);
            button3.Text = command2.ExecuteScalar().ToString();

            SQLiteCommand command3 = new SQLiteCommand("SELECT [3 вариант] FROM [Woprosi] WHERE id = " + id + "", SQLiteConn);
            button4.Text = command3.ExecuteScalar().ToString();

            SQLiteCommand command4 = new SQLiteCommand("SELECT [4 вариант] FROM [Woprosi] WHERE id = " + id + "", SQLiteConn);
            button5.Text = command4.ExecuteScalar().ToString();

            SQLiteCommand command5 = new SQLiteCommand("SELECT [Правильный ответ] FROM [Woprosi] WHERE id = " + id + "", SQLiteConn);
            otvet = command5.ExecuteScalar().ToString();
            
        }
        int count = 0;
        private void button6_Click(object sender, EventArgs e)
        {
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            label7.Text = (count + 1).ToString() + "/" + label3.Text;
            if (count == Convert.ToInt32(label3.Text)-1)
            {
                player.Play();
                count-= hp2 - 1;
                string SQL = "INSERT INTO [Rating] ('Имя','Правильных ответов') VALUES ('" + textBox1.Text + "', '"+count+"')";
                SQLiteCommand command = new SQLiteCommand(SQL, SQLiteConn);
                command.ExecuteNonQuery();
                UpdatE();
                Form2 form2 = new Form2();
                form2.Show();
                return;
            }
            vopros();
            count++;
            label7.Text = (count + 1).ToString() + " /" + label3.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == otvet)
            {
                button2.BackColor = Color.LightGreen;
                button6.Enabled = true;
            }
            else
            {
                hp--;
                hp2++;
                HP();
                if (hp == 0)
                {
                    button2.BackColor = Color.Red;
                    Otvet(button2, button3, button4, button5);
                    UpdatE();
                    Form3 form3 = new Form3();
                    form3.Show();
                    player2.Play();
                }
                else
                {
                    button2.BackColor = Color.Red;
                    Otvet(button2, button3, button4, button5);
                    button6.Enabled = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == otvet)
            {
                button3.BackColor = Color.LightGreen;
                button6.Enabled = true;
            }
            else
            {
                hp--;
                hp2++;
                HP();
                if (hp == 0)
                {
                    button3.BackColor = Color.Red;
                    Otvet(button2, button3, button4, button5);
                    UpdatE();
                    Form3 form3 = new Form3();
                    form3.Show();
                    player2.Play();
                }
                else
                {
                    button3.BackColor = Color.Red;
                    Otvet(button2, button3, button4, button5);
                    button6.Enabled = true;
                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == otvet)
            {
                button4.BackColor = Color.LightGreen;
                button6.Enabled = true;
            }
            else
            {
                hp--;
                hp2++;
                HP();
                if (hp == 0)
                {
                    button4.BackColor = Color.Red;
                    Otvet(button2, button3, button4, button5);
                    UpdatE();
                    Form3 form3 = new Form3();
                    form3.Show();
                    player2.Play();
                }
                else
                {
                    button4.BackColor = Color.Red;
                    Otvet(button2, button3, button4, button5);
                    button6.Enabled = true;
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == otvet)
            {
                button5.BackColor = Color.LightGreen;
                button6.Enabled = true;
            }
            else
            {
                hp--;
                hp2++;
                HP();
                if (hp==0)
                {
                    button5.BackColor = Color.Red;
                    Otvet(button2, button3, button4, button5);
                    UpdatE();
                    Form3 form3 = new Form3();
                    form3.Show();
                    player2.Play();
                    
                }
                else
                {
                    button5.BackColor = Color.Red;
                    Otvet(button2, button3, button4, button5);
                    button6.Enabled = true;
                }
            }

        }

        private void UpdatE()
        {
            tabControl1.SelectedIndex = 0;
            textBox2.Clear();
            button2.Text = String.Empty;
            button3.Text = String.Empty;
            button4.Text = String.Empty;
            button5.Text = String.Empty;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;
            textBox1.Clear();
            count = 0;
            list.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void Otvet(Button b2, Button b3, Button b4, Button b5)
        {
            if (b2.Text == otvet)
                b2.BackColor = Color.LightGreen;
            if (b3.Text == otvet)
                b3.BackColor = Color.LightGreen;
            if (b4.Text == otvet)
                b4.BackColor = Color.LightGreen;
            if (b5.Text == otvet)
                b5.BackColor = Color.LightGreen;
        }
        private void HP()
        {
            if (hp == 2)
                pictureBox3.Visible = false;
            if (hp == 1)
                pictureBox2.Visible = false;
            if (hp == 0)
                pictureBox1.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button8.Enabled = false;
            int pods = 2;
            if (button2.Text != otvet && pods != 0)
            {
                button2.Text = String.Empty;
                button2.Enabled = false;
                pods--;
            }
            if (button3.Text != otvet && pods != 0)
            {
                button3.Text = String.Empty;
                button3.Enabled = false;
                pods--;
            }
            if (button4.Text != otvet && pods != 0)
            {
                button4.Text = String.Empty;
                button4.Enabled = false;
                pods--;
            }
            if (button5.Text != otvet && pods != 0)
            {
                button5.Text = String.Empty;
                button5.Enabled = false;
                pods--;
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenDBFile();
            string login = "red21";
            string password = "naer3543";
            if (textBox4.Text == login && textBox3.Text == password)
            {
                Form5 form5 = new Form5();
                form5.Show();
            }
            else
                MessageBox.Show("Неверный логин или пароль!");
            
        }
        public  static string max;
        private void button10_Click(object sender, EventArgs e)
        {
            SQLiteCommand command1 = new SQLiteCommand("SELECT COUNT(*) FROM [Woprosi]", SQLiteConn);
            max = command1.ExecuteScalar().ToString();
            tabControl1.SelectedIndex = 1;
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                player3.PlayLooping();
            }
            else
                player3.Stop();
        }

        public static List<string> list1 = new List<string>();


        private void button15_Click(object sender, EventArgs e)
        {
            UpdatE();
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            list1.Clear();
            OpenDBFile();
            string SQL ="SELECT id FROM Woprosi";
            DataTable table = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(SQL, SQLiteConn);
            adapter.Fill(table);
            for (int row = 0; row < table.Rows.Count; row++)
                list1.Add(table.Rows[row][0].ToString());
            
            
        }

    }
}