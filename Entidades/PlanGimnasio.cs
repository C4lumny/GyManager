using System.Collections.Generic;

namespace Entidades
{
    public class PlanGimnasio
    {
        public PlanGimnasio() {} // Clase PlanesGimnasio, clase independiete
        public PlanGimnasio(string id, string nombre, double precio, string descripcion, int dias)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
            this.descripcion = descripcion;
            this.dias = dias;
        }
        public string id { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public string descripcion { get; set; }
        public int dias { get; set; }
        public override string ToString()
        {
            return $"{id};{nombre};{precio};{descripcion};{dias}";
        }
    }

}
