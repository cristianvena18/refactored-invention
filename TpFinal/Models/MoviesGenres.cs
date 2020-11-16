using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TpFinal.Models
{
    public class MoviesGenres
    {
        public int Id { get; set; }
        public int? GenreId { get; set; }
        public int? FilmId { get; set; }
        public Film Film { get; set; }
        public Genre Genre { get; set; }
    }
}
