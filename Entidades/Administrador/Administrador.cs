using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Administrador
{
    public class Administrador
    {
        public string NickName { get; set; }
        public string Password { get; set; } 
        public Administrador() { }

        public Administrador(string nickName, string password)
        {
            this.NickName = nickName;
            this.Password = password;
        }
        public override string ToString() 
        { 
            return $"{NickName};{Password}";   
        }
    }
}
