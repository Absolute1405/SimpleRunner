using System;
using System.Collections.Generic;
using FlexEngine.Essence.AppFlow;
using UnityEngine;

namespace Runner.GameFlow
{
    public class GameUpdater : MonoBehaviour
    {
        private HashSet<IUpdatable> _updateListeners = new HashSet<IUpdatable>();
        private HashSet<IFixedUpdatable> _fixedUpdateListeners = new HashSet<IFixedUpdatable>();


        public void AddUpdateListener(IUpdatable listener)
        {
            _updateListeners.Add(listener);
        }
        
        public void RemoveUpdateListener(IUpdatable listener)
        {
            _updateListeners.Remove(listener);
        }
        
        public void RemoveAllUpdateListeners()
        {
            _updateListeners.Clear();
        }
        
        public void AddFixedUpdateListener(IFixedUpdatable listener)
        {
            _fixedUpdateListeners.Add(listener);
        }
        
        public void RemoveFixedUpdateListener(IFixedUpdatable listener)
        {
            _fixedUpdateListeners.Remove(listener);
        }
        
        public void RemoveAllFixedUpdateListeners()
        {
            _fixedUpdateListeners.Clear();
        }
        
        private void Update()
        {
            foreach (var listener in _updateListeners)
            {
                listener.DoUpdate();
            }
        }

        private void FixedUpdate()
        {
            foreach (var listener in _fixedUpdateListeners)
            {
                listener.DoFixedUpdate();
            }
        }

        public void Enable(bool value) => enabled = value;
    }
}

