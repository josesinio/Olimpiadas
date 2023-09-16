using Aplicacion.Persistencia;
using Aplicacion.ViewModels;
using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacion.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PacienteController : ControllerBase
{
    public AplicacionDbContext contexto { get; }
    public PacienteController(AplicacionDbContext contexto)
    {
        this.contexto = contexto;
    }

    [HttpGet]
    public ActionResult Get()
    {
        var  pacientes = contexto.Pacientes;
        return Ok(pacientes);
    }

    [HttpGet("{id:Guid}")]
    public ActionResult Get(Guid id)
    {
        var paciente = contexto.Pacientes.FirstOrDefault(x => x.IdPaciente == id);
        return Ok(paciente);
    }

        [HttpPost]
    public ActionResult Post([FromBody] PacienteVM paciente)
    {
        var  nuevopaciente = new Paciente(idPaciente: new Guid(), paciente.NroDNI, paciente.NroAfiliado, fechaIngreso: DateTime.Now);
        contexto.Add(nuevopaciente);
        contexto.SaveChanges();
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpDelete("{id:Guid}")]
    public ActionResult Delete(Guid id)
    {
        var pacienteBorrar = contexto.Pacientes.FirstOrDefault(x => x.IdPaciente == id);

        if (pacienteBorrar is null)
            throw new Exception("no existe una llamada con ese Id.");

        contexto.Pacientes.Remove(pacienteBorrar);
        contexto.SaveChanges();
        return Ok();
    

}
}

