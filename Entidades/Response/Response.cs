using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Response<T>
    {
        public Response(bool success, string msg)
        {
            Success = success;
            Msg = msg;
            List = null;
            Object = default(T);
        }

        public Response(bool success, string msg, List<T> list, T @object)
        {
            Success = success;
            this.Msg = msg;
            List = list;
            Object = @object;
        }
        public bool Success { get; set; }
        public string Msg { get; set; }
        public List<T> List { get; set; }
        public T Object { get; set; }
    }
}
