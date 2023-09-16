using Aplicacion.Persistencia;
using Aplicacion.ViewModels;
using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace Aplicacion.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    public AplicacionDbContext contexto { get; }
    public UsuarioController(AplicacionDbContext contexto)
    {
        this.contexto = contexto;
    }

    [HttpGet]
    public ActionResult Get()
    {
        var usuarios = contexto.Usuarios;
        return Ok(usuarios);
    }

    [HttpGet("{id:Guid}")]
    public ActionResult Get(Guid id)
    {
        var usuario = contexto.Usuarios.FirstOrDefault(x => x.IdUsuario == id);
        return Ok(usuario);
    }

        [HttpPost]
    public ActionResult Post([FromBody] UsuarioVM usuario)
    {
        var  nuevoatencion = new Usuario(idUsuario: new Guid(), usuario.IdPersonal, usuario.Matricula, usuario.Email, usuario.Contrasenia, usuario.TipoUsuario);
        contexto.Add(nuevoatencion);
        contexto.SaveChanges();
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:Guid}")]
    public ActionResult Put([FromBody] UsuarioVM usuario, Guid id)
    {
        var usuarioModificar = contexto.Usuarios.FirstOrDefault(x => x.IdUsuario == id);

        if (usuarioModificar is null)
            throw new Exception("no existe un usuario con ese Id.");

        usuarioModificar.ModificarUsuario(usuario.Email, usuario.Contrasenia);
        contexto.SaveChanges();
        return Ok(usuarioModificar);
    }

    [HttpDelete("{id:Guid}")]
    public ActionResult Delete(Guid id)
    {
        var administradorBorrar = contexto.Usuarios.FirstOrDefault(x => x.IdUsuario == id);

        if (administradorBorrar is null)
            throw new Exception("no existe un usuario con ese Id.");

        contexto.Usuarios.Remove(administradorBorrar);
        contexto.SaveChanges();
        return Ok();
    

    }
}
