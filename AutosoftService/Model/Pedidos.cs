using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutosoftService.Model
{
    public class Pedidos
    {
        [Key]

        public int PedidoId { get; set; }
        public int ProveedorId { get; set; }
        public string Categoria { get; set; }
        public string Nota { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaEntrega { get; set; }



        [ForeignKey("PedidoId")]
        public virtual List<PedidoD> Pedido_Detalle { get; set; } = new List<PedidoD>();

        public Pedidos()
        {
            PedidoId = 0;
            ProveedorId = 0;
            Categoria = string.Empty;
            Nota = string.Empty;
            Fecha = DateTime.Now;
            FechaEntrega = DateTime.Now.AddDays(15);
            Pedido_Detalle = new List<PedidoD>();


        }
    }
}
