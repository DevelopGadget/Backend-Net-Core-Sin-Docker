
using Web.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.IRepositorio
{
    public interface IEquipo
    {
        Task<IEnumerable<EquipoModel>> Get();
        Task<EquipoModel> Get(string _id);
        Task Add(EquipoModel Equipos);
        Task<ReplaceOneResult> Update(string _id, EquipoModel Equipos);
        Task<DeleteResult> Remove(string _id);
        Task<DeleteResult> RemoveAll();
    }
}
