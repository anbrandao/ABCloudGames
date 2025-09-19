using AndreBrandaoCloudGamesApi.Data.Dtos.JogoDto;
using AndreBrandaoCloudGamesApi.Data.Dtos.PedidoDto;
using AndreBrandaoCloudGamesApi.Models;
using AndreBrandaoCloudGamesApi.Repositories.Contracts;
using AndreBrandaoCloudGamesApi.Repositories.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AndreBrandaoCloudGamesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMapper _mapper;

        public PedidoController(IPedidoRepository pedidoRepository, IMapper mapper)
        {
            _pedidoRepository = pedidoRepository;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<ICollection<ReadPedidoDto>> GetPedidos()
        {
            try
            {
                var listaDePedidos = await _pedidoRepository.GetAllAsync();
                var listaDePedidosMapeadosParaReadPedidosDtos = _mapper.Map<ICollection<ReadPedidoDto>>(listaDePedidos);
                return listaDePedidosMapeadosParaReadPedidosDtos;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao retornar Pedidos");
            }

        }

        [HttpPost]
        public async Task<IResult> PostPedido([FromBody] CreatePedidoDto createPedidoDto)
        {
            try
            {
                var pedidoDtoMapeadoParaPedido = _mapper.Map<Pedido>(createPedidoDto);
                await _pedidoRepository.AddAsync(pedidoDtoMapeadoParaPedido);
                return Results.Created($"/{pedidoDtoMapeadoParaPedido.Id}", pedidoDtoMapeadoParaPedido);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao Inserir Pedido");
            }
        }
        [HttpPut("{id}")]
        public async Task<IResult> PutPedido(Guid id, CreatePedidoDto createPedidoDto)
        {
            try
            {
                var pedido = await _pedidoRepository.GetAsync(id);
                if (pedido == null)
                {
                    return Results.NotFound();
                }
                _mapper.Map(createPedidoDto, pedido);
                await _pedidoRepository.UpdateAsync(pedido);
                return Results.NoContent();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao Atualizar Pedido");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IResult> DeletePedido(Guid id)
        {
            try
            {
                var pedido = await _pedidoRepository.GetAsync(id);
                if (pedido == null)
                {
                    return Results.NotFound();
                }
                await _pedidoRepository.DeleteAsync(pedido.Id);
                return Results.NoContent();
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Falha ao Apagar Pedido");
            }
        }
        [HttpGet("{id}")]
        public async Task<IResult> GetPedido(Guid id)
        {
            try
            {
                var pedido = await _pedidoRepository.GetAsync(id);

                if (pedido == null)
                {
                    return Results.NotFound();
                }
                var pedidoMapeado = _mapper.Map<ReadPedidoDto>(pedido);
                return Results.Ok(pedidoMapeado);
            }
            catch (Exception e)
            {
                throw new ApplicationException("Falha ao Buscar Pedido pelo Id");
            }
        }

        [HttpGet("{id}/detalhes")]
        public async Task<IResult> GetDetalhesDoPedido(Guid id)
        { 
            try
               {
                var pedido = await _pedidoRepository.GetDetalhesDoPedidoAsync(id);
                if (pedido == null)
                {
                    return Results.NotFound();
                }
                var readPeditoDto = _mapper.Map<ReadPedidoDto>(pedido);
                return Results.Ok(readPeditoDto);
            } catch (Exception e) 
             {
                throw new ApplicationException("Falha ao Buscar Detalhes do Pedido pelo Id");
             }
           
        }

    }
}


