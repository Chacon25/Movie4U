using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie4U.Core.Models
{
    public class ObjectRecommendationDto
    {
      
        public ICollection<MovieChoice> Choices { get; set; }

        public UserDto User { get; set; }
    }
}
