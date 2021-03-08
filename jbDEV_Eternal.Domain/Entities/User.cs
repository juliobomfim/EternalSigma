using System.Collections.Generic;

namespace jbDEV_Eternal.Domain.Entities
{
    public class User : Entity
    {
        public User(string name, string email, string password, decimal eternalPoints, bool active)
        {
            Name = name;
            Email = email;
            Password = password;
            EternalPoints = eternalPoints;
            Active = active;
        }

        protected User()
        {
            Characters = new List<Character>();
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal EternalPoints { get; set; }
        public bool Active { get; set; }
        public ICollection<Character> Characters { get; set; }
    }
}
