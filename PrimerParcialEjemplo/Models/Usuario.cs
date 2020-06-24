using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcialEjemplo.Models
{
    public class Usuario
    {
        [Key]
        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        [Range(0, 1000, ErrorMessage = ("El rango es de 0 a 1000"))]
        public int usuarioId { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        [MinLength(3, ErrorMessage = "El minimo de caracteres es 3")]
        [MaxLength(30, ErrorMessage = "El maximo de caracteres es 30")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public int nivel { get; set; }
        
        public DateTime fecha { get; set; }

        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public string contraseña { get; set; }

        public Usuario()
        {
            usuarioId = 0;
            nombre = string.Empty;
            nivel = 0;
            contraseña = string.Empty;
        }
    }
}
