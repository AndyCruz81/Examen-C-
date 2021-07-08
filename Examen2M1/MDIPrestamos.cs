using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen2M1
{
    public partial class MDIPrestamos : Form
    {
        public MDIPrestamos()
        {
            InitializeComponent();
        }

        private void PrestamosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPrestamos frmPrestamos = new FrmPrestamos();
            frmPrestamos.MdiParent = this;
            frmPrestamos.Show();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavePrestamos save = new SavePrestamos();
            save.ShowDialog();
        }
    }
}
