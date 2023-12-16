using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WindowsFormsApp3CodeFirst;

namespace WebApplicationEgitim
{
    public partial class KategoriYonetimi : System.Web.UI.Page
    {
        DatabaseContext context = new DatabaseContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dgvKategoriler.DataSource = context.Categories.ToList();
                dgvKategoriler.DataBind();
            }
        }

        protected void btnEkle_Click(object sender, EventArgs e)
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
                Response.Redirect("KategoriYonetimi.aspx");
            }
        }

        protected void dgvKategoriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(dgvKategoriler.SelectedRow.Cells[1].Text);
            var kategori = context.Categories.Find(id);
            if (kategori != null)
            {
                txtKategoriAdi.Text = kategori.Name;
                txtKategoriAciklamasi.Text = kategori.Description;
                cbDurum.Checked = kategori.IsActive;
            }
            btnEkle.Enabled = false;
            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
        }
    }
}