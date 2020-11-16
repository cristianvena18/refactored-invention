using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TpFinal.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [Display(Name = "Fecha de lanzamiento")]
        public DateTime ReleaseDate { get; set; }
        public bool Outstanding { get; set; }
        public string Photo { get; set; }
        public string Trailer { get; set; }
        public string Summary { get; set; }
        public int? GenreId { get; set; }
        public Genre Genre { get; set; }
        public List<MoviesGenres> MoviesGenres { get; set; }
    }
}
