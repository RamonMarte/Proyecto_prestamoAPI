using Microsoft.AspNetCore.Mvc;
using proyect_prestamo.Data;
using proyect_prestamo.Modelos;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using proyect_prestamo.Services;

namespace proyect_prestamo.Controllers
{
    [Route("api/[controller]")] // Ruta base: /api/Usuarios
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly IUsuarioServices _service;

        public UsuariosController(IUsuarioServices service)
        {
            _service = service;
        }

        // POST: /api/Usuarios/registro
        [HttpPost("registro")]
        public async Task<IActionResult> Registro(RegistrosUsuarios usuarioDto)
        {
            var response = await _service.Register(usuarioDto);
            return Ok(response);
        }

        [HttpGet("Obtener")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var response = await _service.GetById( id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPatch("actualizar")]
        public async Task<IActionResult> Update(int id, RegistrosUsuarios usuarioDto)
        {
            try
            {
                var response = await _service.Update(id, usuarioDto);
                    return Ok(response);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("Todo")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var response = await _service.GetAll();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpDelete("Eliminar")]
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                var response = await _service.Delete(id);
                return Ok(response);
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
            
        }
    }
}
