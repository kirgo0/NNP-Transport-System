using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCL.Security.Identity
{
    public abstract class User
    {
        public int Id { get; }
        public string Name { get; }
        protected string Role { get; }

        public User(int id, string name, string role)
        {
            Id = id;
            Name = name;
            Role = role;
        }

        public string GetRole()
        {
            return Role;
        }
    }
}
