using System;
using Presenter;
using TMPro;
using UnityEngine;

namespace View
{
    public class InputFieldInputController:MonoBehaviour,IInputController
    {
        public event Action<int, int> TileSelected;
        [SerializeField] private TMP_InputField _xUI;
        [SerializeField] private TMP_InputField _yUI;
        
        public void SelectTile()
        {
            int x = Convert.ToInt32(_xUI.text);
            int y = Convert.ToInt32(_yUI.text);
            TileSelected?.Invoke(x,y);
        }
    }
}