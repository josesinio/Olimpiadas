using Aplicacion.Persistencia;
using Aplicacion.ViewModels;
using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacion.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AtencionController : ControllerBase
{
    public AplicacionDbContext contexto { get; }
    public AtencionController(AplicacionDbContext contexto)
    {
        this.contexto = contexto;
    }

    [HttpGet]
    public ActionResult Get()
    {
        var atenciones = contexto.Atenciones;
        return Ok(atenciones);
    }

    [HttpGet("{id:Guid}")]
    public ActionResult Get(Guid id)
    {
        var atencion = contexto.Atenciones.FirstOrDefault(x => x.IdAtencion == id);
        return Ok(atencion);
    }

        [HttpPost]
    public ActionResult Post([FromBody] AtencionVM atencion)
    {
        var  nuevoatencion = new Atencion(idAtencion: new Guid(), atencion.IdPaciente, atencion.Matricula, atencion.Descripcion,  DateTime.Now , atencion.NroHabitacion);
        contexto.Add(nuevoatencion);
        contexto.SaveChanges();
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:Guid}")]
    public ActionResult Put([FromBody] AtencionVM atencion, Guid id)
    {
        var atencionModificar = contexto.Atenciones.FirstOrDefault(x => x.IdAtencion == id);

        if (atencionModificar is null)
            throw new Exception("no existe un administrador  con ese Id.");

        atencionModificar.ModificarAtencion(atencion.Matricula, atencion.Descripcion, atencion.NroHabitacion);
        contexto.SaveChanges();
        return Ok(atencionModificar);
    }
    


}


