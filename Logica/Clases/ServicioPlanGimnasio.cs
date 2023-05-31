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
    public class ServicioPlanGimnasio : ICRUD<PlanGimnasio>
    {
        RepositorioPlan rep = new RepositorioPlan();
        public void Actualizar(PlanGimnasio entidad, int id)
        {
            rep.Update(entidad, id);
        }

        public void Crear(PlanGimnasio entidad)
        {
            rep.Insert(entidad);
        }

        public void Eliminar(int id)
        {
            rep.Delete(id);
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
