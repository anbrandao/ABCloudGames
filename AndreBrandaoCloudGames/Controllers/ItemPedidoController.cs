using AndreBrandaoCloudGamesApi.Data.Dtos.ItemPedidoDto;
using AndreBrandaoCloudGamesApi.Data.Dtos.JogoDto;
using AndreBrandaoCloudGamesApi.Models;
using AndreBrandaoCloudGamesApi.Repositories.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AndreBrandaoCloudGamesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemPedidoController : Controller
    {
        private readonly IJogoRepository _jogoRepository;
        private readonly IItemPedidoRepository _itemPedidoRepository;
        private readonly IMapper _mapper;

        public ItemPedidoController(IItemPedidoRepository itemPedidoRepository, IMapper mapper, IJogoRepository jogoRepository)
        {
            _itemPedidoRepository = itemPedidoRepository;
            _mapper = mapper;
            _jogoRepository = jogoRepository;
        }



        [HttpGet]
        public async Task<ICollection<ReadItemPedidoDto>> GetItensPedidos()
        {
            try
            {
                var listaDeItemPedido = await _itemPedidoRepository.GetAllAsync();
                var listaDeItemPedidoMapeadosParaReadItemPedidoDtos = _mapper.Map<ICollection<ReadItemPedidoDto>>(listaDeItemPedido);
                return listaDeItemPedidoMapeadosParaReadItemPedidoDtos;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao retornar ItensPedidos");
            }
        }

        [HttpPost]
        public async Task<IResult> PostItemPedido([FromBody] CreateItemPedidoDto createItemPedidoDto)
        {
            try   
            {
                var jogo = await _jogoRepository.GetAsync(createItemPedidoDto.JogoId);
                var jogoMapeado = _mapper.Map<ReadJogoDto>(jogo);
                var itemPedidoDtoMapeadoParaItemPedido = _mapper.Map<ItemPedido>(createItemPedidoDto);
                itemPedidoDtoMapeadoParaItemPedido.DefinirPrecoUnitario(jogoMapeado.PrecoVenda);
                await _itemPedidoRepository.AddAsync(itemPedidoDtoMapeadoParaItemPedido);
                return Results.Created($"/{itemPedidoDtoMapeadoParaItemPedido.Id}", itemPedidoDtoMapeadoParaItemPedido);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao Inserir ItemPedido");
            }
        }

        [HttpPut("{id}")]
        public async Task<IResult> PutItemPedido(Guid id, CreateItemPedidoDto createItemPedidoDto)
        {
            try
            {
                var itemPedido = await _itemPedidoRepository.GetAsync(id);
                if (itemPedido == null)
                {
                    return Results.NotFound();
                }
                _mapper.Map(createItemPedidoDto, itemPedido);
                await _itemPedidoRepository.UpdateAsync(itemPedido);
                return Results.NoContent();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao Atualizar ItemPedido");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IResult> DeleteItemPedido(Guid id)
        {
            try
            {
                var itemPedido = await _itemPedidoRepository.GetAsync(id);
                if (itemPedido == null)
                {
                    return Results.NotFound();
                }
                await _itemPedidoRepository.DeleteAsync(itemPedido.Id);
                return Results.NoContent();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao Apagar ItemPedido");
            }
        }

        [HttpGet("{id}")]
        public async Task<IResult> GetItemPedido(Guid id)
        {
            try
            {
                var itemPedido = await _itemPedidoRepository.GetAsync(id);

                if (itemPedido == null)
                {
                    return Results.NotFound();
                }
                var itemPedidoMapeado = _mapper.Map<ReadItemPedidoDto>(itemPedido);
                return Results.Ok(itemPedidoMapeado);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Falha ao Buscar ItemPedido pelo Id");
            }
        }

        [HttpGet("{id}/detalhes")]
        public async Task<IResult> GetDetalhesDoItemPedido(Guid id)
        {
            try
            {
                var itemPedido = await _itemPedidoRepository.GetDetalhesDoItemPedidoAsync(id);
                if (itemPedido == null)
                {
                    return Results.NotFound();
                }
                var itemPedidoMapeado = _mapper.Map<ItemPedido>(itemPedido);
                return Results.Ok(itemPedidoMapeado);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Falha ao Buscar Detalhes do ItemPedido pelo Id");
            }

        }
    }
}
