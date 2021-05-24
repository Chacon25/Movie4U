using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie4U.Core.Models
{
    public class Results
    {

        public Results()
        {
            results = new List<MovieDto>();
        }
        public int Page { get; set; }
        public List<MovieDto> results { get; set; }
    }
}
