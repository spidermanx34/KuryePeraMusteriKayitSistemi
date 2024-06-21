using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuryePera.FORMLARIM
{
    public partial class Form_Tahsilatlarim : Form
    {
        public Form_Tahsilatlarim()
        {
            InitializeComponent();
        }

        private void btnMusteriTahsilat_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Form_MusteriTahsilat tahsilat = new Form_MusteriTahsilat();
            tahsilat.ShowDialog();
            Cursor.Current = Cursors.Default;
        }

        private void btnKuryeTahsilat_Click(object sender, EventArgs e)
        {
            Cursor.Current= Cursors.WaitCursor;
            Form_KuryeTahsilat tahsilat = new Form_KuryeTahsilat();
            tahsilat.ShowDialog();
            Cursor.Current = Cursors.Default;
        }
    }
}
