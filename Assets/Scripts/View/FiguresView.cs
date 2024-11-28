using ChessTest.Model;
using Presenter;
using UnityEngine;

namespace ChessTest.View
{
    public class FiguresView:MonoBehaviour
    {
        private InputHandler _presenter;
        private void Init()
        {
            _presenter.OnFieldChanged += UpdateField;
            _presenter.OnFigureAttack += DisplayAttack;
        }

        private void DisplayAttack(Figure attack, Figure defeated)
        {
        
        }

        private void UpdateField(Field field)
        {
        
        }
    }
}

