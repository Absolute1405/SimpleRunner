using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlexEngine.Essence.ScenesManagement
{
    public class ScenesLoader: MonoBehaviour
    {
        public float LoadProgress { get; private set; }
        
        private TaskCompletionSource<bool> _loadCompletion;
        public event Action SceneLoaded;

        public async Task LoadScene<TArgs>(string sceneName, TArgs args)
        {
            var operation = SceneManager.LoadSceneAsync(sceneName);

            while (!operation.isDone)
            {
                LoadProgress = operation.progress;
                await Task.Yield();
            }

            SceneLoaded?.Invoke();
            var runner = FindObjectOfType<SceneRunner<TArgs>>();

            if (runner == null)
                throw new InvalidOperationException(
                    $"Cant find scene runner with args {typeof(TArgs)} on scene {sceneName}");

            await runner.Load(args);
            runner.Run(args);
        }
    }
}
