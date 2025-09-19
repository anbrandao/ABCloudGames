using AndreBrandaoCloudGamesApi.Data.Dtos.JogoDto;
using AndreBrandaoCloudGamesApi.Models;
using AndreBrandaoCloudGamesApi.Repositories.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AndreBrandaoCloudGamesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JogoController : Controller
    {
        private readonly IJogoRepository _jogoRepository;
        private readonly IMapper _mapper;

        public JogoController(IJogoRepository jogoRepository, IMapper mapper)
        {
            _jogoRepository = jogoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ICollection<ReadJogoDto>> GetJogos()
        {
            try
            {
                var listaDeJogos = await _jogoRepository.GetAllAsync();
                var listaDejogosMapeadosParaReadJogosDtos = _mapper.Map<ICollection<ReadJogoDto>>(listaDeJogos);
                return listaDejogosMapeadosParaReadJogosDtos;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao retornar Jogos");
            }

        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public async Task<IResult> PostJogo([FromBody] CreateJogoDto createJogoDto)
        {
            try
            {
                var jogoDtoMapeadoParaJogo = _mapper.Map<Jogo>(createJogoDto);
                await _jogoRepository.AddAsync(jogoDtoMapeadoParaJogo);
                return Results.Created($"/{jogoDtoMapeadoParaJogo.Id}", jogoDtoMapeadoParaJogo);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao Inserir Jogo");
            }  
        }
       
        [HttpPut("{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IResult> PutJogo(Guid id, CreateJogoDto createJogoDto)
        {
            try
            {
                var jogo = await _jogoRepository.GetAsync(id);
                if (jogo == null)
                {
                    return Results.NotFound();
                }
                _mapper.Map(createJogoDto, jogo);
                await _jogoRepository.UpdateAsync(jogo);
                return Results.NoContent();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao Atualizar Jogo");
            }     
        }
        [HttpDelete("{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IResult> DeleteJogo(Guid id)
        {
            try
            {
                var jogo = await _jogoRepository.GetAsync(id);
                if (jogo == null)
                {
                    return Results.NotFound();
                }
                await _jogoRepository.DeleteAsync(jogo.Id);
                return Results.NoContent();
            }
            catch (Exception ex) {
                throw new ApplicationException("Falha ao Apagar Jogo");
            }     
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetJogo(Guid id)
        {
            try
            {
                var jogo = await _jogoRepository.GetAsync(id);

                if (jogo == null)
                {
                    return Results.NotFound();
                }
                var jogoMapeado = _mapper.Map<ReadJogoDto>(jogo);
                return Results.Ok(jogoMapeado);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Falha ao Buscar Jogo pelo Id");
            } 
        }

        [HttpGet("{id}/detalhes")]
        public async Task<IResult> GetDetalhesDoJogo(Guid id)
        {
            try
            {
                var jogo = await _jogoRepository.GetDetalhesDoJogoAsync(id);
                if (jogo == null)
                {
                    return Results.NotFound();
                }
                var jogoMapeado = _mapper.Map<ReadJogoDto>(jogo);
                return Results.Ok(jogoMapeado);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Falha ao Buscar Detalhes do Jogo pelo Id");
            }

        }
    }
}
