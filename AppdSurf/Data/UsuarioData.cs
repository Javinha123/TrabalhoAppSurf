using AppdSurf.Model;
using SQLite;

namespace AppdSurf.Data
{
    public class UsuarioData
    {
        private SQLiteAsyncConnection _conexaoDb;

        public UsuarioData(SQLiteAsyncConnection conexaoDb)
        {
            _conexaoDb = conexaoDb;
        }

        public Task<List<Usuario>> GetUsuariosAsync()
        {
            var lista = _conexaoDb
                .Table<Usuario>()
                .ToListAsync();
            return lista;
        }

        public Task<Usuario> ObtemUsuario(string email, string senha)
        {
            var usuario = _conexaoDb
                .Table<Usuario>()
                .Where(u => u.Email == email  && u.Senha == senha)
                .FirstOrDefaultAsync();
            return usuario;
        }

        public Task<Usuario> RecuperaUsuario(string email, string nome)
        {
            var usuario = _conexaoDb
                .Table<Usuario>()
                .Where(u => u.Email == email && u.Nome == nome)
                .FirstOrDefaultAsync();
            return usuario;
        }

        public Task<Usuario> ObtemIdUsuario(Guid id)
        {
            var usuario = _conexaoDb
                .Table<Usuario>()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return usuario;
        }

        public async Task<int> SalvarUsuario(Usuario usuario)
        {
            var novoUsuario = await ObtemIdUsuario(usuario.Id);

                if(novoUsuario == null)
            {
                return await _conexaoDb.InsertAsync(usuario);
            }
            else
            {
                return await _conexaoDb.UpdateAsync(usuario);
            }
        }
    }
}
