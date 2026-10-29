using ChatApi.Data;
using Juego.Models;
using Microsoft.AspNetCore.Mvc;

namespace Juego.Controllers;

public class PuntajeController:Controller
{
    private readonly SupabaseCliente _supabase;

    private readonly string _tabla = "puntajes";
    private readonly string _orden = "creado";
    private readonly string _limite = "50";

    public PuntajeController(SupabaseCliente supabase)
    {
        _supabase = supabase;
    }

    public async Task<List<Puntaje>> Listar()
    {        
        return await _supabase.Listar<Puntaje>($"{_tabla}?select=*&order={_orden}.desc&limit={_limite}");
    }

    public async Task<List<Puntaje>> ListarPorNombre(string nombre)
    {
        return await _supabase.Listar<Puntaje>($"{_tabla}?select=*&where=nombre.eq={nombre}&order={_orden}.desc&limit={_limite}");
    }
    public async void Insertar(Puntaje puntaje)
    {
        await _supabase.Actualizar(_tabla,puntaje.Id,puntaje);
    }
}