
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.IRepositorio;
using Web.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Web.Repositorio
{
    public class Equipo_Repositorio : IEquipo
    {
        private readonly ObjectContext context = null; 

        public Equipo_Repositorio(IOptions<Settings> settings)
        {
            context = new ObjectContext(settings);
        }

        public async Task Add(EquipoModel equipo)
        {
            await context.Equipos.InsertOneAsync(equipo);
        }

        public async Task<IEnumerable<EquipoModel>> Get()
        {
            return await context.Equipos.Find(x => true).ToListAsync();
        }

        public async Task<EquipoModel> Get(string _id)
        {
            return await context.Equipos.Find(Builders<EquipoModel>.Filter.Eq("Id", _id)).FirstOrDefaultAsync();
        }

        public async Task<DeleteResult> Remove(string _id)
        {
            return await context.Equipos.DeleteOneAsync(Builders<EquipoModel>.Filter.Eq("Id", _id));
        }

        public async Task<DeleteResult> RemoveAll()
        {
            return await context.Equipos.DeleteManyAsync(new BsonDocument());
        }

        public async Task<ReplaceOneResult> Update(string _id, EquipoModel equipo)
        {
            return await context.Equipos.ReplaceOneAsync(o => o.Id.Equals(_id), equipo);
        }
    }
}
