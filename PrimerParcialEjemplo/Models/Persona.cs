using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcialEjemplo.Models
{
    public class Persona
    {
        [Key]
        [Required(ErrorMessage ="Este campo no puede estar vacio.")]
        [Range(0,1000, ErrorMessage ="El rango debe ser de 0 a 1000")]
        public int personaId { get; set; }
        [Required(ErrorMessage ="Este campo no puede estar vacio.")]
        public string nombre { get; set;}
        [Required(ErrorMessage = "Este campo no puede estar vacio.")]
        public int profesion { get; set; }
        [DisplayFormat(DataFormatString ="{0:dd,mm,yyyy}")]
        public DateTime fecha { get; set; }
        public bool estadoCivil { get; set; }

        public Persona()
        {
            personaId = 0;
            nombre = string.Empty;
            fecha = DateTime.Now;
            profesion = 0;
            estadoCivil = false;
        }
    }
}
