using System;

namespace Entidades
{
    public class Contrato
    {
        public Contrato() { }
        public Contrato(string id, DateTime fecha_inicio, double descuento, Cliente cliente, PlanGimnasio plan, Supervisor supervisor)
        {
            Id = id;
            this.fecha_inicio = fecha_inicio;
            fecha_finalizacion = fecha_finalizacion;
            this.precio = precio;
            this.descuento = descuento;
            this.cliente = cliente;
            this.plan = plan;
            this.supervisor = supervisor;
            estado = estado;
        }
        public string Id { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_finalizacion { get; set; }
        public double precio { get; set; }
        public double descuento { get; set; }
        public bool estado { get; set; }
        public Cliente cliente { get; set; }
        public PlanGimnasio plan { get; set; }
        public Supervisor supervisor { get; set;}
        public override string ToString()
        {
            return $"{Id};{fecha_inicio.ToShortDateString()};{fecha_finalizacion.ToShortDateString()};{precio};{descuento};{cliente.ToString()};{plan.ToString()};{supervisor.ToString()};{estado}";
        }
    }
}
