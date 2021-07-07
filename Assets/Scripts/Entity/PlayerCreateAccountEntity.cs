using System;

namespace Entity
{
    public class PlayerCreateAccountEntity
    {
        public string email;
        public string password;
        public string name;

        public PlayerCreateAccountEntity(string email, string password)
        {
            this.email = email;
            this.password = password;
            name = "lel";
        }
    }
}
