using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class User
    {
        public string UserId { get; set; } = string.Empty;

        public string TeamId { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

        public User() { }

        public bool IsRole(params string[] roles)
        {
            foreach (var role in roles)
            {
                if (role.Equals(Role, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
