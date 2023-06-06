using Entidades;
using Entidades.Informacion_Persona;
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

namespace GUI.CRUD.Actualizar
{
    public partial class ActualizarDatosBiomedicos : Form
    {
        private string datoId;
        public ActualizarDatosBiomedicos(string Id)
        {
            InitializeComponent();
            datoId = Id;

            cargarTextBoxes(datoId);
        }

        private void cargarTextBoxes(string id)
        {
            ServicioDatosBiomedicos serv = new ServicioDatosBiomedicos();
            DatosBiomedicos dato = serv.GetObjectById(id);

            txtAltura.Text = dato.Altura.ToString();
            txtFrecuencia.Text = dato.FrecuenciaCardiaca.ToString();
            txtGrasa.Text = dato.GrasaCorporal.ToString();
            txtPeso.Text = dato.Peso.ToString();
            txtPresion.Text = dato.PresionArterial.ToString();
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ServicioDatosBiomedicos serv = new ServicioDatosBiomedicos();
            try
            {
                DatosBiomedicos datosAct = new DatosBiomedicos();
                datosAct.Altura = double.Parse(txtAltura.Text, System.Globalization.CultureInfo.InvariantCulture);
                datosAct.FrecuenciaCardiaca = int.Parse(txtFrecuencia.Text, System.Globalization.CultureInfo.InvariantCulture);
                datosAct.Peso = double.Parse(txtPeso.Text, System.Globalization.CultureInfo.InvariantCulture);
                datosAct.PresionArterial = int.Parse(txtPresion.Text, System.Globalization.CultureInfo.InvariantCulture);
                datosAct.GrasaCorporal = double.Parse(txtGrasa.Text, System.Globalization.CultureInfo.InvariantCulture);

                MessageBox.Show(serv.Actualizar(datosAct, datoId).Msg, "Actualización exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
