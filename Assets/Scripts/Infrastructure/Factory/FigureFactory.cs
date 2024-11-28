using System;
using System.Collections.Generic;
using ChessTest.Model;
using ChessTest.Model.Figures;
using Infrastructure.AssetManagement;
using Infrastructure.Services.ServiceLocator;
using Network;
using UnityEngine;
using WebSocketSharp;

namespace Infrastructure.Factory
{
    public class FigureFactory
    {
        private Dictionary<Type, string> FiguresPath = new()
        {
            {typeof(King), AssetPath.KingFigure},
            {typeof(Quin), AssetPath.QuinFigure},
            {typeof(Pawn), AssetPath.PawnFigure},
            {typeof(Tower), AssetPath.TowerFigure},
            {typeof(Horse), AssetPath.HorseFigure},
            {typeof(Elephant), AssetPath.ElephantFigure},
        };

        private readonly IAssetProvider _assetProvider;
        private readonly Transform _figureContainer;
        public FigureFactory(IAssetProvider assetProvider, Transform figureContainer)
        {
            _assetProvider = assetProvider;
            _figureContainer = figureContainer;
        }
        public GameObject InstantiateFigure(Figure figure, Vector2 position)
         {
            var figureType = figure.GetType();
            if (FiguresPath.TryGetValue(figure.GetType(), out string path))
            {
                if (figure.GetSide == Side.Black)
                    path += "Black";
                var figureObj = _assetProvider.Instantiate(path);
                figureObj.transform.SetParent(_figureContainer);
                figureObj.transform.position = position;
                return figureObj;
            }

            return null;
        }
    }
}