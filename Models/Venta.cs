using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcConcesionaria.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public int NroFactura { get; set; }
        public decimal ValorVehiculo { get; set; }
        public decimal EntregaCliente { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public string? FormadePago { get; set; }
        public int IdCliente { get; set; }

        [ForeignKey("IdCliente")]
        public virtual Cliente? Cliente { get; set; }
        public int IdVehiculo { get; set; }
        [ForeignKey("IdVehiculo")]
        public virtual Vehiculo? Vehiculo { get; set; }
    }
}
