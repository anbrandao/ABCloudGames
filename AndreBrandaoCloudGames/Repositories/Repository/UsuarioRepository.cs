using AndreBrandaoCloudGamesApi.Infraestrutura;
using AndreBrandaoCloudGamesApi.Models;
using AndreBrandaoCloudGamesApi.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AndreBrandaoCloudGamesApi.Repositories.Repository
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await GetAsync(id);
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Usuario> GetAsync(string id)
        {
            var result = await _dbSet.FindAsync(id);
            return result;
        }

        public async Task<Usuario> GetDetalhesDoUsuarioAsync(string usuarioId)
        {
            var usuario = await _context.Usuarios
                .Include(u => u.Pedidos)
                .FirstOrDefaultAsync(u => u.Id == usuarioId);
  
            usuario.Pedidos = usuario.Pedidos
                .Select(p =>
                {
                    p.Usuario = null;
                    p.ItensPedidos = new List<ItemPedido>();
                    return p;
                })
                .Distinct()
                .ToList();
        

            return usuario;
        }
    }
}
