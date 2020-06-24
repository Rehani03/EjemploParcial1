using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcialEjemplo.Models
{
    public class Empleado
    {
        [Key]
        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        [Range(0, 1000, ErrorMessage =("El rango es de 0 a 1000"))]
        public int empleadoId { get; set; }
        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        [MinLength(3, ErrorMessage ="El minimo de caracteres es 3")]
        [MaxLength(30, ErrorMessage = "El maximo de caracteres es 30")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        [Range(1,1000000, ErrorMessage =("El maximo es 1000000"))]
        public decimal sueldo { get; set; }
        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public int ocupacion { get; set; }
        public DateTime fecha { get; set; }
        [Required(ErrorMessage = "Este campo no puede estar vacio")]
        [MinLength(11, ErrorMessage = "Complete los 11 numeros de la cedula")]
        [Phone(ErrorMessage ="Debe ser numerico")]
        public string cedula { get; set; }
        public bool estado { get; set; }

        public Empleado()
        {
            empleadoId = 0;
            nombre = string.Empty;
            sueldo = 0;
            ocupacion = 0;
            fecha = DateTime.Now;
            cedula = string.Empty;
            estado = false;
            
        }
    }
}
