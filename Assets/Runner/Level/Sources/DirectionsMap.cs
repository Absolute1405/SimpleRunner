using System;
using System.Collections.Generic;
using UnityEngine;

namespace Runner.Level
{
    public static class DirectionsMap
    {
        private static readonly Dictionary<Direction, Vector3> _levelMovementMap = new Dictionary<Direction, Vector3>()
        {
            {Direction.Back, Vector3.back},
            {Direction.Forward, Vector3.forward},
            {Direction.Left, Vector3.left},
            {Direction.Right, Vector3.right}
        };

        public static Vector3 GetDirectionVector(Direction direction)
        {
            if (!_levelMovementMap.ContainsKey(direction))
                throw new ArgumentException($"Directions map doesnt contain level direction {direction}");
            
            return _levelMovementMap[direction];
        }
        
        public static Quaternion GetDirectionQuaternion(Direction direction)
        {
            if (!_levelMovementMap.ContainsKey(direction))
                throw new ArgumentException($"Directions map doesnt contain level direction {direction}");

            Vector3 directionVector = GetDirectionVector(direction);
            return Quaternion.LookRotation(directionVector, Vector3.up);
        }
    }
    
    public enum Direction
    {
        Back,
        Forward,
        Left,
        Right
    }
}

