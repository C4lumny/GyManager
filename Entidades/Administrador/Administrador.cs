namespace Entidades.Administrador
{
    public class Administrador
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Administrador() { }

        public Administrador(string nickName, string password)
        {
            this.UserName = nickName;
            this.Password = password;
        }
        public override string ToString()
        {
            return $"{UserName};{Password}";
        }
    }
}
