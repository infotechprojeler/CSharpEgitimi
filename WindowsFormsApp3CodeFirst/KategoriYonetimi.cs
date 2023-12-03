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
    public partial class KategoriYonetimi : Form
    {
        public KategoriYonetimi()
        {
            InitializeComponent();
        }
        DatabaseContext context = new DatabaseContext();
        private void KategoriYonetimi_Load(object sender, EventArgs e)
        {
            dgvKategoriler.DataSource = context.Categories.ToList();
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
            var kategori = new Category()
            {
                Description = txtKategoriAciklamasi.Text,
                Name = txtKategoriAdi.Text,
                IsActive = cbDurum.Checked
            };
            context.Categories.Add(kategori);
            var sonuc = context.SaveChanges();
            if (sonuc > 0)
            {
                Temizle();
                dgvKategoriler.DataSource = context.Categories.ToList();
            }
        }

        private void dgvKategoriler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var kategori = context.Categories.Find(dgvKategoriler.CurrentRow.Cells[0].Value);
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
            var kategori = new Category()
            {
                Id = Convert.ToInt32(dgvKategoriler.CurrentRow.Cells[0].Value),
                Name = txtKategoriAdi.Text,
                Description = txtKategoriAciklamasi.Text,
                IsActive = cbDurum.Checked
            };
            context.Categories.AddOrUpdate(kategori);
            try
            {
                var sonuc = context.SaveChanges();
                if (sonuc > 0)
                {
                    dgvKategoriler.DataSource = context.Categories.ToList();
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
                var kategori = context.Categories.FirstOrDefault(x => x.Id == id); // 2. yöntem
                
                context.Categories.Remove(kategori);
                var sonuc = context.SaveChanges();
                if (sonuc > 0)
                {
                    Temizle();
                    dgvKategoriler.DataSource = context.Categories.ToList();
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
