using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Operaciones.AccesoPublico
{
    public class Public_Inscripciones : Protected_Inscripciones
    {
        public Public_Inscripciones()
        {
           
        }
        public List<Inscripcion> GetListaVigentes()
        {
            if (GetMainList() == null)
            {
                return null; // Si esta vacia retorna null.
            }
            else
            {
                ValidateStatus();
                var listaVigente = GetMainList().FindAll(item => item.estado == true);  // FindAll devuelve una lista de contratos que cumplan la condicion del predicado, en este caso, retorna los contratos tal que su estado sea true.
                listaVigente.Sort((p1, p2) => p1.id.CompareTo(p2.id));

                return listaVigente; // retorna lista de contratos vigentes.
            }
        }
        public Inscripcion ReturnFromList(string id_inscripcion)
        {
            return GetMainList().FirstOrDefault(item => item.id == id_inscripcion);
        }
        public List<Cliente> ClientesPorSupuervisor(Supervisor supervisor)
        {
            var list = GetMainList();
            if (list != null)
            {
                List<Cliente> list_cliente = new List<Cliente>();
                foreach (var item in list)
                {
                    if (item.supervisor.id == supervisor.id)
                    {
                        list_cliente.Add(item.cliente);
                    }
                }
                return list_cliente;
            }
            else
            {
                return null;
            }    
        }
        
    }
}
