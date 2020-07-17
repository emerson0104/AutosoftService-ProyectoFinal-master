using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutosoftService.Model
{
    public class FacturaD
    {
        [Key]
        public int Id { get; set; }
        public int FacturaId { get; set; }
        public int ArticuloId { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Importe { get; set; }


        public FacturaD()
        {
            Id = 0;
            FacturaId = 0;
            ArticuloId = 0;
            Descripcion = string.Empty;
            Cantidad = 0;
            Precio = 0;
            Importe = 0;
        }

    }
}
