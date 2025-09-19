using System.ComponentModel.DataAnnotations;

namespace AndreBrandaoCloudGamesApi.Data.Dtos.UsuarioDto
{
    public class LoginUsuarioDto
    {
        public required string UserName { get; set; }
        public required string Password { get; set; }
    }
}

