using System;

namespace Entity
{
    public class PlayerCreateAccountEntity
    {
        public string email;
        public string password;
        
        public string[] roles;
        public string name;

        public PlayerCreateAccountEntity(string email, string password)
        {
            this.email = email;
            this.password = password;
            roles = new string[1];
            roles[0] = "ROLE_USER";
            name = "lel";
        }
    }
}
