using UnityEngine;

namespace FlexEngine.Data
{
    public class UserDataConfig<T> : ScriptableObject where T: new()
    {
        private string DataName => typeof(T).Name;
        protected T Model = new T();

        public void Save()
        {
            var exportData = GetForExport();
            PrefsHandler.Save(DataName, exportData);
        }

        public void Load()
        {
            var data = PrefsHandler.Load(DataName);
            Model = GetFromExported(data);
        }

        public string GetForExport()
        {
            return JsonUtility.ToJson(Model);
        }

        private T GetFromExported(string data)
        {
            if (string.IsNullOrEmpty(data))
                return new T();
            
            var result = JsonUtility.FromJson<T>(data);
            if (result == null)
            {
                Debug.LogError($"Cant decode {typeof(T)} data");
                return new T();
            }
            
            return result;
        }
    }
}

