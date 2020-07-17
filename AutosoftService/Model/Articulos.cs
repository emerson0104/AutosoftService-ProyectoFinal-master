using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutosoftService.Model
{
    public class Articulos
    {
        [Key]

        public int ArticuloId { get; set; }

        [Required(ErrorMessage ="Debe elegir una categoria")]
        public string Categoria { get; set; }
        public decimal Existencia { get; set; }
        public decimal Precio { get; set; }
        public DateTime Fecha { get; set; }

        public Articulos()
        {
            ArticuloId = 0;
            Categoria = string.Empty;
            Existencia = 0;
            Precio = 0;
            Fecha = DateTime.Now;
        }
    }
}
