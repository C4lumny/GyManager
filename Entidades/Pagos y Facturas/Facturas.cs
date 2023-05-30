using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Pagos_y_Facturas
{
    public class Facturas
    {
        public int Id { get; set; }
        public decimal? PagoIngresado { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? Saldo { get; set; }
        public int IdInscripcion { get; set; }
        public Facturas()
        {
        }
        public Facturas(int id, decimal? pagoIngresado, decimal? subtotal, decimal? saldo, int idInscripcion)
        {
            Id = id;
            PagoIngresado = pagoIngresado;
            Subtotal = subtotal;
            Saldo = saldo;
            IdInscripcion = idInscripcion;
        }
        public override string ToString()
        {
            return $"{Id};{PagoIngresado};{Subtotal};{Saldo};{IdInscripcion}";
        }
    }

}
