using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Pagos_y_Facturas
{
    //public class Pago<T>
    //{
    //    public string Id { get; set; }
    //    public Cliente cliente { get; set; }
    //    public double Valor { get; set; }
    //    public T Producto { get; set; }
    //    public int Cantidad { get; set; }   
    //    public Pago() { }

    //    public Pago(string id, Cliente cliente, T producto, int cantidad)
    //    {
    //        Id = id;
    //        this.cliente = cliente;
    //        Producto = producto;
    //        Cantidad = cantidad;
    //    }
    //    public override string ToString()
    //    {
    //        return $"{Id};{cliente.Id};{Valor};{Producto};{Cantidad}";
    //    }
    //}

    public class Pago
    {
        public Pago()
        {
            Inscripcion = new Inscripcion();    
        }
        public int Id { get; set; }
        public double ValorIngresado { get; set; }
        public DateTime FechaPago { get; set; }
        public Inscripcion Inscripcion { get; set; }
    }

}
