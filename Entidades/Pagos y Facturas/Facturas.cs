using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Pagos_y_Facturas
{
    public class Facturas
    {
        public int? Id { get; set; }
        public double? PagoIngresado { get; set; }
        public double? Subtotal { get; set; }
        public double? Saldo { get; set; }
        public Inscripcion Inscripcion { get; set; }
        public Facturas()
        {
        }
        public Facturas(int id, double pagoIngresado, double subtotal, double saldo, Inscripcion Inscripcion)
        {
            Id = id;
            PagoIngresado = pagoIngresado;
            Subtotal = subtotal;
            Saldo = saldo;
            this.Inscripcion = Inscripcion;
        }
    }

}
