using ChatApi.Data;
using ChatApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class MensajesController : ControllerBase
{
    private readonly SupabaseCliente _supabase;

    public MensajesController(SupabaseCliente supabase)
    {
        _supabase = supabase;
    }
    [HttpGet]
    public async Task<ActionResult<List<Mensaje>>> Listar()
    {
        return await _supabase.Listar<Mensaje>("mensajes?select=*&order=creado.desc&limit=50");

    }
    [HttpPost]
    public async Task<IActionResult> Enviar (Mensaje mensaje)
    {
        await _supabase.Insertar("mensajes",mensaje);
        return StatusCode(StatusCodes.Status201Created);
    }
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Eliminar (int id)
    {
        await _supabase.Eliminar("mensajes",id);
        return StatusCode(StatusCodes.Status202Accepted);
    }
}