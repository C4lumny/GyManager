using System;

namespace Entidades
{
    public class Inscripcion
    {
        public Inscripcion() { }
        public Inscripcion(string id, DateTime fecha_inicio, DateTime fecha_finalizacion, double descuento, Cliente cliente, PlanGimnasio plan, Supervisor supervisor, bool estado)
        {
            Id = id;
            this.fecha_inicio = fecha_inicio;
            this.fecha_finalizacion = fecha_finalizacion;
            this.precio = precio;
            this.descuento = descuento;
            this.cliente = cliente;
            this.plan = plan;
            this.supervisor = supervisor;
            this.estado = estado;
        }
        public Inscripcion(Inscripcion inscripcion_caducada)
        {
            this.inscripcion_caducada = inscripcion_caducada;
        }
        public Inscripcion inscripcion_caducada  { get; set; }
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
