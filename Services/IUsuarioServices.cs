using proyect_prestamo.Modelos;

namespace proyect_prestamo.Services
{
    public interface IUsuarioServices
    {
        Task<string> Register(RegistrosUsuarios usuarioDto);
        Task<Usuarios> GetById(int id);
        Task<string> Delete(int id);
        Task<Usuarios> Update(int id, RegistrosUsuarios usuarioDto);
        Task <List<Usuarios>> GetAll();

    }

    
}
