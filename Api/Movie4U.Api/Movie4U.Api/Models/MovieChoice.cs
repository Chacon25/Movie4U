using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie4U.Api.Models
{
    public class MovieChoice
    {
        public int Id { get; set; }
        public string title { get; set; }

        public List<int> genre_ids { get; set; }
    
    }
}
