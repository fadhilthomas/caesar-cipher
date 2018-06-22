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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Program ini dibuat untuk memenuhi tugas akhir\nMatematika Diskrit\n\n:: Muhammad Thomas Fadhila Yahya\n:: TI15Gx\n:: 15312574\n:: Teknik Informatika\n:: Perguruan Tinggi Teknokrat","Tentang");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form1 = new Form1();
            form1.Closed += (s, args) => this.Close();
            form1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var form2 = new Form2();
            form2.Closed += (s, args) => this.Close();
            form2.ShowDialog();
        }

        
        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
