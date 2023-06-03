using Datos;
using Datos.Archivos;
using Datos.Archivos.Repositorio;
using Entidades;
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
        public string Actualizar(Pago entidad, int id)
        {
            return rep.Update(entidad, id);
        }

        public string Crear(Pago entidad)
        {
            return rep.Insert(entidad).Msg;
        }

        public string Eliminar(int id)
        {
            return rep.Delete(id);
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
            throw new NotImplementedException();
        }

        public Pago GetObjectById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
