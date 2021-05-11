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
        }

        public string Name { get; set; }

        public ICollection<Movie> Movies { get; set; }


    }
}
