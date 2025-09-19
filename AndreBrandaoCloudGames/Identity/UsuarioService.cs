using AndreBrandaoCloudGamesApi.Data.Dtos.UsuarioDto;
using AndreBrandaoCloudGamesApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AndreBrandaoCloudGamesApi.Identity
{
    public class UsuarioService
    {

        private readonly IMapper _mapper;
        private readonly UserManager<Usuario> _userManager;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly TokenService _tokenService;

        public UsuarioService(IMapper mapper, UserManager<Usuario> userManager, SignInManager<Usuario> signInManager, TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<IResult> CadastraUsuario(CreateUsuarioDto createUsuarioDto)
        {
            var useCase = new RegistraUsuarioUseCase();
            var result = useCase.Execute(createUsuarioDto);
            Usuario usuario = _mapper.Map<Usuario>(createUsuarioDto);
            IdentityResult resultado = await _userManager.CreateAsync(usuario, createUsuarioDto.Password);
            if (resultado.Succeeded)
            {
                return Results.Ok("Usuário cadastrado com sucesso");
            }
            throw new ApplicationException("Falha ao cadastrar usuario");
        }

        public async Task<IResult> Login(LoginUsuarioDto loginUsuarioDto)
        {
            var useCase = new LoginUsuarioUseCase();
            var result = useCase.Execute(loginUsuarioDto);
            var resultado = await _signInManager.PasswordSignInAsync(loginUsuarioDto.UserName, loginUsuarioDto.Password, false, false);
            if (!resultado.Succeeded)
            {
                throw new ApplicationException("Usuário não autenticado!");
            }
          
            var usuario = _signInManager
                .UserManager
                .Users.
                FirstOrDefault(user => user.NormalizedUserName == loginUsuarioDto.UserName.ToUpper());

            var token = _tokenService.GeraToken(usuario);

            return Results.Ok(token);
        }
    }
}

