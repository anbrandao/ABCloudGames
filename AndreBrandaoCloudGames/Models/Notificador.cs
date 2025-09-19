using AndreBrandaoCloudGamesApi.Repositories.Contracts;
using AndreBrandaoCloudGamesApi.Repositories.Repository;

namespace AndreBrandaoCloudGamesApi.Models
{
    public abstract class Notificador
    {
        private readonly ICollection<IPromocaoObserver> Observadores = new List<IPromocaoObserver>();

        public void AdicionaObservador(IPromocaoObserver observador)
        {
            Observadores.Add(observador);
        }

        public void NotificaObservadores(bool isPromotional)
        {
            foreach (var observador in Observadores)
            {
                observador.AtualizarPromocao(isPromotional);
            }
        }
    }
}
