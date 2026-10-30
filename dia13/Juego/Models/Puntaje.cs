using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Juego.Models;

public class Puntaje
{   [JsonIgnore(Condition =JsonIgnoreCondition.WhenWritingDefault)]
    public int Id {get;set;}
    [Required]
    [StringLength(30)]
    public string Jugador {get;set;} = "";
    public int Puntos {get;set;}
}