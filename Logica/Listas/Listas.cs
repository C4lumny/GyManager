using Datos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Listas
    {
        // Declaracion estatica para tener la misma instancia de listas en distintas clase.
        RepositorioUsuarios repositorioUsuarios = new RepositorioUsuarios();
        RepositorioPlan repositorioPlanes = new RepositorioPlan();
        RepositorioContratos repositorioContratos = new RepositorioContratos();
        public Listas()
        {
        }
        public List<Cliente> GetListaCliente() // retorna la lista de clientes, al ser publica se puede utilizar en cualquier clase.
        {
            var list = repositorioUsuarios.Load();
            if (list == null) { return null; }

            return list.OfType<Cliente>().ToList(); 
        }
        public List<Supervisor> GetListaSupervisor() // retorna la lista de supervisores, al ser publica se puede utilizar en cualquier clase.
        {
            var list = repositorioUsuarios.Load();
            if (list == null) { return null; }

            return list.OfType<Supervisor>().ToList(); ;
        }
        public List<PlanGimnasio> GetListaPlan() // retorna la lista de planes, al ser publica se puede utilizar en cualquier clase.
        {
            var list = repositorioPlanes.Load(); 
            if (list == null) { return null; }
            return list;
        }
        public List<Inscripcion> GetListaContrato() // retorna la lista de contratos, al ser publica se puede utilizar en cualquier clase.
        {
            var list = repositorioContratos.Load();
            if (list == null) { return null; }
            return list;
        }
    }
}
