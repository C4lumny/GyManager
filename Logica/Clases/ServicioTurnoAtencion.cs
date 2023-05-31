using Datos.Archivos;
using Datos.Archivos.Repositorio;
using Entidades;
using Entidades.Informacion_Persona;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica.Clases
{
    public class ServicioTurnoAtencion
    {

        RepositorioTurnos rep = new RepositorioTurnos();

        public ServicioTurnoAtencion()
        {
            
        }
        public string asignar(Turno_Atencion entidad, string id)
        {
            return rep.Asignar(entidad, id).Msg;
        }

        public string eliminar(string id_sup, int id_turno)
        {
            return rep.Delete(id_turno, id_sup);
        }
    }
}
