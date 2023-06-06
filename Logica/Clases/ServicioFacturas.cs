using Datos;
using Datos.Archivos;
using Datos.Archivos.Repositorio;
using Entidades.Pagos_y_Facturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Logica.Clases
{
    public class ServicioFacturas 
    {
        ConexionOracle coneccion;

        RepositorioFacturas rep;

        public ServicioFacturas()
        {
            coneccion = new ConexionOracle();
            rep = new RepositorioFacturas(coneccion);
        }

        public List<Facturas> GetListBySearch(string search)
        {
            throw new NotImplementedException();
        }

        public Facturas GetObjectById(string id)
        {
            try
            {
                return GetAll().FirstOrDefault(item => item.Id.ToString() == id);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Facturas GetObjectByIdInscripcion(string id)
        {
            try
            {   
                return GetAll().FirstOrDefault(item => item.Inscripcion.Id.ToString() == id);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<Facturas> GetAll()
        {
            var lista = rep.GetAll();
            if (lista == null)
            {
                return null;
            }
            return lista;
        }
        public Response<Facturas> validar_factura(Facturas factura)
        {
            if (factura.PagoIngresado <= 0)
            {
                return new Response<Facturas>(false, "No hay pagos registrados a esta factura");
            }
            else
            {
                return new Response<Facturas>(true, "Valido");
            }
        }
    }
}
