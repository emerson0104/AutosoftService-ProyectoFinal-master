using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AutosoftService.Model
{
    public class Facturas
    {
        [Key]
        public int FacturaId { get; set; }
        [ForeignKey("VehiculoId")]
        public int VehiculoId { get; set; }
        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        public string Servicios { get; set; }
        public bool TipoPago { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Itbis { get; set; }
        public decimal Total { get; set; }
        public DateTime ProximoMantemiento { get; set; }
        public DateTime Fecha { get; set; }


        [ForeignKey("FacturaId")]
        public virtual List<FacturaD> Factura_Detalle { get; set; }

        public Facturas()
        {
            FacturaId = 0;
            VehiculoId = 0;
            ClienteId = 0;
            Servicios = string.Empty;
            TipoPago = false;
            SubTotal = 0;
            Itbis = 0;
            Total = 0;
            ProximoMantemiento = DateTime.Now.AddMonths(3);
            Fecha = DateTime.Now;
            Factura_Detalle = new List<FacturaD>();
        }
    }
}
