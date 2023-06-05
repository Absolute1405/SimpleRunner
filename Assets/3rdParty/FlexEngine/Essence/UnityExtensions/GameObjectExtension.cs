using UnityEngine;

namespace FlexEngine.Essence.UnityExtensions
{
    public static class GameObjectExtension
    {
        public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
        {
            var component = gameObject.GetComponent<T>();
            if (component != null) return component;
            return gameObject.AddComponent<T>();
        }
    }
}

