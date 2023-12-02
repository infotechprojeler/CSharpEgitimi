using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsEgitim
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value >= 1)
            {
                label1.Font = new Font("Arial", (float)numericUpDown1.Value);
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 50; i++) // 50 kere dön
            {
                domainUpDown1.Items.Add(FontFamily.Families[i].Name); // döngü her çalıştığında domainUpDown1 e sistemdeki fontlardan birini ekle
            }
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value >= 1)
            {
                label1.Font = new Font(domainUpDown1.SelectedItem.ToString(), (float)numericUpDown1.Value);
            }
        }
    }
}
