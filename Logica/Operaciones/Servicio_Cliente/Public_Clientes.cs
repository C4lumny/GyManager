using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Operaciones.AccesoPublico
{
    public class Public_Clientes : Protected_Clientes
    {
        public Public_Clientes()
        {

        }
        public Cliente ReturnFromList(string id_cliente)
        {
            try
            {
                return GetMainList().FirstOrDefault(item => item.id == id_cliente); 
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
