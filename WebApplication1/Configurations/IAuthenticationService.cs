using SeriesApp.Models.Usuarios;

namespace SeriesApp.Configurations
{
    public interface IAuthenticationService
    {
        public string GenerateToken(UsuarioViewModelOutput usuarioViewModelOutput);
    }
}
