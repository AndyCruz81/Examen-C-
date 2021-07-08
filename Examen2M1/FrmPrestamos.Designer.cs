namespace Examen2M1
{
    partial class FrmPrestamos
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
            this.label2 = new System.Windows.Forms.Label();
            dgvP = new System.Windows.Forms.DataGridView();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnNuew = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(dgvP)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(265, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Prestamos";
            // 
            // dgvP
            // 
            dgvP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dgvP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvP.Location = new System.Drawing.Point(12, 37);
            dgvP.Name = "dgvP";
            dgvP.Size = new System.Drawing.Size(632, 302);
            dgvP.TabIndex = 1;
            // 
            // btnOpen
            // 
            this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Location = new System.Drawing.Point(12, 371);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(126, 36);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Abrir";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnNuew
            // 
            this.btnNuew.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuew.Location = new System.Drawing.Point(518, 371);
            this.btnNuew.Name = "btnNuew";
            this.btnNuew.Size = new System.Drawing.Size(126, 36);
            this.btnNuew.TabIndex = 3;
            this.btnNuew.Text = "Nuevo";
            this.btnNuew.UseVisualStyleBackColor = true;
            this.btnNuew.Click += new System.EventHandler(this.btnNuew_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(270, 371);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(118, 36);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Actualizar";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // FrmPrestamos
            // 
            this.ClientSize = new System.Drawing.Size(656, 419);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnNuew);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(dgvP);
            this.Controls.Add(this.label2);
            this.Name = "FrmPrestamos";
            this.Text = "Prestamos";
            ((System.ComponentModel.ISupportInitialize)(dgvP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPrestamos;
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.Button btnVisualizar;
        private System.Windows.Forms.Label label2;
        private static System.Windows.Forms.DataGridView dgvP;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnNuew;
        private System.Windows.Forms.Button btnUpdate;
    }
}