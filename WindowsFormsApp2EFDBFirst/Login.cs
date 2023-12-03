using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2EFDBFirst
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void kategoriYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KategoriYonetimi kategoriYonetimi = new KategoriYonetimi();
            kategoriYonetimi.ShowDialog();
        }

        private void ürünYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 urunYonetimi = new Form1();
            urunYonetimi.ShowDialog();
        }

        private void kullanıcıYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KullaniciYonetimi kullaniciYonetimi = new KullaniciYonetimi();
            kullaniciYonetimi.ShowDialog();
        }
        AdoNetDbEntities context = new AdoNetDbEntities();
        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) || string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Kullanıcı Adı ve Şifre Boş Bırakılamaz!");
                return;
            }
            var kullanici = context.Kullanicilar.FirstOrDefault(k => k.Username == txtKullaniciAdi.Text && k.Password == txtSifre.Text);
            if (kullanici != null) // eğer kullanıcı adı ve şifre doğruysa
            {
                groupBox1.Visible = false; // giriş formunu gizle
                menuStrip1.Visible = true; // üst menüyü göster
            }
            else
            {
                MessageBox.Show("Giriş Başarısız!");
            }
        }
    }
}
