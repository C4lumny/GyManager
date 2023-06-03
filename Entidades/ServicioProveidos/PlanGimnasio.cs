namespace Entidades
{ 
    public class PlanGimnasio
    {
        public PlanGimnasio()
        {
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string Descripcion { get; set; }
        public int Dias { get; set; }
    }
}
