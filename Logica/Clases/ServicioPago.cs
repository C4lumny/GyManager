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
    public class ServicioPago : ICRUD<Pago>
    {
        RepositorioPagos rep = new RepositorioPagos();

        public void Actualizar(Pago entidad, int id)
        {
            rep.Update(entidad, id);
        }

        public void Crear(Pago entidad)
        {
            rep.Insert(entidad);
        }

        public void Eliminar(int id)
        {
            rep.Delete(id);
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
