namespace Entidades
{
    public class PlanGimnasio
    {
        public PlanGimnasio() { } 
        public PlanGimnasio(string id, string nombre, double precio, string descripcion, int dias)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            Descripcion = descripcion;
            Dias = dias;
        }
        public string Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string Descripcion { get; set; }
        public int Dias { get; set; }
        public override string ToString()
        {
            return $"{Id};{Nombre};{Precio};{Descripcion};{Dias}";
        }
    }

}
