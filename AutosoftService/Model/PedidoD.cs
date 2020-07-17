using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AutosoftService.Model
{
    public class PedidoD
    {
        [Key]

        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ClienteId { get; set; }
        public int ProveedorId { get; set; }
        public string Categoria { get; set; }
        public string Articulo { get; set; }
        public int Unidad { get; set; }
        public decimal Precio { get; set; }

        public PedidoD()
        {
            Id = 0;
            PedidoId = 0;
            ProveedorId = 0;
            Categoria = string.Empty;
            Articulo = string.Empty;
            Unidad = 0;
            Precio = 0;
        }


    }
}
