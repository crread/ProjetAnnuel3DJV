namespace Entity
{
    public class LoginEntity 
    {
        public string email;
        public string password;

        public LoginEntity(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
    }
}
