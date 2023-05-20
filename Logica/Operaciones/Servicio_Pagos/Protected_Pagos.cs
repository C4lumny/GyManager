using Entidades;
using Entidades.Pagos_y_Facturas;
using Logica.Operaciones.AccesoProtegido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Operaciones.Servicio_Pagos
{
    public class Protected_Pagos : Abs_ProtectedClass<Pago<Inscripcion>>
    {
        protected override bool Exist(string id)
        {
            throw new NotImplementedException();
        }

        protected override List<Pago<Inscripcion>> GetMainList()
        {
            throw new NotImplementedException();
        }
    }
}
