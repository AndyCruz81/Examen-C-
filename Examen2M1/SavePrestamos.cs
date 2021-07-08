using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Examen2M1.Poco;
using Examen2M1.Data;

namespace Examen2M1
{
    public partial class SavePrestamos : Form
    {
        public SavePrestamos()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Digite un nombre para el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<Prestamo> prestamos = Program.Prestamos;
            string fileName = txtNombre.Text;

            PrestamoModel model = new PrestamoModel(fileName);

            foreach (Prestamo p in prestamos)
            {
                model.Create(p);
            }
        }
    }
}
