using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MvcConcesionaria.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(45, MinimumLength = 3)]
        [Required]
        public string? Marca { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(45, MinimumLength = 3)]
        [Required]
        public string? Modelo { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(45, MinimumLength = 3)]
        [Required]
        public string? Color { get; set; }


        [Display(Name = "Año Fabricación")]
        public int AnioFabricacion { get; set; }

        [StringLength(250)]
        public string? Observaciones { get; set; }

        [Range(2, 8)]
        [Display(Name = "Puertas")]
        public int CantPuertas { get; set; }

        [Range(1, 100000000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Precio { get; set; }

        public string? Reservado { get; set; }
        public string? Vendido { get; set; }



    }
}
