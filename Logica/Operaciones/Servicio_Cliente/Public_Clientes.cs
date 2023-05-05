using Entidades;
using System;
using System.Linq;

namespace Logica.Operaciones.AccesoPublico
{
    public class Public_Clientes : Protected_Clientes
    {
        public Public_Clientes()
        {

        } 
        public Cliente ReturnCliente(string id_cliente)
        {
            try
            {
                return GetMainList().FirstOrDefault(item => item.Id == id_cliente);
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
