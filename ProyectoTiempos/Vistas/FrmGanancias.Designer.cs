namespace ProyectoTiempos.Vistas
{
    partial class FrmGanancias
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
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMaxima = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblMinima = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbSorteo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(306, 39);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sorteos :";
            // 
            // lblMaxima
            // 
            this.lblMaxima.AutoSize = true;
            this.lblMaxima.Location = new System.Drawing.Point(198, 127);
            this.lblMaxima.Name = "lblMaxima";
            this.lblMaxima.Size = new System.Drawing.Size(0, 17);
            this.lblMaxima.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ganancia Maxima :";
            // 
            // lblMinima
            // 
            this.lblMinima.AutoSize = true;
            this.lblMinima.Location = new System.Drawing.Point(198, 200);
            this.lblMinima.Name = "lblMinima";
            this.lblMinima.Size = new System.Drawing.Size(0, 17);
            this.lblMinima.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 200);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Ganancia minima :";
            // 
            // cbSorteo
            // 
            this.cbSorteo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSorteo.FormattingEnabled = true;
            this.cbSorteo.Location = new System.Drawing.Point(111, 44);
            this.cbSorteo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbSorteo.Name = "cbSorteo";
            this.cbSorteo.Size = new System.Drawing.Size(165, 24);
            this.cbSorteo.TabIndex = 7;
            // 
            // FrmGanancias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProyectoTiempos.Properties.Resources.Fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(455, 319);
            this.Controls.Add(this.cbSorteo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblMinima);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblMaxima);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBuscar);
            this.Name = "FrmGanancias";
            this.Text = "FrmGanancias";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMaxima;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblMinima;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbSorteo;
    }
}