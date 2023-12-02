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
    public partial class KullaniciYonetimi : Form
    {
        public KullaniciYonetimi()
        {
            InitializeComponent();
        }
        KullaniciDAL kullaniciDAL = new KullaniciDAL();
        private void KullaniciYonetimi_Load(object sender, EventArgs e)
        {
            dgvKullanicilar.DataSource = kullaniciDAL.KayitlariDatatableileGetir("select * from Kullanicilar");
        }
    }
}
