using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutosoftService.Model
{
    public class Proveedores
    {
        [Key]

        public int ProveedorId { get; set; }

        [Required(ErrorMessage ="Debe ingresar su nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Debe ingresar su telefono")]

        public string Telefono { get; set; }

        [Required(ErrorMessage = "Debe ingresar su email")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Debe ingresar su direccion")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Debe ingresar su RNC")]
        public string RNC { get; set; }
        public int CantidadPedidos { get; set; }
        public DateTime Fecha { get; set; }

        public Proveedores()
        {
            ProveedorId = 0;
            Nombre = string.Empty;
            Telefono = string.Empty;
            Email = string.Empty;
            Direccion = string.Empty;
            RNC = string.Empty;
            CantidadPedidos = 0;
            Fecha = DateTime.Now;
        }
    }
}
