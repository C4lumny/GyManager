﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Supervisoress : Personas
    {
        public Supervisoress() {
            List<Turno_Atencion> turnos = new List<Turno_Atencion>();
        }

        public Supervisoress(string id, string nombre, string apellido, string genero, string telefono, DateTime fecha_nacimiento, string correo, DateTime fecha_ingreso)
            : base(id, nombre, apellido, genero, telefono, fecha_nacimiento, fecha_ingreso)
        {
            Correo = correo;
            List<Turno_Atencion> turnos = new List<Turno_Atencion>();
        }

        public string Correo { get; set; }

        public override string ToString()
        {
            return $"{Id};{Nombre};{Apellido};{Genero};{Telefono};{Fecha_nacimiento};{Correo};{Fecha_ingreso}";
        }
    }
}
