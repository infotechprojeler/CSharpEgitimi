using ClassLibrary2;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.UI.WebControls;
using WindowsFormsApp3CodeFirst;

namespace WebApplicationEgitim
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DatabaseContext context = new DatabaseContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) // sayfadaki formu tetikleyen butonlardan birine basılmışsa sayfa postback olur, bu metot bu durumu kontrol eder ve sayfa sunucuya bir buton ile postalanmamışsa aşağıdaki kodları çalıştır işlevi görür
            {
                dgvUrunler.DataSource = context.Products.ToList();
                dgvUrunler.DataBind(); // web form da bu kodu yazmazsak grid view a veri yüklenmiyor!!
                ddlUrunKategorisi.DataSource = context.Categories.ToList();
                ddlUrunKategorisi.DataBind();
            }
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            var urun = new Product()
            {
                CategoryId = int.Parse(ddlUrunKategorisi.SelectedValue),
                Description = txtUrunAciklamasi.Text,
                IsActive = cbDurum.Checked,
                IsDelete = false,
                Name = txtUrunAdi.Text,
                Price = Convert.ToDecimal(txtUrunFiyati.Text),
                Stock = int.Parse(txtUrunStok.Text)
            };
            context.Products.Add(urun);
            int sonuc = context.SaveChanges();
            if (sonuc > 0) // eğer kayıt başarılıysa
            {
                Response.Redirect("/WebForm1.aspx"); // uygulamayı bu adrese yönlendir
            }
        }

        protected void dgvUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            int urunId = Convert.ToInt32(dgvUrunler.SelectedRow.Cells[1].Text);
            var urun = context.Products.Find(urunId);
            if (urun != null)
            {
                txtUrunAdi.Text = urun.Name;
                txtUrunAciklamasi.Text = urun.Description;
                txtUrunFiyati.Text = urun.Price.ToString();
                txtUrunStok.Text = urun.Stock.ToString();
                cbDurum.Checked = urun.IsActive;
                ddlUrunKategorisi.SelectedValue = urun.CategoryId.ToString();
            }
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            var urun = new Product()
            {
                Id = Convert.ToInt32(dgvUrunler.SelectedRow.Cells[1].Text),
                CategoryId = int.Parse(ddlUrunKategorisi.SelectedValue),
                Description = txtUrunAciklamasi.Text,
                IsActive = cbDurum.Checked,
                IsDelete = false,
                Name = txtUrunAdi.Text,
                Price = Convert.ToDecimal(txtUrunFiyati.Text),
                Stock = int.Parse(txtUrunStok.Text)
            };
            context.Products.AddOrUpdate(urun);
            int sonuc = context.SaveChanges();
            if (sonuc > 0) // eğer kayıt başarılıysa
            {
                Response.Redirect("/WebForm1.aspx"); // uygulamayı bu adrese yönlendir
            }
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                int urunId = Convert.ToInt32(dgvUrunler.SelectedRow.Cells[1].Text);
                var urun = context.Products.Find(urunId);
                if (urun != null)
                {
                    context.Products.Remove(urun);
                    int sonuc = context.SaveChanges();
                    if (sonuc > 0) // eğer kayıt başarılıysa
                    {
                        Response.Redirect("/WebForm1.aspx"); // uygulamayı bu adrese yönlendir
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}