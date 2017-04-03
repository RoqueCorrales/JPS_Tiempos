namespace ProyectoTiempos.Vistas
{
    partial class FrmVistasApostados
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
            this.cbSorteo = new System.Windows.Forms.ComboBox();
            this.tablaGanadores = new System.Windows.Forms.DataGridView();
            this.btnBuscar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tablaGanadores)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sorteo :";
            // 
            // cbSorteo
            // 
            this.cbSorteo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSorteo.FormattingEnabled = true;
            this.cbSorteo.Location = new System.Drawing.Point(131, 26);
            this.cbSorteo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSorteo.Name = "cbSorteo";
            this.cbSorteo.Size = new System.Drawing.Size(165, 24);
            this.cbSorteo.TabIndex = 8;
            // 
            // tablaGanadores
            // 
            this.tablaGanadores.AllowUserToAddRows = false;
            this.tablaGanadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaGanadores.Location = new System.Drawing.Point(31, 71);
            this.tablaGanadores.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tablaGanadores.Name = "tablaGanadores";
            this.tablaGanadores.RowTemplate.Height = 24;
            this.tablaGanadores.Size = new System.Drawing.Size(411, 220);
            this.tablaGanadores.TabIndex = 9;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(342, 27);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 23);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // FrmVistasApostados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProyectoTiempos.Properties.Resources.Fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(469, 318);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.tablaGanadores);
            this.Controls.Add(this.cbSorteo);
            this.Controls.Add(this.label1);
            this.Name = "FrmVistasApostados";
            this.Text = "FrmVistasApostados";
            ((System.ComponentModel.ISupportInitialize)(this.tablaGanadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSorteo;
        private System.Windows.Forms.DataGridView tablaGanadores;
        private System.Windows.Forms.Button btnBuscar;
    }
}