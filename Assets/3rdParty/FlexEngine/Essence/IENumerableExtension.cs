using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace FlexEngine.Essence
{
    public static class IENumerableExtension
    {
        public static T GetRandom<T>(this IEnumerable<T> collection)
        {
            var array = collection.ToArray();

            if (array.Length == 0)
                throw new ArgumentException("Empty collection");
            
            var rand = Random.Range(0, array.Length);
            return array[rand];
        }
    }
}

