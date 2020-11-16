using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TpFinal.Models
{
    public class MoviesActors
    {
        public int? FilmId { get; set; }
        public int? PersonId { get; set; }
        public Film Film { get; set; }
        public Person Person { get; set; }
        public string Character { get; set; }
        public int Order { get; set; }
    }
}
