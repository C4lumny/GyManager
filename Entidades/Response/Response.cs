using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Response<T>
    {
        public Response(bool success, string msg, List<T> data, T value)
        {
            this.success = success;
            this.msg = msg;
            this.data = data;
            this.value = value;
        }
        public bool success { get; set; }
        public string msg { get; set; }
        public List<T> data { get; set; }
        public T value { get; set; }
    }
}
