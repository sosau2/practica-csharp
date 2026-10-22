using Microsoft.AspNetCore.Mvc;
using Billetaje.Models;

namespace Billetaje.Controllers;

public class TarjetasController : Controller
{
    public IActionResult Index()
    {
        List<Tarjeta> tarjetas = new List<Tarjeta>
        {
            new Tarjeta { Numero = "0001", Titular = "Lucia" , Saldo = 12144},
            new Tarjeta { Numero = "0002", Titular = "Mateo" , Saldo = 12144},
            new Tarjeta { Numero = "0003", Titular = "Rosa" , Saldo = 12144},
            new Tarjeta { Numero = "0004", Titular = "Carlos" , Saldo = 12144},
        };
        return View(tarjetas);
    }
}