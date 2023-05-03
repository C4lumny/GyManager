using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logica.Operaciones.AccesoPublico
{
    public class Public_Inscripciones : Protected_Inscripciones
    {
        public Public_Inscripciones()
        {

        }
        public List<Inscripcion> GetInscripcionesVigentes()
        {
            if (GetMainList() == null)
            {
                return null;
            }
            else
            {
                var Inscripcines_vigentes = GetMainList().FindAll(item => item.Estado == true);
                Inscripcines_vigentes.Sort((p1, p2) => p1.Id.CompareTo(p2.Id));
                return Inscripcines_vigentes;
            }
        }
        public Inscripcion ReturnInscripcion(string id_inscripcion)
        {
            try
            {
                return GetMainList().FirstOrDefault(item => item.Id == id_inscripcion);
            }
            catch (Exception)
            {

                return null;
            }
        }
        public List<Cliente> ClientesPorSupervisor(Supervisor supervisor) // ingresa un supervisor y retorna los clientes asociados por medio de la inscripcion.
        {
            var inscripciones = GetMainList();
            if (inscripciones != null)
            {
                List<Cliente> Clientes = new List<Cliente>();
                foreach (var item in inscripciones)
                {
                    if (item.supervisor.Id == supervisor.Id)
                    {
                        Clientes.Add(item.cliente);
                    }
                }
                if (Clientes.Count <= 0)
                {
                    return null;
                }
                return Clientes;
            }
            else
            {
                return null;
            }
        }
        public List<Inscripcion> Historial_Inscripciones()
        {
            var historial = Repositorio_Historial.Load();
            if (historial == null)
            {
                return null;
            }
            else
            {
                foreach (var item in historial)
                {
                    if (DateTime.Now >= item.Fecha_finalizacion)
                    {
                        item.Estado = false;
                    }
                }
                Repositorio_Historial.Update(historial);
                historial.Sort((x1, x2) => x1.Id.CompareTo(x2.Id));
                return historial;
            }
        }
    }
}
