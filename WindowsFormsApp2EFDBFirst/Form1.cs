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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*
         * Entity framework
         * Projelerimizde sql kodu yazmadan veritabanı CRUD işlemlerini yapabilmemizi sağlayan microsoftun geliştirip destek verdiği 3.parti bir orm aracıdır.
         * EF ü kullanmak istediğimiz her projeye sağ tıklayıp açılan menüden Nuget package manager menüsüne tıklayıp açılan pencereden browse sekmesine geçip oradaki listeden(eğer çıkmazsa arama kutusuna entity framework yazarak) seçip yükle butonuna tıklayarak projemize yüklüyoruz.
         * Projedeki references i genişletip entityframework ve entityframework.sqlserver ı gördüysek işlem başarılıdır.
         * Entity frameworkde 4 farklı veritabanı kullanım yaklaşımı vardır
         * Databasefirst : var olan veritabanını kullanır
         * CodeFirst : önce class lar tanımlanır sonra veritabanı bu class lara göre oluşturulur
         * ModelFirst : Bir model tasarlanır ve veritabanı bu modeldeki tasarıma göre oluşturulur.
         * CodeFirst from Database : var olan veritabanını kullanan class lar elle yazılır (veya entityframework e oluşturtulur) böylece yapı bozulmadan kullanılır.
         * 
         * Veritabanı tablolarını tutan class context.cs uzantılı olan!
         */
        AdoNetDbEntities context = new AdoNetDbEntities();
        private void Form1_Load(object sender, EventArgs e)
        {
            dgvUrunler.DataSource = context.Urunler.ToList();
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
                context.Urunler.Add(new Urunler
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
                    dgvUrunler.DataSource = context.Urunler.ToList();
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
                var urun = context.Urunler.Find(urunId); // ef de ürünü id sine göre bulmak için find metodu kullanılır
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

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int urunId = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value);
            var urun = context.Urunler.Find(urunId);
            urun.Name = txtUrunAdi.Text;
            urun.Description = txtUrunAciklamasi.Text;
            urun.Stock = int.Parse(txtStok.Text);
            urun.Price = Convert.ToDecimal(txtUrunFiyati.Text);
            var sonuc = context.SaveChanges();
            if (sonuc > 0)
            {
                Temizle();
                dgvUrunler.DataSource = context.Urunler.ToList();
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
                var urun = context.Urunler.Find(urunId);
                context.Urunler.Remove(urun); // ef de silinecek olarak işaretler
                var sonuc = context.SaveChanges();
                if (sonuc > 0)
                {
                    Temizle();
                    dgvUrunler.DataSource = context.Urunler.ToList();
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

        private void btnAra_Click(object sender, EventArgs e)
        {
            dgvUrunler.DataSource = context.Urunler.Where(u => u.Name.Contains(txtAra.Text)).ToList(); // ef de arama filtreleme işlemleri where metoduyla yapılır. İçerisine yazılan komut lambda expression diye isimlendirilir burada u => u kodu u nun urunler tipinde bir nesne olduğunu ifade eder
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            // textbox değeri değiştikçe birden fazla alana göre yapma
            dgvUrunler.DataSource = context.Urunler.Where(u => u.Name.Contains(txtAra.Text) || u.Description.Contains(txtAra.Text)).ToList();
        }
    }
}
