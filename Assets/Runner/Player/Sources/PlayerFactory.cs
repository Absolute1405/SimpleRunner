using Runner.Shared;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Runner.Player
{
    public class PlayerFactory : AddressableCachedFactory<PlayerFacade>
    {
        [SerializeField] private Transform _root;

        public PlayerFacade Create(AssetReference template)
        {
            var result = GetCachedInstance(_root);
            return result;
        }
    }
}

