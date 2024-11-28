using Infrastructure.AssetManagement;
using Photon.Pun;
using UnityEngine;

namespace Network
{
    public class AssetProviderPhoton:INetworkAssetProvider
    {
        public GameObject Instantiate(string path)
        {
            var gameObj = PhotonNetwork.Instantiate(path, Vector3.zero, new Quaternion());
            return gameObj;
        }

        public GameObject Instantiate(string path, Vector3 at)
        {
            var gameObj = PhotonNetwork.Instantiate(path, at, new Quaternion());
            return gameObj;
        }

        public TComponent Instantiate<TComponent>(string path) where TComponent : MonoBehaviour
        {
            var prefab = Instantiate(path);
            return prefab.GetComponent<TComponent>();
        }
    }
}