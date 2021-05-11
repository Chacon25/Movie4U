using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie4U.Core.Entities
{
    public class Choice : BaseEntity
    {

        public Choice()
        {
            Genres = new List<Genre>();
        }
        public int UserId { get; set; }

        public int GenreId { get; set; }

        public ICollection<Genre> Genres { get; set; }
    }
}
