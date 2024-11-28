using ChessTest.Model;
using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class ChessFieldFactory:IService
    {
        private readonly FigureFactory _figureFactory;
        public ChessFieldFactory(FigureFactory figureFactory)
        {
            _figureFactory = figureFactory;
        }
        public GameObject[,] CreateField(Grid chessGrid, Figure[,] figures)
        {
            var figuresObjects = new GameObject[figures.GetLength(0),figures.GetLength(1)];
            for (int i = 0; i < figures.GetLength(0); i++)
            {
                for (int j = 0; j < figures.GetLength(1); j++)
                {
                    int invertedRow = figures.GetLength(0) - 1 - i;
                    figuresObjects[i,j] = _figureFactory.InstantiateFigure(figures[i, j], chessGrid[invertedRow, j]);
                }
            }

            return figuresObjects;
        }
    }
}