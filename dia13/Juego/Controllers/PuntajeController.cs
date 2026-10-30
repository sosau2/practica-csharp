using Juego.Data;
using Juego.Models;
using Microsoft.AspNetCore.Mvc;

namespace Juego.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PuntajeController:ControllerBase
{
    private readonly SupabaseCliente _supabase;

    private readonly string _tabla = "puntajes";    
    private readonly string _limite = "50";

    public PuntajeController(SupabaseCliente supabase)
    {
        _supabase = supabase;
    }

    [HttpGet]
    public async Task<List<Puntaje>> Listar()
    {        
        return await _supabase.Listar<Puntaje>($"{_tabla}?select=*&order=puntos.desc&limit={_limite}");
    }
    
    [HttpPost]
    public async Task<IActionResult> Insertar(Puntaje puntaje)
    {
        await _supabase.Insertar(_tabla,puntaje);
        return StatusCode(StatusCodes.Status201Created);
    }

}