using AndreBrandaoCloudGamesApi.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AndreBrandaoCloudGamesApi.Data.Dtos.UsuarioDto
{
    public class CreateUsuarioDto
    {
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public required string Repassword { get; set; }
        public required string Role { get; set; }
    }
 }
