using AndreBrandaoCloudGamesApi.Models;

namespace AndreBrandaoCloudGamesApi.Repositories.Contracts
{
    public interface IJogoRepository : IGenericRepository<Jogo>
    {
        Task<Jogo> GetDetalhesDoJogoAsync(Guid id);
    }
}
