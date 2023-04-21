﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Persona // Clase Personas, proporciona la mayoria de atributos a la clase Coach y a la clase Clientes de la capa de Entidades.
    {
        public Persona() {}
        public Persona(string id, string nombre, string genero, string telefono, double altura, double peso, DateTime fecha_nacimiento, DateTime fecha_ingreso, bool estado)
        {
            this.id = id;
            this.nombre = nombre;
            this.genero = genero;
            this.telefono = telefono;
            this.altura = altura;
            this.peso = peso;
            this.fecha_nacimiento = fecha_nacimiento;
            this.fecha_ingreso = fecha_ingreso;
            this.estado = estado;
        }
        public String id { get; set; }
        public String nombre { get; set; }
        public String genero { get; set; }
        public String telefono { get; set; }
        public double altura { get; set; }
        public double peso { get; set; }
        public DateTime fecha_nacimiento { get; set; }
        public DateTime fecha_ingreso { get; set; }
        public bool estado { get; set; } 
    }
}
