using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcConcesionaria.Models;

public class MarcaVehiculosVM
{
    public List<Vehiculo>? Vehiculos { get; set; }
    public SelectList? Marcas { get; set; }
    public string? MarcaVehiculo { get; set; }
    public string? SearchString { get; set; }
}
