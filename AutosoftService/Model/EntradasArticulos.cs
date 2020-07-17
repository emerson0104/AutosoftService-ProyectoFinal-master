using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutosoftService.Model
{
    public class EntradasArticulos
    {
        [Key]
        public int EntradasArtId { get; set; }
        public int ArticuloId { get; set; }
        [Required(ErrorMessage ="Debe ingresar la cantidad")]
        public decimal Cantidad { get; set; }
        public DateTime Fecha { get; set; }

        public EntradasArticulos()
        {
            EntradasArtId = 0;
            ArticuloId = 0;
            Cantidad = 0;
            Fecha = DateTime.Now;
        }
    }
}
