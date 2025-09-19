using AndreBrandaoCloudGamesApi.Models;
using AndreBrandaoCloudGamesApi.Repositories.Contracts;

namespace AndreBrandaoCloudGamesApi.Services
{
    public class PromocaoService : Notificador
    {
        private readonly IJogoRepository _jogoRepository;

        public PromocaoService(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;   
        }

        private bool IsPromotional;

        public async Task AtualizaJogosAplicandoDesconto(bool isPromotional)
        {
            var jogos = await _jogoRepository.GetAllAsync();

            foreach (var jogo in jogos)
            {
                AdicionaObservador(jogo);
                SetIsPromotional(isPromotional);
                NotificaObservadores(isPromotional);
                await _jogoRepository.UpdateAsync(jogo);
            }
        }
        public void SetIsPromotional(bool IsPromotional)
        {
            this.IsPromotional = IsPromotional;
        }
    }
}


