using AndreBrandaoCloudGamesApi.Models;

namespace AndreBrandaoCloudGamesApi.Repositories.Contracts
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
   
        Task<Usuario> GetAsync(string id);
        Task DeleteAsync(string id);
        Task<Usuario> GetDetalhesDoUsuarioAsync(string usuarioId);
    }
}
