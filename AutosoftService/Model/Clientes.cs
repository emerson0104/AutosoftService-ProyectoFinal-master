using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutosoftService.Model
{
    public class Clientes
    {
        [Key]

        public int ClienteId { get; set; }

        [Required(ErrorMessage ="Debe ingresar su nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar su cedula")]
        public string Cedula { get; set; }

        [Required(ErrorMessage = "Debe ingresar su telefono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Debe ingresar su direccion")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Debe ingresar su email")]
        public string Email { get; set; }
        public DateTime Fecha { get; set; }

        public Clientes()
        {
            ClienteId = 0;
            Nombre = string.Empty;
            Cedula = string.Empty;
            Telefono = string.Empty;
            Direccion = string.Empty;
            Email = string.Empty; 
            Fecha = DateTime.Now; 
        }
    }
}
