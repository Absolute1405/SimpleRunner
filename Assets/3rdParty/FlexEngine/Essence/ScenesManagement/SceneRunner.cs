using System.Threading.Tasks;
using UnityEngine;

namespace FlexEngine.Essence.ScenesManagement
{
    public abstract class SceneRunner<TArgs> : MonoBehaviour
    {
        public abstract Task Load(TArgs args);
        public abstract void Run(TArgs args);
    }
}

