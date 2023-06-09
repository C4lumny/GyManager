﻿using Entidades.Informacion_Persona;
using Logica.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Pureba
{
    public partial class ConsultarHistorialBiomedico : Form
    {

        //ServicioHistorial serv;
        ServicioDatosBiomedicos serv;

        public ConsultarHistorialBiomedico()
        {
            InitializeComponent();
            serv = new ServicioDatosBiomedicos();
            CargarGrilla();
            dgvHistorialBiomedico.ClearSelection();

        }

        void CargarGrilla()
        {
            dgvHistorialBiomedico.Rows.Clear();
            var lista = serv.GetHistorial();
            if (lista != null)
            {
                foreach (DatosBiomedicos dato in lista)
                {
                    dgvHistorialBiomedico.Rows.Add(dato.Id, dato.FechaRegistro.ToShortDateString(), dato.id_cliente.ToString(), dato.Altura.ToString(), dato.Peso.ToString(), dato.IdCategoriaPeso.ToString(), dato.Imc.ToString(), dato.GrasaCorporal.ToString(), dato.FrecuenciaCardiaca.ToString(), dato.PresionArterial.ToString());
                }
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string buscado = txtBusqueda.Text;
            dgvHistorialBiomedico.Rows.Clear();
            if (buscado.All(char.IsDigit))
            {
                List<DatosBiomedicos> datosBuscados = serv.GetListBySearchHB(buscado);
                if (datosBuscados != null)
                {
                    foreach (DatosBiomedicos dato in datosBuscados)
                    {
                        dgvHistorialBiomedico.Rows.Add(dato.Id, dato.FechaRegistro.ToShortDateString(), dato.id_cliente.ToString(), dato.Altura.ToString(), dato.Peso.ToString(), dato.IdCategoriaPeso.ToString(), dato.Imc.ToString(), dato.GrasaCorporal.ToString(), dato.FrecuenciaCardiaca.ToString(), dato.PresionArterial.ToString());
                    }
                }
            }
        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
