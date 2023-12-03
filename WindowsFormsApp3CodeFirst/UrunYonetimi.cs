using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3CodeFirst
{
    public partial class UrunYonetimi : Form
    {
        public UrunYonetimi()
        {
            InitializeComponent();
        }
        DatabaseContext context = new DatabaseContext();
        private void UrunYonetimi_Load(object sender, EventArgs e)
        {
            dgvUrunler.DataSource = context.Products.ToList();
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
            if (string.IsNullOrWhiteSpace(txtUrunAdi.Text))
            {
                MessageBox.Show("Ürün Adı Boş Bırakılamaz!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUrunFiyati.Text))
            {
                MessageBox.Show("Ürün Fiyatı Boş Bırakılamaz!");
                return;
            }
            try
            {
                context.Products.Add(new Product
                {
                    Name = txtUrunAdi.Text,
                    Description = txtUrunAciklamasi.Text,
                    Price = Convert.ToDecimal(txtUrunFiyati.Text),
                    Stock = int.Parse(txtStok.Text)
                });
                var sonuc = context.SaveChanges(); // SaveChanges metodu entity framework de ekleme işlemini veritabanına işler. Bu metodu çağırmazsak değişiklik veritabanına yansımaz!!!
                if (sonuc > 0)
                {
                    Temizle();
                    dgvUrunler.DataSource = context.Products.ToList();
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
    }
}
