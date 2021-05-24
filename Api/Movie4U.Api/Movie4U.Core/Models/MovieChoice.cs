using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie4U.Core.Models
{
    public class MovieChoice
    {

     
        public int Id { get; set; }
        public string Title { get; set; }

        public List<int> genre_ids { get; set; }
        


    }

    public class Dat
    {
        public int Id { get; set; }
        
    }



}
