using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dominio;
[Table("Llamada")]
public class Llamada
{
    [Key]
    [Required]
    public Guid IdLlamada {get; set; }
    [Key]
    [Required]
    public Guid IdAtencion {get; set; }
    [Required]
    public DateTime FechaHora {get; set; }


    public Llamada(Guid idLlamada, Guid idAtencion, DateTime fechaHora)
    {
        IdLlamada = idLlamada;
        IdAtencion = idAtencion;
        FechaHora = fechaHora;
    }

}
