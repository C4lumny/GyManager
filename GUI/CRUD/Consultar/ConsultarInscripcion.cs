﻿using Entidades;
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
    public partial class ConsultarInscripcion : Form
    {
        ServicioInscripcion serv;
        public ConsultarInscripcion()
        {
            InitializeComponent();
            serv = new ServicioInscripcion();
        }

        void CargarGrilla()
        {
            dgvInscripcion.Rows.Clear();
            var lista = serv.GetAll();
            if (lista != null)
            {
                foreach (Inscripcion inscripcion in lista)
                {
                    dgvInscripcion.Rows.Add(inscripcion.FechaInicio, inscripcion.FechaFinal, inscripcion.Precio, inscripcion.Cliente.Id, inscripcion.Cliente.Nombre, inscripcion.Supervisor.Id, inscripcion.Supervisor.Nombre, inscripcion.Plan.Id, inscripcion.IdEstado);
                }
            }

        }

        private void ConsultarInscripcionBD_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }
    }
}
