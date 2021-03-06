﻿using ProyectoTiempos.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoTiempos.Vistas
{
    public partial class FrmVistasApostados : Form
    {
        private Logica log;
        public FrmVistasApostados()
        {
            InitializeComponent();
            log = new Logica();
            cbSorteo.DataSource = log.cargarComboSorteos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string cod = cbSorteo.SelectedItem.ToString();
            tablaGanadores.DataSource = log.vistasMontosApostados(cod);
        }
    }
}
