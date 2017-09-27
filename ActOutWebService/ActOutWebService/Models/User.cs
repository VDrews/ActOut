namespace ActOutWebService.Models
{
    //Tabla de Usuarios
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int Type { get; set; }

        public string EstadoActual { get; set; }
    }
}