using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsEgitim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Windows forms eğitimi";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "button1_Click çalıştı";
            Form2 form2 = new Form2(); // button1 e tıklanınca form 2 nesnesi oluştur
            // form2.ShowDialog(); // form2 yi ekrana getir - ShowDialog altta kalan forma müdahale ettirmez
            form2.Show(); // altta kalan formlar erişilebilir
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // aktif formu kapatır
        }
    }
}
