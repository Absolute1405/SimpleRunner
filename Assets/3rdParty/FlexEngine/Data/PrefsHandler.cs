using UnityEngine;

namespace FlexEngine.Data
{
    public static class PrefsHandler
    {
        public static string Load(string name) 
        {
            var loadResult = PlayerPrefs.GetString(name);
            return loadResult;
        }

        public static void Save(string name, string data)
        {
            PlayerPrefs.SetString(name, data);
            PlayerPrefs.Save();
        }
    }
}

