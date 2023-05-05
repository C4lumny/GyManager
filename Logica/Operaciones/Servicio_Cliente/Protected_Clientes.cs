using Datos;
using Entidades;
using Logica.Operaciones.AccesoProtegido;
using System.Collections.Generic;
using System.Linq;

namespace Logica.Operaciones
{
    public class Protected_Clientes : Abs_ProtectedClass<Cliente>
    {
        protected RepositorioClientes Repositorio_Clientes;
        protected Protected_Clientes()
        { 
            Repositorio_Clientes = new RepositorioClientes();
        }
        protected override List<Cliente> GetMainList()
        {
            var Clientes = Repositorio_Clientes.Load();
            if (Clientes == null)
            {
                return null;
            }
            return Clientes;
        }
        protected override bool Exist(string id_cliente)
        {
            if (GetMainList().FirstOrDefault(item => item.Id == id_cliente) != null)
            {
                return true;
            }
            return false;
        }
        protected double CalculateIMC(Cliente cliente)
        {
            return cliente.Peso / (cliente.Altura * cliente.Altura);
        }
    }
}
