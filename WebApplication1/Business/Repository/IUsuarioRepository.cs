

using SeriesApp.Business.Entities;

namespace SeriesApp.Business.Repository
{
    public interface IUsuarioRepository
    {
        void Adicionar(Usuario usuario);
        void Commit();
        Usuario ObterUsuario(string login);
    }
}
