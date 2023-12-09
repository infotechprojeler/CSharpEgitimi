using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3CodeFirst
{
    public partial class KullaniciYonetimi : Form
    {
        public KullaniciYonetimi()
        {
            InitializeComponent();
        }
        DatabaseContext context = new DatabaseContext();
        private void KullaniciYonetimi_Load(object sender, EventArgs e)
        {
            dgvKullanicilar.DataSource = context.Users.ToList();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) || string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Kullanıcı Adı ve Şifre Boş Bırakılamaz!");
                return;
            }
            var kullanici = new User()
            {
                Email = txtEmail.Text,
                Name = txtAd.Text,
                Surname = txtSoyad.Text,
                Password = txtSifre.Text,
                Username = txtKullaniciAdi.Text,
                Phone = txtTelefon.Text,
                UserGuid = Guid.NewGuid() // her kullanıcıya özel bir kod oluşturur
            };
            context.Users.Add(kullanici);
            var sonuc = context.SaveChanges();
            if (sonuc > 0)
            {
                dgvKullanicilar.DataSource = context.Users.ToList();
                MessageBox.Show("Kayıt Başarılı!");
            }
        }

        private void dgvKullanicilar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dgvKullanicilar.CurrentRow.Cells[0].Value;
            var kullanici = context.Users.Find(id);

            txtAd.Text = kullanici.Name;
            txtSoyad.Text = kullanici.Surname;
            txtTelefon.Text = kullanici.Phone;
            txtEmail.Text = kullanici.Email;
            txtKullaniciAdi.Text = kullanici.Username;
            txtSifre.Text = kullanici.Password;

            btnEkle.Enabled = false;
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
            btnGeri.Enabled = true;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKullaniciAdi.Text) || string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Kullanıcı Adı ve Şifre Boş Bırakılamaz!");
                return;
            }
            var kullanici = new User()
            {
                Id = (int)dgvKullanicilar.CurrentRow.Cells[0].Value,
                Email = txtEmail.Text,
                Name = txtAd.Text,
                Surname = txtSoyad.Text,
                Password = txtSifre.Text,
                Username = txtKullaniciAdi.Text,
                Phone = txtTelefon.Text,
                UserGuid = Guid.NewGuid() // her kullanıcıya özel bir kod oluşturur
            };

            context.Users.AddOrUpdate(kullanici);
            var sonuc = context.SaveChanges();
            if (sonuc > 0)
            {
                dgvKullanicilar.DataSource = context.Users.ToList();
                MessageBox.Show("Kayıt Başarılı!");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var kullanici = context.Users.Find((int)dgvKullanicilar.CurrentRow.Cells[0].Value);

            context.Users.Remove(kullanici);

            var sonuc = context.SaveChanges();
            if (sonuc > 0)
            {
                dgvKullanicilar.DataSource = context.Users.ToList();
                MessageBox.Show("Kayıt Silme Başarılı!");
            }
        }
    }
}
