using Aplicacion.Persistencia;
using Aplicacion.ViewModels;
using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacion.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LlamadaController : ControllerBase
{
    public AplicacionDbContext contexto { get; }
    public LlamadaController(AplicacionDbContext contexto)
    {
        this.contexto = contexto;
    }

    [HttpGet]
    public ActionResult Get()
    {
        var llamadas = contexto.Llamadas;
        return Ok(llamadas);
    }

    [HttpGet("{id:Guid}")]
    public ActionResult Get(Guid id)
    {
        var llamada = contexto.Llamadas.FirstOrDefault(x => x.IdLlamada == id);
        return Ok(llamada);
    }

        [HttpPost]
    public ActionResult Post([FromBody] LlamadaVM llamada)
    {
        var  nuevollamda = new Llamada(idLlamada: new Guid(), llamada.IdAtencion, fechaHora: DateTime.Now);
        contexto.Add(nuevollamda);
        contexto.SaveChanges();
        return StatusCode(StatusCodes.Status201Created);
    }

}
