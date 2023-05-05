using Datos.Archivos;
using Entidades;
using System;
using System.Collections.Generic;
using System.IO;

namespace Datos
{
    public class RepositorioPlan : Abs_Repositorio<PlanGimnasio>
    {
        protected string ruta = "Planes .txt"; 
        public RepositorioPlan()
        {
            Ruta(ruta);
        }

        public override PlanGimnasio Mapper(string linea)
        {
            try
            {
                var aux = linea.Split(';');
                PlanGimnasio plan = new PlanGimnasio();
                plan.Id = aux[0];
                plan.Nombre = aux[1];
                plan.Precio = double.Parse(aux[2]);
                plan.Descripcion = aux[3];
                plan.Dias = int.Parse(aux[4]);
                return plan;
            }
            catch (Exception) { }
            return null;
        }

    }
}
