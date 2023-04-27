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
                return null; 
            }
            else
            {
                ValidateStatus();
                var listaVigente = GetMainList().FindAll(item => item.estado == true); 
                listaVigente.Sort((p1, p2) => p1.id.CompareTo(p2.id));

                return listaVigente;
            }
        }
        public Inscripcion ReturnFromList(string id_inscripcion)
        {
            try
            {
                return GetMainList().FirstOrDefault(item => item.id == id_inscripcion);
            }
            catch (Exception)
            {

                return null;
            }
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
        public List<Inscripcion> Historial()
        {
            
            var lista = ar_historial.Load();
            if (lista == null)
            {
                return null;
            }
            else
            {
                foreach (var item in lista)
                {
                    if (DateTime.Now >= item.fecha_finalizacion)
                    {
                        item.estado = false;
                    }
                }
                ar_historial.Update(lista);
                return lista;
            }
        }
    }
}
