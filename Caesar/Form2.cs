using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Caesar
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if ((textBox1.Text == "A") || (textBox1.Text == "B") || (textBox1.Text == "C") || (textBox1.Text == "D") || (textBox1.Text == "E") || (textBox1.Text == "F") || (textBox1.Text == "G") || (textBox1.Text == "H") || (textBox1.Text == "I") || (textBox1.Text == "J") || (textBox1.Text == "K") || (textBox1.Text == "L") || (textBox1.Text == "M") || (textBox1.Text == "N") || (textBox1.Text == "O") || (textBox1.Text == "P") || (textBox1.Text == "Q") || (textBox1.Text == "R") || (textBox1.Text == "S") || (textBox1.Text == "T") || (textBox1.Text == "U") || (textBox1.Text == "V") || (textBox1.Text == "W") || (textBox1.Text == "X") || (textBox1.Text == "Y") || (textBox1.Text == "Z"))
            {
                MessageBox.Show("Kunci hanya berupa angka (1-25)");
                textBox1.Text = "0";
            }
            var yourSanitized = int.Parse(textBox1.Text);
            if (yourSanitized >= 0 && yourSanitized <= 26)
            {
                trackBar1.Value = int.Parse(yourSanitized.ToString());
            }else
            {
                MessageBox.Show("Kunci tidak boleh melebihi 26");
                textBox1.Text = "0";
            }
            textBox3.Text = caesarshift(textBox2.Text, textBox1.Text);
            toolStripStatusLabel1.Text = "Kunci = " + textBox1.Text;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = "" + trackBar1.Value;
            toolStripStatusLabel1.Text = "Kunci = " + trackBar1.Value;
            textBox3.Text = caesarshift(textBox2.Text, textBox1.Text);
        }

        public static string caesarshift(string input, string keys)
        {
            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string Text = input.ToUpper();
            int key = int.Parse(keys);
            string final = "";
            int indexOfChar = 0;
            char encryptedChar;
            foreach (char c in Text)
            {
                indexOfChar = alphabets.IndexOf(c);
                if (c == ' ')
                {
                    final = final + c;
                }
                else if ((c == '\r') || (c == '\n') || (c == '!') || (c == '@') || (c == '#') || (c == '$') || (c == '%') || (c == '^') || (c == '&') || (c == '*') || (c == '(') || (c == ')') || (c == '-') || (c == '_') || (c == '+') || (c == '=') || (c == '\'') || (c == '/') || (c == '1') || (c == '2') || (c == '3') || (c == '4') || (c == '5') || (c == '6') || (c == '7') || (c == '8') || (c == '9') || (c == '0') || (c == '.') || (c == ',') || (c == '?') || (c == '<') || (c == '>') || (c == '[') || (c == ']') || (c == '{') || (c == '}') || (c == ';') || (c == ':'))// if encounters a new line
                {
                    final = final + c;
                }
                else if ((indexOfChar - key) < 0)
                {
                    encryptedChar = alphabets[(indexOfChar - key) + 26];
                    final = final + encryptedChar;
                }
                else
                {
                    encryptedChar = alphabets[indexOfChar - key];
                    final = final + encryptedChar;
                }
            }
            return final;
        }

        public static string selesai(string input, string keys)
        {
            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string Text = input.ToUpper();
            int key = int.Parse(keys);
            string final = "";
            string langkah1 = "";
            string langkah2 = "\r\n\r\nLangkah II:\r\n";
            string hasil = "";
            int indexOfChar = 0;
            char encryptedChar;
            string huruf2 = "";
            string huruf3 = "";
            foreach (char c in Text)
            {
                indexOfChar = alphabets.IndexOf(c);
                if (c == ' ')
                {
                    final = final + c;
                    continue;
                }
                else if ((c == '\r') || (c == '\n') || (c == '!') || (c == '@') || (c == '#') || (c == '$') || (c == '%') || (c == '^') || (c == '&') || (c == '*') || (c == '(') || (c == ')') || (c == '-') || (c == '_') || (c == '+') || (c == '=') || (c == '\'') || (c == '/') || (c == '1') || (c == '2') || (c == '3') || (c == '4') || (c == '5') || (c == '6') || (c == '7') || (c == '8') || (c == '9') || (c == '0') || (c == '.') || (c == ',') || (c == '?') || (c == '<') || (c == '>') || (c == '[') || (c == ']') || (c == '{') || (c == '}') || (c == ';') || (c == ':'))// if encounters a new line
                {
                    final = final + c;
                    continue;
                }
                else if ((indexOfChar - key) < 0)
                {
                    huruf2 = c.ToString();
                    encryptedChar = alphabets[(indexOfChar - key) + 26];
                    huruf3 = encryptedChar.ToString();
                    final = final + encryptedChar;
                }
                else
                {
                    huruf2 = c.ToString();
                    encryptedChar = alphabets[indexOfChar - key];
                    huruf3 = encryptedChar.ToString();
                    final = final + encryptedChar;
                }
                int hasilmod = (alphabets.IndexOf(huruf2) - key) % 26 ;
                if(((alphabets.IndexOf(huruf2) - key) % 26)<0)
                {
                    hasilmod = ((alphabets.IndexOf(huruf2) - key) % 26) + 26;
                }
                langkah1 = langkah1 + huruf2 + "=" + alphabets.IndexOf(huruf2) + ", ";
                langkah2 = langkah2 + huruf2 + "->E(" + alphabets.IndexOf(huruf2) + ")\t\t\t= " + "(" + alphabets.IndexOf(huruf2) + "-" + key + ") mod 26\r\n\t\t\t= " + (alphabets.IndexOf(huruf2) - key) + " mod 26\r\n\t\t\t= " + hasilmod + " (" + huruf3 + ")\r\n\r\n";
            }
            hasil = langkah1 + langkah2;
            return hasil;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox2.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            textBox1.Text = "0";
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Apakah anda yakin ingin keluar?", "Keluar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    this.Hide();
                    var form3 = new Form3();
                    
                    form3.ShowDialog();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox2.CharacterCasing = CharacterCasing.Upper;
            textBox3.Text = caesarshift(textBox2.Text, textBox1.Text);
            textBox3.SelectionStart = textBox3.Text.Length;
            textBox3.ScrollToCaret();
        }

        private void textBox1_Click(object sender, MouseEventArgs e)
        {
            textBox1.SelectAll();
        }

        private Form4 rumus = new Form4();
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            rumus.textBox1.Text = "Diketahui\r\nCiphertext\t: " + textBox2.Text.Replace("\r\n", " ") + "\r\nKunci\t\t: " + textBox1.Text + "\r\n\r\nLangkah I:\r\n" + selesai(textBox2.Text, textBox1.Text) + "\r\nLangkah III:\r\nCiphertext\t: " + textBox2.Text.Replace("\r\n", " ") + "\r\nPlaintext\t\t: " + textBox3.Text.Replace("\r\n", " ");
            rumus.textBox2.Text = "= Dekripsi\r\n= Ciphertext\r\n= Kunci";
            rumus.textBox3.Text = "D\r\nc\r\nK";
            rumus.textBox3.Enabled = false;
            rumus.textBox2.Enabled = false;
            rumus.textBox1.Select(0, 0);
            rumus.label1.Text = "D(c) = (c - K) mod 26";
            rumus.ShowDialog();
        }
    }
}
