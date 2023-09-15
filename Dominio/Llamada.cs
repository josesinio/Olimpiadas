namespace Dominio;

public class Llamada
{
    public Guid IdLlamada {get; set; }
    public Guid IdAtencion {get; set; }
    public DateTime FechaHora {get; set; }


    public Llamada(Guid idLlamada, Guid idAtencion, DateTime fechaHora)
    {
        IdLlamada = idLlamada;
        IdAtencion = idAtencion;
        FechaHora = fechaHora;
    }

}
