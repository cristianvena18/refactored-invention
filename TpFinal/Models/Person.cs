using System;
using System.ComponentModel.DataAnnotations;

namespace TpFinal.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo es requerido")]
        public string Name { get; set; }

        [Display(Name = "Fecha de nacimiento")]
        [Required(ErrorMessage = "El campo es requerido")]
        public DateTime Birthdate { get; set; }

        [Display(Name = "Biografia")]
        [Required(ErrorMessage = "El campo es requerido")]
        public string Biography { get; set; }

        [Display(Name = "Foto de persona")]
        public string Photo { get; set; }
    }
}
