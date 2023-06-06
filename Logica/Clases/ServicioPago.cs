using Datos;
using Datos.Archivos;
using Datos.Archivos.Repositorio;
using Entidades;
using Entidades.Informacion_Persona;
using Entidades.Pagos_y_Facturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    public class ServicioPago : ICRUD<Pago, int>, IGetBySearch<Pago>
    {
        ConexionOracle coneccion;

        RepositorioPagos rep;
        public ServicioPago()
        {
            coneccion = new ConexionOracle();
            rep = new RepositorioPagos(coneccion);
        }
        public Response<Pago> Actualizar(Pago entidad, int id)
        {
            try
            {
                return rep.Update(entidad, id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Response<Pago> Crear(Pago entidad)
        {
            try
            {
                if (true)
                {

                }
                return rep.Insert(entidad);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Response<Pago> Eliminar(int id)
        {
            try
            {
                return rep.Delete(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Pago> GetAll()
        {
            var lista = rep.GetAll();
            if (lista == null)
            {
                return null;
            }
            return lista;
        }

        public List<Pago> GetListBySearch(string search)
        {
            try
            {
                return GetAll().FindAll(item => item.Id.ToString().StartsWith(search));
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<Pago> GetListBySearchPG(string search)
        {
            try
            {
                return GetHistorial().FindAll(item => item.Id.ToString().StartsWith(search));
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Pago GetObjectById(string id)
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
        public List<Pago> GetHistorial()
        {
            rep.HistorialAccess();
            var lista = rep.GetAll();
            if (lista == null)
            {
                return null;
            }
            return lista;
        }
    }
}
