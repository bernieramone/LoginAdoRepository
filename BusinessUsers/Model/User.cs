namespace BusinessUsers.Model
{
    public class User
    {
        public int ID { get; set; }
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int status { get; set; }
        public string securityKey { get; set; }

    }
}
