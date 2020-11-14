﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TpFinal.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public string Photo { get; set; }
        public string Trailer { get; set; }
        public string Summary { get; set; }
        public string Genre { get; set; }
    }
}
