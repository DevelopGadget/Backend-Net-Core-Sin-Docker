using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Web.Models
{
    public class ObjectContext
    {
        public IConfigurationRoot Configuration { get; set; }
        private IMongoDatabase _database = null;

        public ObjectContext(IOptions<Settings> Setting)
        {

            Configuration = Setting.Value.configuration;
            Setting.Value.ConectionString = Configuration.GetSection("MongoConection:ConectionMlab1").Value;
            Setting.Value.Database = Configuration.GetSection("MongoConection:Database").Value;

            var Client = new MongoClient(Setting.Value.ConectionString);
            if (Client != null) { _database = Client.GetDatabase(Setting.Value.Database); }

        }
            public IMongoCollection<EquipoModel> Equipos
            {
                get { return _database.GetCollection<EquipoModel>("Equipos"); }
            }

            public IMongoCollection<JugadoresModel> Jugadores
            {
                get { return _database.GetCollection<JugadoresModel>("Jugadores"); }
            }

    }
      
}
    
