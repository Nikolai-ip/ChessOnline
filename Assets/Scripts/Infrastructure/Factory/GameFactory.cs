using Infrastructure.AssetManagement;
using Infrastructure.Services.ServiceLocator;
using Photon.Pun;
using Presenter;
using View;


namespace Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly INetworkAssetProvider _networkAssetProvider;
        private readonly IAssetProvider _assetProvider;
        private IInputController _inputController;


        public GameFactory(INetworkAssetProvider networkAssetProvider, IAssetProvider assetProvider)
        {
            _networkAssetProvider = networkAssetProvider;
            _assetProvider = assetProvider;
        }

        public void CreateGameEntities()
        {
            var grid = _assetProvider.Instantiate<Grid>(AssetPath.Field);
            var figureContainer = grid.transform;
            var figureFactory  = new FigureFactory(_networkAssetProvider,figureContainer);
            var fieldFactory = new ChessFieldFactory(figureFactory);
            GameServices.Container.RegisterSingle(fieldFactory);
        }


        public void CreateControllers()
        {
            if (PhotonNetwork.IsMasterClient)
                _networkAssetProvider.Instantiate(AssetPath.NetworkMessageController);
            _inputController = _assetProvider.Instantiate<InputFieldInputController>(AssetPath.InputController);
            GameServices.Container.RegisterSingle<IInputController>(_inputController);
            
        }
    }
}