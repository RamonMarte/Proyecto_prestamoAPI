using Microsoft.EntityFrameworkCore;
using proyect_prestamo.Data;
using proyect_prestamo.Modelos;

namespace proyect_prestamo.Services
{
    public class UsuarioService : IUsuarioServices
    {
        private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<string> Register(RegistrosUsuarios usuarioDto)
        {

            try
            {
                // 1. Verificar si el email ya existe
                if (await _context.Usuarios.AnyAsync(u => u.Email == usuarioDto.Email))
                    return "El correo electrónico ya está registrado.";

                // 2. CRUCIAL: Hashing de la contraseña
                // Genera el hash de la contraseña usando BCrypt
                string contrasenaHash = BCrypt.Net.BCrypt.HashPassword(usuarioDto.Password);

                // 3. Crear el objeto Usuario con el hash
                var nuevoUsuario = new Usuarios
                {
                    Nombre = usuarioDto.Nombre,
                    Email = usuarioDto.Email,
                    Password = contrasenaHash// Guardamos el HASH
                };

                // 4. Guardar el usuario en la base de datos
                _context.Usuarios.Add(nuevoUsuario);
                await _context.SaveChangesAsync();

                return $"Usuario {usuarioDto.Nombre} agregado correctamente";


            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<Usuarios> GetById(int id)
        {
            try
            {
                var response = await _context.Usuarios.FindAsync(id);

                if(response == null)
                    throw new Exception("Usuario no encontrado");

                return response;

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Usuarios>> GetAll()
        {
            try
            {
                var response = await _context.Usuarios.ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> Delete(int id)
        {
            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                    return "Usuario no encontrado";
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
                return $"Usuario con ID {id} eliminado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<Usuarios> Update(int id, RegistrosUsuarios usuarioDto)
        {
            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);
                if (usuario == null)
                    throw new Exception("Usuario no encontrado");
                usuario.Nombre = usuarioDto.Nombre;
                usuario.Email = usuarioDto.Email;
                // Actualizar la contraseña si se proporciona una nueva
                if (!string.IsNullOrEmpty(usuarioDto.Password))
                {
                    usuario.Password = BCrypt.Net.BCrypt.HashPassword(usuarioDto.Password);
                }
                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
