using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace MonoDragons.Core.PhysicsEngine
{
    public class PhysicsInstance
    {
        private readonly List<Action> callbacks = new List<Action>();

        public float GetDistance(float speed, TimeSpan deltaTime)
        {
            return (float)(speed * deltaTime.TotalMilliseconds);
        }

        public void MoveTowards(Vector2 source, Vector2 destination, float speed, TimeSpan deltaTime, Action<Vector2> moveCallback)
        {
            MoveTowards(source, destination, GetDistance(speed, deltaTime), moveCallback);
        }

        public void MoveTowards(Vector2 source, Vector2 destination, float distance, Action<Vector2> moveCallback)
        {
            Move(source, GetDirectionTowards(source, destination), distance, moveCallback);
        }

        public Vector2 GetDirectionTowards(Vector2 source, Vector2 destination)
        {
            var direction = destination - source;
            direction.Normalize();
            return direction;
        }

        public void Move(Vector2 source, Vector2 direction, float speed, TimeSpan deltaTime, Action<Vector2> moveCallback)
        {
            Move(source, direction, GetDistance(speed, deltaTime), moveCallback);
        }

        public void Move(Vector2 source, Vector2 direction, float distance, Action<Vector2> moveCallback)
        {
            callbacks.Add(() => moveCallback(source + direction * distance));
        }

        public void Resolve()
        {
            callbacks.ForEach(x => x());
        }
    }
}
