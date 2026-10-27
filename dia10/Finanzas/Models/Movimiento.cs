
using System.ComponentModel.DataAnnotations;

namespace Finanzas.Models;
public class Movimiento
{
    public int Id {get;set;}
    [Display(Name ="Monto (Gs)")]
    [Range(1,10000000,ErrorMessage ="El monto debe ser mayor a cero")]
    public int Monto {get;set;}

    public TipoMovimiento TipoMovimiento {get;set;}
    
    [Display(Name ="Descripcion")]
    [Required(ErrorMessage ="La descricion es obligatoria")]
    [StringLength(200,ErrorMessage ="La descripcion admite solo hasta 200 Caracteres")]
    public string Descripcion {get;set;} = "";    
}