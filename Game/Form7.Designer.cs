namespace Game
{
    partial class Form7
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form7));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Fifaks 1.0 dev1", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Font = new System.Drawing.Font("Fifaks 1.0 dev1", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 423);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Пользователю";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tabPage2.Controls.Add(this.listBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 423);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Админу";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.listBox1.Font = new System.Drawing.Font("Fifaks 1.0 dev1", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Items.AddRange(new object[] {
            "1. На стартовом экране выберите вариант Игрок (после чего вас переместит",
            "на вкладку игрока, для вы сможете выбрать стартовые данные для игры).",
            "",
            "2.  Введите имя пользователя (оно в случае победы будет занесено",
            "в таблицу результатов).",
            "",
            "3. Далее выберите количество вопросов, которое будет представленно в тесте.",
            "",
            "4. После необходимо выбрать уровень сложности (от уровня сложности",
            "будет зависеть количество жизней, т.е. количество раз, которое можно ошибиться.",
            "Легко: 3 жизни, Средне: 2 ; жизни, Легко: 1 жизнь).",
            "",
            "5. Также можно посмотреть результаты прошлых игр по соответствующей кнопке.",
            "",
            "6. Для начала игры нажать на кнопку Начать игру (будет осуществлён переход",
            "к самой игре).",
            "",
            "7. В ходе самой игры нужно выбрать один из 4 вариантов ответов на вопрос",
            "и нажать кнопку Продолжить (если на вопрос был дан верный ответ, то кнопка",
            "будет подсвечена зелёным цветом, если нет, то кнопка подсветится красным,",
            "а верный ответ зелёным).",
            "",
            "10. Можно один раз за игру взять подсказку 50/50 (она уберёт 2 неверных варианта " +
                "",
            "ответа из вопроса).",
            "",
            "9. Также можно отключить музыку рядом с иконкой динамика или завершить игру",
            "досрочно, нажав кнопку Выход.",
            "",
            "10. В случае победы или поражения будет выведена соответствующая информация."});
            this.listBox1.Location = new System.Drawing.Point(63, 6);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(666, 404);
            this.listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.listBox2.Font = new System.Drawing.Font("Fifaks 1.0 dev1", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Items.AddRange(new object[] {
            "1.  На стартовом экране выберите роль Админ (вас переместит на вкладку",
            " с авторизацией).",
            "",
            "2. На вкладке с авторизацией введите логин и пароль.",
            "",
            "3. Нажмите кнопку Подтвердить (вас переместит в окно Админа).",
            "",
            "4. В окне Админа вы можете добавить вопрос соотвествующей кнопкой( перед этим",
            "нужно заполнить все поля: вопрос, варианты ответа, правильный ответ).",
            "",
            "5. Также можно посмотреть всю базу вопросов, нажав кнопку Показать базу (откроетс" +
                "я",
            "вся база вопросов).",
            "",
            "6.  В окне с базой вопросов можно посмотреть все вопросы.",
            "",
            "7. Чтобы удалить вопрос из базы нужно выделить нужный вопрос и нажать ",
            "кнопку Удалить."});
            this.listBox2.Location = new System.Drawing.Point(58, 6);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(666, 404);
            this.listBox2.TabIndex = 0;
            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form7";
            this.Text = "Руководство пользователя";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox listBox2;
    }
}