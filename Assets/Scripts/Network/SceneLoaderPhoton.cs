using System;
using System.Collections;
using Infrastructure;
using Infrastructure.SceneLoader;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Network
{
    public class SceneLoaderPhoton: ISceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public string CurrentScene => SceneManager.GetActiveScene().name;

        public SceneLoaderPhoton(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string name, Action onLoaded = null)
        {
            _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));
        }

        private IEnumerator LoadScene(string name, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == name)
            {
                onLoaded?.Invoke();
                yield break;
            }
            PhotonNetwork.LoadLevel(name);
            while (SceneManager.GetActiveScene().name != name)
            {
                yield return null;
            }
            onLoaded?.Invoke();
        }
    }
}