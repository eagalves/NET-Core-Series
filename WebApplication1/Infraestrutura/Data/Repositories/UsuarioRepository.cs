using SeriesApp.Business.Entities;
using SeriesApp.Business.Repository;
using SeriesApp.Infraestrutura.Data;
using System.Linq;

namespace curso.api.Infraestrutura.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SeriesDbContext _contexto;

        public UsuarioRepository(SeriesDbContext contexto)
        {
            _contexto = contexto;
        }

        public void Adicionar(Usuario usuario)
        {
            _contexto.Usuario.Add(usuario);
        }
        public void Commit() 
        { 
            _contexto.SaveChanges();
        }

        public Usuario ObterUsuario(string login)
        {
            return _contexto.Usuario.FirstOrDefault(u => u.Login == login);
        }
    }
}
