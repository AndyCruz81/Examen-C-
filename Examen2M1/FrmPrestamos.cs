using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Examen2M1.Data;
using Examen2M1.Poco;

namespace Examen2M1
{
    public partial class FrmPrestamos : Form
    {
        private PrestamoModel prestamoModel;

        public FrmPrestamos()
        {
            InitializeComponent();
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            VentanaPrestamo ventana = new VentanaPrestamo();
            ventana.ShowDialog();
        }

        private void btnNuew_Click(object sender, EventArgs e)
        {
            VentanaPrestamo ventana = new VentanaPrestamo();
            ventana.ShowDialog();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "DAT|*.dat";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string currentFileName = openFileDialog.FileName;
                string FileName = currentFileName.Substring(0, currentFileName.Length - 3);
                prestamoModel = new PrestamoModel(FileName);
                Program.Prestamos = (List<Prestamo>)prestamoModel.GetAll();
                LoadTable();
            }
        }

        public static void LoadTable ()
        {
            dgvP.DataSource = Program.Prestamos;
        }
    }
}
