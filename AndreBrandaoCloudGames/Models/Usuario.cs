using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace AndreBrandaoCloudGamesApi.Models
{
    /// <summary>
    /// Usuário que representa um cliente com acesso à plataforma de jogos,
    /// onde pode se associar ao plano premium para obter descontos exclusivos,
    /// explorar a biblioteca de jogos e realizar compras de títulos disponíveis.
    /// </summary>
    public class Usuario : IdentityUser
    {
        public required string Nome { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public required Role Role { get; set; } = Role.USER;
        public ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
    }
}
