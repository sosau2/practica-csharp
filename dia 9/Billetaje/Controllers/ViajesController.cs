using Microsoft.AspNetCore.Mvc;
using Billetaje.Models;

namespace Billetaje.Controllers;

public class ViajesController : Controller
{
    public IActionResult Index()
    {
        List<Viaje> viajes = new List<Viaje>
        {
            new Viaje {Linea = "Linea 12",NumeroTarjeta = "0001",Monto=6400},
            new Viaje {Linea = "Linea 142",NumeroTarjeta = "0002",Monto=6400},
            new Viaje {Linea = "Linea 122",NumeroTarjeta = "0003",Monto=6400},
            new Viaje {Linea = "Linea 32",NumeroTarjeta = "0004",Monto=6400},
            
            
        };
        return View(viajes);
    }
}