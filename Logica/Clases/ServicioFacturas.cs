﻿using Datos;
using Datos.Archivos;
using Datos.Archivos.Repositorio;
using Entidades.Pagos_y_Facturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    public class ServicioFacturas 
    {
        ConexionOracle coneccion;

        RepositorioFacturas rep;

        public ServicioFacturas()
        {
            coneccion = new ConexionOracle();
            rep = new RepositorioFacturas(coneccion);
        }

        public List<Facturas> GetListBySearch(string search)
        {
            throw new NotImplementedException();
        }

        public Facturas GetObjectById(string id)
        {
            throw new NotImplementedException();
        }

        public List<Facturas> Leer()
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
