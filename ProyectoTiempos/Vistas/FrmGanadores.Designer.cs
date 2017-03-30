namespace ProyectoTiempos.Vistas
{
    partial class FrmGanadores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGanadores));
            this.label1 = new System.Windows.Forms.Label();
            this.tablaGanadores = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.cbSorteo = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFelicidades = new System.Windows.Forms.Label();
            this.lblMontoPagado = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tablaGanadores)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(220, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "listas de Ganadores ";
            // 
            // tablaGanadores
            // 
            this.tablaGanadores.AllowUserToAddRows = false;
            this.tablaGanadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaGanadores.Location = new System.Drawing.Point(12, 75);
            this.tablaGanadores.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tablaGanadores.Name = "tablaGanadores";
            this.tablaGanadores.RowTemplate.Height = 24;
            this.tablaGanadores.Size = new System.Drawing.Size(556, 281);
            this.tablaGanadores.TabIndex = 1;
            this.tablaGanadores.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tablaGanadores_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Codigo de Sorteo";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(319, 5);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // cbSorteo
            // 
            this.cbSorteo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSorteo.FormattingEnabled = true;
            this.cbSorteo.Location = new System.Drawing.Point(136, 2);
            this.cbSorteo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSorteo.Name = "cbSorteo";
            this.cbSorteo.Size = new System.Drawing.Size(163, 24);
            this.cbSorteo.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblNombre);
            this.panel1.Controls.Add(this.lblMontoPagado);
            this.panel1.Controls.Add(this.lblFelicidades);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(630, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(225, 192);
            this.panel1.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(705, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Informacion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Nombre :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Monto Pagado :";
            // 
            // lblFelicidades
            // 
            this.lblFelicidades.AutoSize = true;
            this.lblFelicidades.Location = new System.Drawing.Point(75, 132);
            this.lblFelicidades.Name = "lblFelicidades";
            this.lblFelicidades.Size = new System.Drawing.Size(0, 17);
            this.lblFelicidades.TabIndex = 3;
            // 
            // lblMontoPagado
            // 
            this.lblMontoPagado.AutoSize = true;
            this.lblMontoPagado.Location = new System.Drawing.Point(139, 84);
            this.lblMontoPagado.Name = "lblMontoPagado";
            this.lblMontoPagado.Size = new System.Drawing.Size(0, 17);
            this.lblMontoPagado.TabIndex = 5;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(139, 38);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(0, 17);
            this.lblNombre.TabIndex = 6;
            // 
            // FrmGanadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(859, 422);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbSorteo);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tablaGanadores);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmGanadores";
            this.Text = "Tabla de Ganadores";
            ((System.ComponentModel.ISupportInitialize)(this.tablaGanadores)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView tablaGanadores;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox cbSorteo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblMontoPagado;
        private System.Windows.Forms.Label lblFelicidades;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
    }
}