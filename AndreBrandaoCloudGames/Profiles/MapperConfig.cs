using AndreBrandaoCloudGamesApi.Data.Dtos.ItemPedidoDto;
using AndreBrandaoCloudGamesApi.Data.Dtos.JogoDto;
using AndreBrandaoCloudGamesApi.Data.Dtos.PedidoDto;
using AndreBrandaoCloudGamesApi.Data.Dtos.UsuarioDto;
using AndreBrandaoCloudGamesApi.Models;
using AutoMapper;

namespace AndreBrandaoCloudGamesApi.Profiles
{
    public class MapperConfig : Profile
    {
      
    
        public MapperConfig()
        {
            CreateMap<Usuario, ReadUsuarioDto>().ReverseMap().
                ForMember(readUsuarioDto => readUsuarioDto.Pedidos,
                opt =>opt.MapFrom(Usuario => Usuario.Pedidos));

            CreateMap<Usuario, CreateUsuarioDto>().ReverseMap();

            CreateMap<Jogo, ReadJogoDto>().ReverseMap();
            CreateMap<Jogo, CreateJogoDto>().ReverseMap()
            .AfterMap((src, dest) => dest.PrecoVenda = src.Preco);

            CreateMap<ItemPedido, ReadItemPedidoDto>().ReverseMap().
                ForMember(readItemPedidoDto => readItemPedidoDto.Jogo,
                opt => opt.MapFrom(itemPedido => itemPedido.Jogo)).
                ForMember(readItemPedidoDto => readItemPedidoDto.Pedido,
                opt => opt.MapFrom(itemPedido => itemPedido.Pedido));

            CreateMap<ItemPedido, CreateItemPedidoDto>().ReverseMap();
             

            CreateMap<Pedido, ReadPedidoDto>().ReverseMap().
                ForMember(readPedidoDto => readPedidoDto.Usuario,
                opt => opt.MapFrom(Pedido => Pedido.Usuario));
            CreateMap<Pedido, CreatePedidoDto>().ReverseMap();

        }
    }
}
    

