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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true; // ekrandaki timerı aktif eder
            timer1.Interval = 1000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // timer nesnesine çift tıklayarak tick olayını tetikliyoruz
            Random random = new Random(); // rastgele değerler üreten nesnemiz
            this.BackColor = Color.FromArgb(random.Next(1, 100), random.Next(1, 100), random.Next(1, 100));
        }
    }
}
