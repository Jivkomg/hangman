using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlipItLikeYouTickIt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int buttonSide, tb1text, tb2text;
        Image [] listskartininakone = new Image [1];

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Формата не може да е по-малко от двуизмерна !","Загубеняк !");
                textBox1.Text = "10";
                textBox2.Text = "10";
            }
            tb1text = Convert.ToInt32(textBox1.Text);
            tb2text = Convert.ToInt32(textBox2.Text);

            if (tb1text > 10)
            {
                textBox1.Text = "10";
            }
            if (tb1text < 2)
            {
                textBox1.Text = "2";
            }
            if (tb2text > 10)
            {
                textBox2.Text = "10";
            }
            if (tb2text < 2)
            {
                textBox2.Text = "2";
            }
            tb1text = Convert.ToInt32(textBox1.Text);
            tb2text = Convert.ToInt32(textBox2.Text);
            MakeButtons(tb1text,tb2text);
            Genesis();
      
        }

        /*public bool CheckIfWhite(Button b)
        {
            if (b.BackColor == Color.White)
            {
                return true;
            }
            else
            {
                return false;
            }
        }*/

        Form f;
        bool [] isWhite = new bool [100];

        Button [,] buttons = new Button [10,10];

        void MakeButtons(int x,int y)
        {
            f = new Form();
            if(x<8 && y<8)
            {
                buttonSide = 100;
                f.Size = new Size(buttonSide * x + (x + 1) * 10, buttonSide * y + (y + 1) * 10 + 30);
            }
            else
            {
                buttonSide = 50;
                f.Size = new Size(buttonSide * x + (x + 1) * 5, buttonSide * y + (y + 1) * 5 + 30);
            }
            this.Hide();
            f.Show();



            for (int i = 0; i < tb2text; i++)
            {
                for (int j = 0; j < tb1text; j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i,j].Click += Button_Flip;

                    if (x < 8 && y < 8)
                    buttons[i,j].Location = new Point(j * 10 + j * buttonSide, i * 10 + i * buttonSide);
                    else
                    buttons[i,j].Location = new Point(j * 5 + j * buttonSide, i * 5 + i * buttonSide);
                    buttons[i,j].Size = new Size(buttonSide, buttonSide);
                    buttons[i,j].BackColor = Color.Black;
                    f.Controls.Add(buttons[i,j]);  
                }
            }
           

            f.MinimumSize = new System.Drawing.Size(f.Width, f.Height);
            f.AutoSize = true;
            f.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            f.MaximizeBox = false;
            f.Text="Промени расовото отношение на света ;D";

            //System.ComponentModel.ComponentResourceManager resources =
             // new System.ComponentModel.ComponentResourceManager(typeof(Form));
            //f.Icon = ((System.Drawing.Icon)(resources.GetObject("33341.ico")));
            //f.Height += 1000;
            Button m = new Button();
            m.Click += new EventHandler(menu_Button);
            m.BackColor = Color.Black;
            m.ForeColor = Color.White;
            m.Text = "Меню";
            m.Font = new Font(m.Font.FontFamily, 18);
            m.Size = new System.Drawing.Size(f.Width / 2, 50);
            //m.ImageAlign = "Bottom Center";
            m.Location = new Point(0,f.Height-35);


            Button r = new Button();
            r.Click += new EventHandler(restart_Button);
            r.BackColor = Color.Black;
            r.ForeColor = Color.White;
            r.Text = "Рестарт";
            r.Font = new Font(r.Font.FontFamily, 18);
            r.Size = new System.Drawing.Size(f.Width / 2, 50);
            //m.ImageAlign = "Bottom Center";
            r.Location = new Point(f.Width/2, f.Height - 35);
            f.Controls.Add(r);
            f.Controls.Add(m);
        }
        private void Button_Flip(object sender, EventArgs e)
        {

            if (sender is Button)
            {
                Button b = (Button)sender;
                ChangeColour(b);
                for (int i = 0; i < tb2text; i++)
                {
                    for (int j = 0; j < tb1text; j++)
                    {
                        if (b == buttons[i,j])
                        {
                            if (i!=tb2text-1)
                            {
                                ChangeColour(buttons[i + 1, j]); 
                            }
                            if (i!=0)
                            {
                                ChangeColour(buttons[i - 1, j]);
                            }
                            if (j!=tb1text-1)
                            {
                                ChangeColour(buttons[i, j + 1]);
                            }
                            if (j!=0)
                            {
                                ChangeColour(buttons[i, j - 1]);
                            }

                        }
                    }
                }
                WinCondition();
            }
        }
        private void ChangeColour(Button b)
        {
            if (b.BackColor == Color.White)
            {
                b.BackColor = Color.Black;
            }
            else if (b.BackColor == Color.Black)
            {
                b.BackColor = Color.White;
            }
        }
        private void GenerateLevel()
        {
            for (int i = 0; i < tb2text; i++)
            {
                for (int j = 0; j < tb1text; j++)
                {
                    buttons[i, j].BackColor = Color.Black;
                }   
            }
            Genesis();
        }
        private void menu_Button(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void restart_Button(object sender, EventArgs e)
        {
            //goto BackDoor;
            GenerateLevel();
        }
        private void WinCondition()
        {
            bool win = true;
            for (int i = 0; i < tb2text; i++)
            {
                for (int j = 0; j < tb1text; j++)
                {
                    if (buttons[i, j].BackColor == Color.Black)
                    {
                        win = false;
                    }
                }
            }
            if (win)
            {
                Form w = new Form();
                w.Size = new Size(900,650);
                PictureBox picture = new PictureBox
                {
                    Name = "pictureBox",
                    Size = new Size(900, 650),
                    Location = new Point(0, 0)
                };
                w.Controls.Add(picture);
                picture.ImageLocation = "E:/FlipItLikeYouTickIt/FlipItLikeYouTickIt/bin/Debug/zebra-in-black-and-white-malcolm-macgregor.jpg";
                w.Text = "Зебрата е черно-бяла, Зебрата е неутрална - Бъди като Зебрата !";
                w.Font = new Font("Comic Sans MS", 18);
                w.Show();
                f.Close();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //unneeded
            /*f.MinimumSize = new System.Drawing.Size(f.Width,f.Height);
            f.AutoSize = true;
            f.AutoSizeMode = AutoSizeMode.GrowAndShrink;*/
            //textBox1.Text=(isWhite[24].ToString());

        }

        public void Genesis ()
        {
            double tobeflipped = Math.Floor(Math.Sqrt(tb1text*tb2text));
            
            for (int i = 0; i < tobeflipped-1; i++)
            {
                Random r = new Random();
                int X = r.Next(0, tb2text);
                int Y = r.Next(0, tb1text);
                if (buttons[X,Y].BackColor!=Color.White && X!=tb2text-1-X && Y!=tb1text-1-Y)
                {
                    ChangeColour(buttons[X,Y]);
                    ChangeColour(buttons[tb2text - 1 - X, tb1text - 1 - Y]);
                }
                else
                {
                    i--;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form t = new Form();
            t.MaximizeBox = false;
            Label l = new Label();
            l.Location = new Point(0,0);
            l.Size = new System.Drawing.Size(290,290);
            t.AutoSize = true;
            t.AutoSizeMode = AutoSizeMode.GrowAndShrink; 
            t.Controls.Add(l);
            t.Text = "Тотуриал";
            l.Text = "Избери брой на квадратите по двете измерения и натисни стартовия бутон. \n Целта на играта е да обърнеш всички квадратчета, така че да са бели !";
            l.Font = new Font( "Monotype Corsiva",14);
            //l.Font.Size = 14;
            t.Show();
            l.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form c = new Form();
            c.MaximizeBox = false;
            Label l = new Label();
            l.Location = new Point(0, 0);
            l.Size = new System.Drawing.Size(350, 250);
            c.AutoSize = true;
            c.AutoSizeMode = AutoSizeMode.GrowAndShrink; 
            c.Controls.Add(l);
            c.Text = "Кредити";
            l.Text = "Екип:\nПрограмисти:\nДеян Величков и Живко Георгиев\nДизайн:\nДеян Величков\nРешения на странни проблеми:\nЖивко Георгиев\nГодина на издаване:\n2018";
            //l.Font.Name. = "Monotype Corsiva";
            //l.Font.Size = 14;
            l.Font = new Font("Monotype Corsiva",18);
            //l.TextAlign=
            c.Show();
            l.Show();
        }
    }
}
