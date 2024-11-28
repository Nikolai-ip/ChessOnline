 using ChessTest.Model;
 using Infrastructure.AssetManagement;
 using Infrastructure.Factory;
 using Infrastructure.Services.ServiceLocator;
 using Photon.Pun;
 using Presenter;
 using UnityEngine;

namespace DefaultNamespace.Proxy
{
    public class GameProxyTest:MonoBehaviour
    {
        // private Field _field;
        // private Grid _grid;
        // private ChessFieldFactory _fieldFactory;
        // private FigureFactory _figureFactory;
        // private ChessGame _chessGame;
        // [SerializeField] private Transform _figureContainer;
        // private InputHandler _inputHandler;
        // private void Start()
        // {
        //     _field = new Field();
        //     _chessGame = new ChessGame(_field);
        //     _grid = FindObjectOfType<Grid>();
        //     var assetProvider = GameServices.Container.Single<INetworkAssetProvider>();
        //     _figureFactory = new FigureFactory(assetProvider,_figureContainer);
        //     _fieldFactory = new ChessFieldFactory(_figureFactory);
        //     _fieldFactory.CreateField(_grid,_field.data);
        //     if (PhotonNetwork.IsMasterClient)
        //         _inputHandler = new InputHandler(Side.White);
        //     else
        //         _inputHandler = new InputHandler(Side.Black);
        // }
    }
}