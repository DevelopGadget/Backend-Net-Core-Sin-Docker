
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Web.IRepositorio;

namespace Web.Repositorio
{
    public class Jugadores_Repositorio : IJugadores
    {
        private readonly ObjectContext context = null; 

        public Jugadores_Repositorio(IOptions<Settings> settings)
        {
            context = new ObjectContext(settings);
        }

        public async Task Add(JugadoresModel equipo)
        {
            await context.Jugadores.InsertOneAsync(equipo);
        }

        public async Task<IEnumerable<JugadoresModel>> Get()
        {
            return await context.Jugadores.Find(x => true).ToListAsync();
        }

        public async Task<JugadoresModel> Get(string _id)
        {
            return await context.Jugadores.Find(Builders<JugadoresModel>.Filter.Eq("Id", _id)).FirstOrDefaultAsync();
        }

        public async Task<DeleteResult> Remove(string _id)
        {
            return await context.Jugadores.DeleteOneAsync(Builders<JugadoresModel>.Filter.Eq("Id", _id));
        }

        public async Task<DeleteResult> RemoveAll()
        {
            return await context.Jugadores.DeleteManyAsync(new BsonDocument());
        }

        public async Task<ReplaceOneResult> Update(string _id, JugadoresModel equipo)
        {
            return await context.Jugadores.ReplaceOneAsync(o => o.Id.Equals(_id), equipo);
        }
    }
}