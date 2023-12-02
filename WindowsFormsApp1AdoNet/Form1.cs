using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1AdoNet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        UrunDAL urunDAL = new UrunDAL();
        private void Form1_Load(object sender, EventArgs e)
        {
            // form yüklenirken ekrandaki datagride verileri yüklüyoruz
            // dgvUrunler.DataSource = urunDAL.UrunleriGetir(); // ürün listesi ile
            dgvUrunler.DataSource = urunDAL.UrunleriDatatableileGetir();

            dgvUrunler.Columns[0].HeaderText = "Ürün No";
            dgvUrunler.Columns[1].HeaderText = "Ürün Adı";
            dgvUrunler.Columns[2].HeaderText = "Açıklama";
            dgvUrunler.Columns[3].HeaderText = "Fiyat";
            dgvUrunler.Columns[4].HeaderText = "Stok";
        }

        void Temizle()
        {
            txtStok.Text = string.Empty;
            txtUrunAciklamasi.Text = string.Empty;
            txtUrunAdi.Text = string.Empty;
            txtUrunFiyati.Text = string.Empty;
            btnEkle.Enabled = true;
            btnGuncelle.Enabled = false;
            btnSil.Enabled = false;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = urunDAL.Add(new Urun
                {
                    Name = txtUrunAdi.Text,
                    Description = txtUrunAciklamasi.Text,
                    Price = Convert.ToDecimal(txtUrunFiyati.Text),
                    Stock = int.Parse(txtStok.Text)
                });
                if (sonuc > 0)
                {
                    Temizle();
                    dgvUrunler.DataSource = urunDAL.UrunleriDatatableileGetir();
                    MessageBox.Show("Kayıt Başarılı!");
                }
                else
                    MessageBox.Show("Kayıt Başarısız!");
            }
            catch (Exception hata)
            {
                // todo: oluşan hatayı hata ile yakalayıp loglayabiliriz
                MessageBox.Show("Hata Oluştu! Geçersiz Değer Girdiniz!");
            }
            
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = urunDAL.Update(new Urun
                {
                    Id = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value),
                    Name = txtUrunAdi.Text,
                    Description = txtUrunAciklamasi.Text,
                    Price = Convert.ToDecimal(txtUrunFiyati.Text),
                    Stock = int.Parse(txtStok.Text)
                });
                if (sonuc > 0)
                {
                    Temizle();
                    dgvUrunler.DataSource = urunDAL.UrunleriDatatableileGetir();
                    MessageBox.Show("Kayıt Başarılı!");
                }
                else
                    MessageBox.Show("Kayıt Başarısız!");
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu! Geçersiz Değer Girdiniz!");
            }
        }

        private void dgvUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnEkle.Enabled = false;
                btnGuncelle.Enabled = true;
                btnSil.Enabled = true;
                btnGeri.Enabled = true;

                //Ekrandaki gridview dan satır seçerek formu doldurma
                /* 
                txtUrunAdi.Text = dgvUrunler.CurrentRow.Cells[1].Value.ToString();
                txtUrunAciklamasi.Text = dgvUrunler.CurrentRow.Cells[2].Value.ToString();
                txtUrunFiyati.Text = dgvUrunler.CurrentRow.Cells[3].Value.ToString();
                txtStok.Text = dgvUrunler.CurrentRow.Cells[4].Value.ToString();
                */
                int urunId = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value);
                var urun = urunDAL.UrunGetir(urunId);
                txtUrunAdi.Text = urun.Name;
                txtUrunAciklamasi.Text = urun.Description;
                txtUrunFiyati.Text = urun.Price.ToString();
                txtStok.Text = urun.Stock.ToString();
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
                int urunId = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value);
                var sonuc = urunDAL.Delete(urunId);
                if (sonuc > 0)
                {
                    Temizle();
                    dgvUrunler.DataSource = urunDAL.UrunleriDatatableileGetir();
                    MessageBox.Show("Silme Başarılı!");
                }
                else
                    MessageBox.Show("Silme Başarısız!");
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu!");
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            Temizle();
            btnGeri.Enabled = false;
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            dgvUrunler.DataSource = urunDAL.UrunleriDatatableileGetir(txtAra.Text);
        }
    }
}
