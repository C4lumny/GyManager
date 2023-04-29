﻿using System;

namespace Entidades
{
    public class Inscripcion
    {
        public Inscripcion() 
        { 
            cliente = new Cliente();
            supervisor = new Supervisor();
            plan = new PlanGimnasio();
        }
        public Inscripcion(string id, DateTime fecha_inicio, DateTime fecha_finalizacion, double precio,  double descuento, Cliente cliente, PlanGimnasio plan, Supervisor supervisor, bool estado)
        {

            Id = id;
            Fecha_inicio = fecha_inicio;
            Fecha_finalizacion = fecha_finalizacion;
            Precio = precio;
            Descuento = descuento;
            this.cliente = cliente;
            this.plan = plan;
            this.supervisor = supervisor;
            Estado = estado;
        }
        public string Id { get; set; }
        public DateTime Fecha_inicio { get; set; }
        public DateTime Fecha_finalizacion { get; set; }
        public double Precio { get; set; }
        public double Descuento { get; set; }
        public bool Estado { get; set; }
        public Cliente cliente { get; set; }
        public PlanGimnasio plan { get; set; }
        public Supervisor supervisor { get; set;}
        public override string ToString()
        {
            return $"{Id};{Fecha_inicio};{Fecha_finalizacion};{Precio};{Descuento};{cliente.Id};{plan.Id};{supervisor.Id};{Estado}";
        }
        public string ToFullString()
        {
            return $"{Id};{Fecha_inicio};{Fecha_finalizacion};{Precio};{Descuento};{Estado};{cliente.ToString()};{plan.ToString()};{supervisor.ToFullString()}";
        }
    }
}
