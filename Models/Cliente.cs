namespace MvcConcesionaria.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public int Dni { get; set; }
        public string? Email { get; set; }
        public string? Direccion { get; set; }
        public int Telefono { get; set; }
        public string? Debe { get; set; }
        public int? IdVehiculoComprado { get; set; }



    }
}
