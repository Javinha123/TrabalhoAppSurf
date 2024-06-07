using AppdSurf.Model;
using SQLite;

namespace AppdSurf.Data
{
    public class SenhaData
    {
        private SQLiteAsyncConnection _conexaoDb;

        public SenhaData(SQLiteAsyncConnection conexaoDb)
        {
            _conexaoDb = conexaoDb;
        }

        public Task<List<Senha>> GetSenhasAsync()
        {
            var lista = _conexaoDb
                .Table<Senha>()
                .ToListAsync();
            return lista;
        }

        public Task<Senha> ObtemSenha(int numero, string letra)
        {
            var Senha = _conexaoDb
                .Table<Senha>()
                .Where(u =>  u.Letra == letra)
                .FirstOrDefaultAsync();
            return Senha;
        }

        public Task<Senha> ObtemIdSenha(Guid id)
        {
            var Senha = _conexaoDb
                .Table<Senha>()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return Senha;
        }

        public async Task<int> SalvarSenha(Senha Senha)
        {
            var novaSenha = await ObtemIdSenha(Senha.Id);

                if(novaSenha == null)
            {
                return await _conexaoDb.InsertAsync(Senha);
            }
            else
            {
                return await _conexaoDb.UpdateAsync(Senha);
            }
        }
    }
}
