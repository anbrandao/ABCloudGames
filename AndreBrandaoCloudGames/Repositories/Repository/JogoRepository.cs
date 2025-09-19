using AndreBrandaoCloudGamesApi.Infraestrutura;
using AndreBrandaoCloudGamesApi.Models;
using AndreBrandaoCloudGamesApi.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AndreBrandaoCloudGamesApi.Repositories.Repository
{
    public class JogoRepository : GenericRepository<Jogo>, IJogoRepository
    {
        public JogoRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<Jogo> GetDetalhesDoJogoAsync(Guid id)
        {
            var jogo = await _context.Jogos
                .Include(j => j.ItensPedidos)
                    .ThenInclude(j => j.Pedido)
                .FirstOrDefaultAsync(j => j.Id == id);


            jogo.ItensPedidos = jogo.ItensPedidos
                .Select(p =>
                {
                p.Jogo = null;
                p.Pedido.ItensPedidos = null;
                return p;
                }).
                Distinct()
                .ToList();
            
            return jogo;
        }
    }
}
