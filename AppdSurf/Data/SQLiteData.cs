using AppdSurf.Model;
using SQLite;

namespace AppdSurf.Data
{
    public class SQLiteData
    {
        readonly SQLiteAsyncConnection _conexaoDb;

        public UsuarioData UsuarioDataTable { get; set; }

        public SenhaData SenhaDataTable { get; set; }

        public SQLiteData(String path)
        {
            _conexaoDb = new SQLiteAsyncConnection(path);
            _conexaoDb.CreateTableAsync<Usuario>().Wait();
            UsuarioDataTable = new UsuarioData (_conexaoDb);

            _conexaoDb = new SQLiteAsyncConnection(path);
            _conexaoDb.CreateTableAsync<Senha>().Wait();
            SenhaDataTable = new SenhaData(_conexaoDb);

            _conexaoDb = new SQLiteAsyncConnection(path);
            _conexaoDb.CreateTableAsync<Senha>().Wait();
            SenhaDataTable = new SenhaData(_conexaoDb);
        }

        
    }
}
