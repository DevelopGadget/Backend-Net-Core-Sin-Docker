using Web.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.IRepositorio
{
    public interface IJugadores
    {
        Task<IEnumerable<JugadoresModel>> Get();
        Task<JugadoresModel> Get(string _id);
        Task Add(JugadoresModel Equipos);
        Task<ReplaceOneResult> Update(string _id, JugadoresModel Equipos);
        Task<DeleteResult> Remove(string _id);
        Task<DeleteResult> RemoveAll();
    }
}