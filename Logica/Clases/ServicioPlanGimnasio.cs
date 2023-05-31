using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Archivos.Repositorio;
using Datos;

namespace Logica.Clases
{
    public class ServicioPlanGimnasio
    {
        RepositorioPlan rep = new RepositorioPlan();
        public string Actualizar(PlanGimnasio entidad, int id)
        {
            return rep.Update(entidad, id);
        }

        public string Crear(PlanGimnasio entidad)
        {
            return rep.Insert(entidad).Msg;
        }

        public string Eliminar(int id)
        {
            return rep.Delete(id);
        }

        public List<PlanGimnasio> Leer()
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
