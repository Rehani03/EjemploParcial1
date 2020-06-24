using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerParcialEjemplo.Models
{
    public class Usuario
    {
        public int usuarioId { get; set; }
        public string nombre { get; set; }
        public int nivel { get; set; }
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
