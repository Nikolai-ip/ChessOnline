using Infrastructure.Services;

namespace Infrastructure.Factory
{
    public interface IGameFactory:IService
    {
        void CreateGameEntities();
        void CreateControllers();
    }
}