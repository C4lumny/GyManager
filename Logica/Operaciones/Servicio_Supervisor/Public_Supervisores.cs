using Entidades;
using Logica.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Operaciones.AccesoPublico
{
    public class Public_Supervisores: Protected_Supervisor
    {
        public Public_Supervisores()
        {
        }
        public Supervisor ReturnSupervisorFromList(string id_supervisor)
        {
            try
            {
                return GetMainList().FirstOrDefault(item => item.id == id_supervisor);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public Turno_Atencion ReturnTurnoFromList(string id_supervisor, string dia, DateTime hora)
        {
            try
            {
                return ar_turno.Load().FirstOrDefault((item) => (item.id_supervisor == id_supervisor && item.dia == dia && item.Hora_Inicio == hora) || (item.id_supervisor == id_supervisor && item.dia == dia && item.Hora_Salida == hora));
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
