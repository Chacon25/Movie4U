using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie4U.Core.Entities
{
    public class Genre : BaseEntity
    {

        public Genre()
        {
            Movies = new List<Movie>();
            Choices = new List<Choice>();
        }

        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }

        public ICollection<Choice> Choices { get; set; }

      
    }
}
