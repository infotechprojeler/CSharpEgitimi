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
            cbKategoriler.DataSource = context.Categories.ToList(); // ön yüzde gösterilecek kısımı display member özelliğine name yazarak, kullanıcının seçtiği kategori id sini kullanabilmek için ise valuemember özelliğine Id yazarak ayar yaptık.
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
                    Stock = int.Parse(txtStok.Text),
                    IsActive = cbDurum.Checked,
                    CategoryId = Convert.ToInt32(cbKategoriler.SelectedValue)
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

        private void dgvUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnEkle.Enabled = false;
                btnGuncelle.Enabled = true;
                btnSil.Enabled = true;
                btnGeri.Enabled = true;

                int urunId = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value);
                var urun = context.Products.Find(urunId); // ef de ürünü id sine göre bulmak için find metodu kullanılır
                txtUrunAdi.Text = urun.Name;
                txtUrunAciklamasi.Text = urun.Description;
                txtUrunFiyati.Text = urun.Price.ToString();
                txtStok.Text = urun.Stock.ToString();
                cbDurum.Checked = urun.IsActive;
                cbKategoriler.SelectedValue = urun.CategoryId;
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu!");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int urunId = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value);
            var urun = context.Products.Find(urunId);
            urun.Name = txtUrunAdi.Text;
            urun.Description = txtUrunAciklamasi.Text;
            urun.Stock = int.Parse(txtStok.Text);
            urun.Price = Convert.ToDecimal(txtUrunFiyati.Text);
            urun.IsActive = cbDurum.Checked;
            urun.CategoryId = (int)cbKategoriler.SelectedValue;

            var sonuc = context.SaveChanges();
            if (sonuc > 0)
            {
                Temizle();
                dgvUrunler.DataSource = context.Products.ToList();
                MessageBox.Show("Kayıt Başarılı!");
            }
            else
            {
                MessageBox.Show("Kayıt Başarısız!");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                int urunId = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value);
                var urun = context.Products.Find(urunId);
                context.Products.Remove(urun); // ef de silinecek olarak işaretler
                var sonuc = context.SaveChanges();
                if (sonuc > 0)
                {
                    Temizle();
                    dgvUrunler.DataSource = context.Products.ToList();
                    MessageBox.Show("Kayıt Silindi!");
                }
                else
                {
                    MessageBox.Show("Kayıt Silinemedi!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu!");
            }
        }
    }
}
