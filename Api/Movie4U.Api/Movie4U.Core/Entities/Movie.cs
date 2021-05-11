using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie4U.Core.Entities
{
    public class Movie :BaseEntity
    {

        public Movie()
        {
            Genres = new List<Genre>();
        }


        public string Name  { get; set; }

        public ICollection<Genre> Genres { get; set; }

       
    }
}
