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
            return lista.OfType<Cliente>().ToList();  // retorna la lista de los clientes de la clase Listas.
        }
        protected override bool Exist(string id_cliente)
        {
            if (GetMainList().FirstOrDefault(item => item.id == id_cliente) != null) // valida si el objeto esta en retepitdo (el metodo FirstOrDeafult() devuelve el valor predeterminado si no lo encuentra, en el caso de objetos es null.
            {
                return true; // encontro una id existente.
            }
            return false; // no encontro.
        }
        protected double CalculateIMC(double peso, double altura)
        {
            return peso / (altura * altura);
        }
    }
}
