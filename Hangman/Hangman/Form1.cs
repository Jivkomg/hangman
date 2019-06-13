using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangman
{
    public partial class Form1 : Form
    {
        
        Label[] letters = new Label[18];
        string word = "";
        int tries = 0;
        int cntCorrectLetters = 0;

        public Form1()
        {
            InitializeComponent();
            letters[0] = label7;
            letters[1] = label8;
            letters[2] = label9;
            letters[3] = label10;
            letters[4] = label11;
            letters[5] = label12;
            letters[6] = label13;
            letters[7] = label14;
            letters[8] = label15;
            letters[9] = label16;
            letters[10] = label17;
            letters[11] = label18;
            letters[12] = label19;
            letters[13] = label20;
            letters[14] = label21;
            letters[15] = label22;

            
            label3.Hide();
            textBox3.Hide();
            label2.Hide();        
            textBox2.Hide();
            label4.Hide();
            label5.Hide();
            button1.Enabled = false;
            
            for (int i = 0; i < 16; i++ )
            {
                letters[i].Hide();

            }          
           
            textBox3.Text = tries.ToString();
        }
      
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {        
            word = textBox1.Text;
            label2.Text = label2.Text + word.Length + " letters";
            label2.Show();
            textBox2.Show();
            textBox1.ReadOnly = true;
            
            button1.Enabled = false;
            
            for (int i = 0; i < word.Length ; i++)
            {
                
                letters[i].Show();

            }
            
            tries = word.Length + 3;
            textBox3.Text = tries.ToString();
            label3.Show();
            textBox3.Show();

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            char symbol = textBox2.Text[textBox2.Text.Length - 1];
            if (word.IndexOf(symbol) != -1)
            {
                for (int i = word.IndexOf(symbol); i < word.Length; i++)
                {
                    if (word[i] == symbol)
                    {
                        letters[i].Text = symbol.ToString();
                        cntCorrectLetters++;
                    }

                }
            }
            else
            {
                tries--;
                textBox3.Text = tries.ToString();
            }

            if (tries == 0)
            {
                label5.Show();
                textBox2.Enabled = false;
            }

            else
            {
                if (cntCorrectLetters == word.Length)
                {
                    textBox2.Enabled = false;
                    label4.Show();
                }
            }
        }
           
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 16; i++)
            {
                letters[i].Text = "_";
                letters[i].Hide();
  
            }
            
            label3.Hide();
            textBox3.Clear();
            textBox3.Hide();

            label4.Hide();
            label5.Hide();

            textBox2.Enabled = true;
            textBox2.Clear();
            textBox2.Hide();

            label2.Text = "";
            label2.Hide();

            textBox1.Clear();
            textBox1.ReadOnly = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       

       
        
        
    }
  


      
        


       


       
       

    

        

        
    }

