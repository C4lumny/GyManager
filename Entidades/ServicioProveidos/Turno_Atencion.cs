using System;

namespace Entidades
{
    //public class Turno_Atencion
    //{
    //    public string Jornada { get; set; } 
    //    public DateTime Hora_Inicio { get; set; }
    //    public DateTime Hora_Salida { get; set; }
    //    public string Dia { get; set; }
    //    public string Id_supervisor { get; set; }
    //    public Turno_Atencion(string id_supervisor, string dia, DateTime hora_Inicio, DateTime hora_Salida)
    //    {
    //        this.Id_supervisor = id_supervisor;
    //        this.Dia = dia;
    //        Hora_Inicio = hora_Inicio;
    //        Hora_Salida = hora_Salida;
    //        Jornada = CalculateJornada();
    //    }
    //    string CalculateJornada()
    //    {
    //        if (Hora_Inicio.TimeOfDay > new TimeSpan(11, 0, 0) && Hora_Inicio.TimeOfDay < new TimeSpan(19, 0, 0))
    //        {
    //            return "Tarde";
    //        }
    //        else if (Hora_Inicio.TimeOfDay >= new TimeSpan(19, 0, 0))
    //        {
    //            return "Noche";
    //        }
    //        else
    //        {
    //            return "Mañana";
    //        }
    //    }
    //    public override string ToString()
    //    {
    //        return $"{Id_supervisor};{Dia};{Hora_Inicio.ToShortTimeString()};{Hora_Salida.ToShortTimeString()}";
    //    }
    //}

    public class Turno_Atencion
    {
        public Turno_Atencion()
        {
            
        }
        public int Id { get; set; }
        public string Dia { get; set; }
        public DateTime HoraEntrada { get; set; }
        public DateTime HoraSalida { get; set; }

        public override string ToString()
        {
            return $"{Id};{Dia};{HoraEntrada};{HoraSalida}";
        }
    }

}
