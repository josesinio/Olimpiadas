using Aplicacion.Persistencia;
using Aplicacion.ViewModels;
using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacion.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonalController : ControllerBase
{
    public AplicacionDbContext contexto { get; }
    public PersonalController(AplicacionDbContext contexto)
    {
        this.contexto = contexto;
    }

    [HttpGet]
    public ActionResult Get()
    {
        var personales = contexto.Personales;
        return Ok(personales);
    }

    [HttpGet("{id:Guid}")]
    public ActionResult Get(Guid id)
    {
        var personal = contexto.Personales.FirstOrDefault(x => x.IdPersonal == id);
        return Ok(personal);
    }

        [HttpPost]
    public ActionResult Post([FromBody] PersonalVM personal)
    {
        var  nuevopersonal = new Personal(idPersonal: new Guid(), personal.Nombre, personal.Apellido, personal.Area);
        contexto.Add(nuevopersonal);
        contexto.SaveChanges();
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpDelete("{id:Guid}")]
    public ActionResult Delete(Guid id)
    {
        var personalBorrar = contexto.Personales.FirstOrDefault(x => x.IdPersonal == id);

        if (personalBorrar is null)
            throw new Exception("no existe algun personal con ese Id.");

        contexto.Personales.Remove(personalBorrar);
        contexto.SaveChanges();
        return Ok();
    }
    
}
