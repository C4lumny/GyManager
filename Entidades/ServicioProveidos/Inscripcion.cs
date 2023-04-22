using System;

namespace Entidades
{
    public class Inscripcion
    {
        public Inscripcion() { }
        public Inscripcion(string id, DateTime fecha_inicio, DateTime fecha_finalizacion, double precio,  double descuento, Cliente cliente, PlanGimnasio plan, Supervisor supervisor, bool estado)
        {
            this.id = id;
            this.fecha_inicio = fecha_inicio;
            this.fecha_finalizacion = fecha_finalizacion;
            this.precio = precio;
            this.descuento = descuento;
            this.cliente = cliente;
            this.plan = plan;
            this.supervisor = supervisor;
            this.estado = estado;
        }
        public Inscripcion(Inscripcion inscripcion)
        {
            id = inscripcion.id;
            fecha_inicio = inscripcion.fecha_inicio;
            fecha_finalizacion = inscripcion.fecha_finalizacion;
            precio = inscripcion.precio;
            descuento = inscripcion.descuento;
            cliente = inscripcion.cliente;
            plan = inscripcion.plan;
            supervisor = inscripcion.supervisor;
            estado = inscripcion.estado;
        }
        public string id { get; set; }
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
            return $"{id};{fecha_inicio};{fecha_finalizacion};{precio};{descuento};{cliente.ToString()};{plan.ToString()};{supervisor.ToString()};{estado}";
        }
    }
}
