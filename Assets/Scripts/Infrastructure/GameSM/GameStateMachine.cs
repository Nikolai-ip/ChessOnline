using System;
using System.Collections.Generic;
using Assets.Scripts.Cmd;
using Infrastructure;
using Infrastructure.Cmd;
using Infrastructure.Factory;
using Infrastructure.GameSM;
using Infrastructure.GameSM.GameState;
using Infrastructure.SceneLoader;
using Infrastructure.Services;
using Infrastructure.Services.ServiceLocator;
using Network;
using UnityEngine;

namespace GameCore
{
    public class GameStateMachine
    {
        private Dictionary<Type, IExitableState> _states;
        private IExitableState _currentState;
        public GameStateMachine(ISceneLoader sceneLoader, GameServices services)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                {typeof(BootstrapState), new BootstrapState(this, sceneLoader, services)},
                {typeof(MainMenu), new MainMenu(this,services.Single<IRoomService>(),sceneLoader)},
                {typeof(LoadLevelState), new LoadLevelState(this, services, sceneLoader,services.Single<IGameFactory>())},
                {typeof(GameCycle), new GameCycle(this)},
            };
        }
        public void Enter<TState>() where TState: class, IState
        {
            var state = ChangeState<TState>();
            state.Enter();
            Debug.Log(state.GetType());
        }
        public void Enter<TState, TPayLoad>(TPayLoad payLoad) where TState: class, IPayLoadedState<TPayLoad>
        {
            var state = ChangeState<TState>();
            state.Enter(payLoad);
            Debug.Log(state.GetType());
        }
        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _currentState?.Exit();
            var state = GetState<TState>();
            _currentState = state;
            return state;
        }
        private TState GetState<TState>() where TState: class, IExitableState
        {
            return _states[typeof(TState)] as TState;
        }
    }
}