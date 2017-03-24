namespace ProyectoTiempos.Vistas
{
    partial class FrmVerSorteos
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.lblFechaSorteo = new System.Windows.Forms.Label();
            this.lblNumeroSorteo = new System.Windows.Forms.Label();
            this.cbSorteo = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione sorteo";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblFecha);
            this.panel1.Controls.Add(this.lblCodigo);
            this.panel1.Controls.Add(this.lblFechaSorteo);
            this.panel1.Controls.Add(this.lblNumeroSorteo);
            this.panel1.Location = new System.Drawing.Point(107, 56);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(181, 114);
            this.panel1.TabIndex = 1;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(85, 72);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(0, 13);
            this.lblFecha.TabIndex = 8;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(85, 11);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(0, 13);
            this.lblCodigo.TabIndex = 7;
            // 
            // lblFechaSorteo
            // 
            this.lblFechaSorteo.AutoSize = true;
            this.lblFechaSorteo.Location = new System.Drawing.Point(2, 72);
            this.lblFechaSorteo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFechaSorteo.Name = "lblFechaSorteo";
            this.lblFechaSorteo.Size = new System.Drawing.Size(37, 13);
            this.lblFechaSorteo.TabIndex = 6;
            this.lblFechaSorteo.Text = "Fecha";
            // 
            // lblNumeroSorteo
            // 
            this.lblNumeroSorteo.AutoSize = true;
            this.lblNumeroSorteo.Location = new System.Drawing.Point(2, 11);
            this.lblNumeroSorteo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumeroSorteo.Name = "lblNumeroSorteo";
            this.lblNumeroSorteo.Size = new System.Drawing.Size(74, 13);
            this.lblNumeroSorteo.TabIndex = 0;
            this.lblNumeroSorteo.Text = "Codigo Sorteo";
            // 
            // cbSorteo
            // 
            this.cbSorteo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSorteo.FormattingEnabled = true;
            this.cbSorteo.Location = new System.Drawing.Point(155, 18);
            this.cbSorteo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbSorteo.Name = "cbSorteo";
            this.cbSorteo.Size = new System.Drawing.Size(92, 21);
            this.cbSorteo.TabIndex = 3;
            this.cbSorteo.SelectedIndexChanged += new System.EventHandler(this.cbSorteo_SelectedIndexChanged);
            // 
            // FrmVerSorteos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProyectoTiempos.Properties.Resources.Fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(384, 275);
            this.Controls.Add(this.cbSorteo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmVerSorteos";
            this.Text = "FrmVerSorteos";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblFechaSorteo;
        private System.Windows.Forms.Label lblNumeroSorteo;
        private System.Windows.Forms.ComboBox cbSorteo;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblCodigo;
    }
}