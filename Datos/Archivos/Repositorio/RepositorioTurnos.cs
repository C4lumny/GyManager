using Entidades;
using System;
using System.Collections.Generic;
using System.IO;

namespace Datos.Archivos.Repositorio
{
    public class RepositorioTurnos : Abs_Repositorio<Turno_Atencion>
    {

        string ruta = "Turnos.txt";
        public RepositorioTurnos()
        { 
            Ruta(ruta);
        }
        public override Turno_Atencion Mapper(string linea)
        {
            try
            {
                var aux = linea.Split(';');
                var turno = new Turno_Atencion(aux[0], aux[1], DateTime.Parse(aux[2]), DateTime.Parse(aux[3]));
                return turno;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
