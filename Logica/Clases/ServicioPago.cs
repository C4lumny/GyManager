using Datos;
using Datos.Archivos.Repositorio;
using Entidades.Pagos_y_Facturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    public class ServicioPago 
    {
        RepositorioPagos rep = new RepositorioPagos();

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

        public List<Pago> Leer()
        {
            var lista = rep.GetAll();
            if (lista == null)
            {
                return null;
            }
            return lista;
        }
    }
}
