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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                DialogResult sonuc;
                sonuc = MessageBox.Show("Merhaba " + textBox1.Text, "Uyarı!", MessageBoxButtons.OKCancel); // ekranda uyarı penceresinde sadece ok yerine ok ve cancel tuşları çıksın
                if (sonuc == DialogResult.OK) // eğer kullanıcı ok butonuna tıkladıysa
                {
                    this.Close(); // formu kapat
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Çıkmak istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close(); // formu kapat
            }
        }
    }
}
