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

namespace WindowsFormsApp2EFDBFirst
{
    public partial class KategoriYonetimi : Form
    {
        public KategoriYonetimi()
        {
            InitializeComponent();
        }
        AdoNetDbEntities context = new AdoNetDbEntities();
        private void KategoriYonetimi_Load(object sender, EventArgs e)
        {
            dgvKategoriler.DataSource = context.Kategoriler.ToList();
        }
        void Temizle()
        {
            txtKategoriAciklamasi.Text = string.Empty;
            txtKategoriAdi.Text = string.Empty;

            btnEkle.Enabled = true;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            var kategori = new Kategoriler()
            {
                Name = txtKategoriAdi.Text,
                Description = txtKategoriAciklamasi.Text,
                IsActive = cbDurum.Checked
            };
            context.Kategoriler.Add(kategori);
            try
            {
                Temizle();
                var sonuc = context.SaveChanges();
                if (sonuc > 0)
                {
                    dgvKategoriler.DataSource = context.Kategoriler.ToList();
                    MessageBox.Show("Kayıt Başarılı!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu!");
            }
        }

        private void dgvKategoriler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var kategori = context.Kategoriler.Find(dgvKategoriler.CurrentRow.Cells[0].Value);
            if (kategori != null)
            {
                txtKategoriAdi.Text = kategori.Name;
                txtKategoriAciklamasi.Text = kategori.Description;
                cbDurum.Checked = kategori.IsActive;
            }
            btnEkle.Enabled = false;
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
            btnGeri.Enabled = true;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            var kategori = new Kategoriler()
            {
                Id = Convert.ToInt32(dgvKategoriler.CurrentRow.Cells[0].Value),
                Name = txtKategoriAdi.Text,
                Description = txtKategoriAciklamasi.Text,
                IsActive = cbDurum.Checked
            };
            context.Kategoriler.AddOrUpdate(kategori);
            try
            {
                var sonuc = context.SaveChanges();
                if (sonuc > 0)
                {
                    dgvKategoriler.DataSource = context.Kategoriler.ToList();
                    MessageBox.Show("Kayıt Başarılı!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu!");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                int id = (int)dgvKategoriler.CurrentRow.Cells[0].Value;
                // var kategori = context.Kategoriler.Find(id); // 1. yöntem
                Kategoriler kategori = context.Kategoriler.FirstOrDefault(x => x.Id == id); // 2. yöntem
                // ef de change tracking denilen bir yapı vardır ve bu yapı context i izleyerek hareket eder, yeni kayıt ekleme, silme, kayıt getirme olaylarını izler ve komutlarımıza göre işlem yapar.
                context.Kategoriler.Remove(kategori);
                var sonuc = context.SaveChanges();
                if (sonuc > 0)
                {
                    Temizle();
                    dgvKategoriler.DataSource = context.Kategoriler.ToList();
                    MessageBox.Show("Kayıt Silindi!");
                }
                else
                    MessageBox.Show("Kayıt Silinemedi!");
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu!");
            }
        }
    }
}
