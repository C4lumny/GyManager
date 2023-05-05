using Entidades;
using System;
using System.Collections.Generic;
using System.IO;

namespace Datos.Archivos
{
    public class RepositorioSupervisor : Abs_Repositorio<Supervisor>
    {
        string ruta = "Supervisor.txt";
        public RepositorioSupervisor()
        {
            Ruta(ruta);
        }


        public override Supervisor Mapper(string linea)
        {
            try
            {
                var aux = linea.Split(';');
                Supervisor supervisor = new Supervisor();
                supervisor.Id = aux[0];
                supervisor.Nombre = aux[1];
                supervisor.Genero = aux[2];
                supervisor.Telefono = aux[3];
                supervisor.Altura = double.Parse(aux[4]);
                supervisor.Peso = double.Parse(aux[5]);
                supervisor.Fecha_nacimiento = DateTime.Parse(aux[6]);
                supervisor.Fecha_ingreso = DateTime.Parse(aux[7]);
                return supervisor;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
