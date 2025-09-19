using AndreBrandaoCloudGamesApi.Data.Dtos.UsuarioDto;
using AndreBrandaoCloudGamesApi.Identity;
using AndreBrandaoCloudGamesApi.Repositories.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AndreBrandaoCloudGamesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _usuarioService;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioController(UsuarioService cadastraUsuarioService, IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioService = cadastraUsuarioService;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Policy = "Admin")]
        public async Task<ICollection<ReadUsuarioDto>> GetUsuarios()
        {

            var listaDeUsuarios = await _usuarioRepository.GetAllAsync();
            var listaDeUsuariosMapeadosParaReadUsuariosDtos = _mapper.Map<ICollection<ReadUsuarioDto>>(listaDeUsuarios);
            return listaDeUsuariosMapeadosParaReadUsuariosDtos;
        }

        [HttpPost("cadastro")]
        public async Task<IResult> CadastraUsuario(CreateUsuarioDto createUsuarioDto)
        {
            var cadastro = await _usuarioService.CadastraUsuario(createUsuarioDto);
            return Results.Ok(cadastro);

        }

        [HttpPost("login")]
        public async Task<IResult> Login(LoginUsuarioDto loginUsuarioDto)
        {

            var token = await _usuarioService.Login(loginUsuarioDto);
            return Results.Ok(token);
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IResult> PutUsuario(Guid id, CreateUsuarioDto createUsuarioDto)
        {

            var usuario = await _usuarioRepository.GetAsync(id);
            if (usuario == null)
            {
                return Results.NotFound();
            }
            _mapper.Map(createUsuarioDto, usuario);
            await _usuarioRepository.UpdateAsync(usuario);
            return Results.NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IResult> DeleteUsuario(string id)
        {

            var usuario = await _usuarioRepository.GetAsync(id);
            if (usuario == null)
            {
                return Results.NotFound();
            }
            await _usuarioRepository.DeleteAsync(id);
            return Results.NoContent();

        }

        [HttpGet("{id}/detalhes")]
        [Authorize(Policy = "Admin")]
        public async Task<IResult> GetDetalhesDoUsuario(string id)
        {
            {
                var usuario = await _usuarioRepository.GetDetalhesDoUsuarioAsync(id);
                if (usuario == null)
                {
                    return Results.NotFound();
                }
                var readUsuarioDto = _mapper.Map<ReadUsuarioDto>(usuario);
                return Results.Ok(readUsuarioDto);

            }

        }

    }
}

