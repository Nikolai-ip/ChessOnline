using System;
using Infrastructure.Services;

namespace Presenter
{
    public interface IInputController:IService
    {
        event Action<int, int> TileSelected;
    }
}