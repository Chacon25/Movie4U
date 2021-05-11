using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie4U.Core.Entities
{
    public class User : BaseEntity
    {
        public User()
        {
            Choices = new List<Choice>();
        }
        public string Name { get; set; }

        public string User_Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ICollection<Choice> Choices { get; set; }

    }
}
