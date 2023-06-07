using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcConcesionaria.Models
{
    public class FiltroClientes
    {
        public List<Cliente>? ListaClientes { get; set; }
        public SelectList? Todos { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
    }
}
