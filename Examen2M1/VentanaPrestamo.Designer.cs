namespace Examen2M1
{
    partial class VentanaPrestamo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPeriodo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numTasa = new System.Windows.Forms.NumericUpDown();
            this.dgvPrestamos = new System.Windows.Forms.DataGridView();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.numMonto = new System.Windows.Forms.NumericUpDown();
            this.numPlazo = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numTasa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlazo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Monto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(313, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Periodo";
            // 
            // cmbPeriodo
            // 
            this.cmbPeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPeriodo.FormattingEnabled = true;
            this.cmbPeriodo.Location = new System.Drawing.Point(391, 22);
            this.cmbPeriodo.Name = "cmbPeriodo";
            this.cmbPeriodo.Size = new System.Drawing.Size(161, 28);
            this.cmbPeriodo.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Plazo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(313, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tasa (%)";
            // 
            // numTasa
            // 
            this.numTasa.DecimalPlaces = 2;
            this.numTasa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numTasa.Location = new System.Drawing.Point(391, 91);
            this.numTasa.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numTasa.Name = "numTasa";
            this.numTasa.Size = new System.Drawing.Size(161, 26);
            this.numTasa.TabIndex = 7;
            this.numTasa.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // dgvPrestamos
            // 
            this.dgvPrestamos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrestamos.Location = new System.Drawing.Point(12, 155);
            this.dgvPrestamos.Name = "dgvPrestamos";
            this.dgvPrestamos.Size = new System.Drawing.Size(577, 150);
            this.dgvPrestamos.TabIndex = 8;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(20, 126);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(75, 23);
            this.btnCalcular.TabIndex = 9;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.BtnCalcular_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Location = new System.Drawing.Point(498, 318);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(91, 32);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(12, 318);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(91, 32);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // numMonto
            // 
            this.numMonto.DecimalPlaces = 2;
            this.numMonto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numMonto.Location = new System.Drawing.Point(72, 22);
            this.numMonto.Maximum = new decimal(new int[] {
            1874919424,
            2328306,
            0,
            0});
            this.numMonto.Name = "numMonto";
            this.numMonto.Size = new System.Drawing.Size(194, 26);
            this.numMonto.TabIndex = 12;
            // 
            // numPlazo
            // 
            this.numPlazo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPlazo.Location = new System.Drawing.Point(72, 91);
            this.numPlazo.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numPlazo.Name = "numPlazo";
            this.numPlazo.Size = new System.Drawing.Size(194, 26);
            this.numPlazo.TabIndex = 13;
            // 
            // VentanaPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 362);
            this.Controls.Add(this.numPlazo);
            this.Controls.Add(this.numMonto);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.dgvPrestamos);
            this.Controls.Add(this.numTasa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbPeriodo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "VentanaPrestamo";
            this.Text = "Prestamo";
            this.Load += new System.EventHandler(this.VentanaPrestamo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numTasa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPlazo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPeriodo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numTasa;
        private System.Windows.Forms.DataGridView dgvPrestamos;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.NumericUpDown numMonto;
        private System.Windows.Forms.NumericUpDown numPlazo;
    }
}