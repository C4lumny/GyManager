using Datos.Archivos;
using Entidades;
using System;
using System.Collections.Generic;
using System.IO;

namespace Datos
{
    public class RepositorioClientes : Abs_Repositorio<Cliente>
    {
        string ruta = "Cliente.txt";
        public RepositorioClientes()
        { 
            Ruta(ruta);
        }
        public override Cliente Mapper(string linea)
        {
            try
            {
                var aux = linea.Split(';');
                Cliente cliente = new Cliente();
                cliente.Id = aux[0];
                cliente.Nombre = aux[1];
                cliente.Genero = aux[2];
                cliente.Telefono = aux[3];
                cliente.Altura = double.Parse(aux[4]);
                cliente.Peso = double.Parse(aux[5]);
                cliente.Imc = double.Parse(aux[6]);
                cliente.Fecha_nacimiento = DateTime.Parse(aux[7]);
                cliente.Discapacidad = aux[8];
                cliente.Fecha_ingreso = DateTime.Parse(aux[9]);
                return cliente;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
