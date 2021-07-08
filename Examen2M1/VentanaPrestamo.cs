using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Examen2M1.Enums;
using Examen2M1.Poco;

namespace Examen2M1
{
    public partial class VentanaPrestamo : Form
    {
        private Prestamo Prestamo;

        public VentanaPrestamo()
        {
            InitializeComponent();
        }

        private void VentanaPrestamo_Load(object sender, EventArgs e)
        {
            cmbPeriodo.Items.AddRange(Enum.GetValues(typeof(Periodo)).Cast<object>().ToArray());
            cmbPeriodo.SelectedIndex = 0;
        }

        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            double monto = (double)numMonto.Value;
            string periodo = cmbPeriodo.SelectedItem.ToString();
            int plazo = (int)numPlazo.Value;
            decimal tasa = numTasa.Value / 100;

            Prestamo = new Prestamo()
            {
                Monto = monto,
                Periodo = periodo,
                Plazo = plazo,
                Tasa = tasa
            };

            CargarTabla(plazo, monto, (double)tasa);
        }

        private void AgregarPrestamo(Prestamo prestamo)
        {
            if (Program.Prestamos == null)
            {
                Program.Prestamos = new List<Prestamo>
                {
                    prestamo
                };
                return;
            }

            Program.Prestamos.Add(prestamo);
        }

        private void CargarTabla(int plazo, double monto, double tasa)
        {
            DataTable dataTable = new DataTable("Prestamos");
            DataColumn column;
            DataRow row;

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.Caption = "No";
            column.ColumnName = "No";
            column.Unique = true;
            column.ReadOnly = true;
            dataTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Double");
            column.Caption = "Cuota";
            column.ColumnName = "Cuota";
            column.Unique = false;
            column.ReadOnly = true;
            dataTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Double");
            column.Caption = "Abono";
            column.ColumnName = "Abono";
            column.Unique = false;
            column.ReadOnly = true;
            dataTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Double");
            column.Caption = "Interes";
            column.ColumnName = "Interes";
            column.Unique = false;
            column.ReadOnly = true;
            dataTable.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Double");
            column.Caption = "Saldo";
            column.ColumnName = "Saldo";
            column.Unique = false;
            column.ReadOnly = true;
            dataTable.Columns.Add(column);

            double abono = monto / plazo;

            for (int i = 0; i <= plazo; i++)
            {
                row = dataTable.NewRow();
                row["No"] = i;

                if (i == 0)
                {
                    row["Cuota"] = 0;
                    row["Abono"] = 0;
                    row["Interes"] = 0;
                    row["Saldo"] = monto;
                    dataTable.Rows.Add(row);
                    continue;
                }

                row["Abono"] = abono;
                double interes = Convert.ToDouble(dataTable.Rows[i - 1]["Saldo"]) * tasa;
                row["Interes"] = interes;
                row["Cuota"] = abono + interes;
                row["Saldo"] = Convert.ToDouble(dataTable.Rows[i - 1]["Saldo"]) - abono;

                dataTable.Rows.Add(row);
            }

            dgvPrestamos.DataSource = dataTable;
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            AgregarPrestamo(Prestamo);
            MessageBox.Show("Se ha registrado el prestamo", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
