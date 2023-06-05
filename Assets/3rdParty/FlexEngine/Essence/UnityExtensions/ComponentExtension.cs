﻿using UnityEngine;

namespace FlexEngine.Essence.UnityExtensions
{
    public static class ComponentExtension
    {
        public static T GetOrAddComponent<T>(this Component component) where T : Component
        {
            return component.gameObject.GetOrAddComponent<T>();
        }
    }
}

