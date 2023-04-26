using Datos;
using Entidades;
using Logica.Operaciones.AccesoProtegido;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Operaciones
{
    public class Protected_Clientes: Abs_ProtectedClass<Cliente>
    {
        protected RepositorioClientes ar_clientes;
        protected Protected_Clientes()
        {
            ar_clientes = new RepositorioClientes();
        }
        protected override List<Cliente> GetMainList()
        {
            var lista = ar_clientes.Load();
            if (lista == null)
            {
                return null;
            }
            return lista;  
        }
        protected override bool Exist(string id_cliente)
        {
            if (GetMainList().FirstOrDefault(item => item.id == id_cliente) != null) 
            {
                return true; 
            }
            return false; 
        }
        protected double CalculateIMC(Cliente cliente)
        {
            return cliente.peso / (cliente.altura * cliente.altura);
        }
    }
}
