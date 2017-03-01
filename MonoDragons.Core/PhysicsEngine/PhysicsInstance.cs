using System;
using System.Collections.Generic;
using System.Linq;
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
            callbacks.Add(() => moveCallback(GetLocation(source, direction, distance)));
        }

        public void Arrive(Vector2 source, Vector2 destination, Action uponArrivial)
        {
            callbacks.Add(() =>
            {
                if (Math.Abs(source.X - destination.X) < 10 && Math.Abs(source.Y - destination.Y) < 10)
                    uponArrivial();
            });
        }

        public Vector2 GetLocation(Vector2 source, Vector2 direction, float distance)
        {
            return source + direction * distance;
        }

        public void Resolve()
        {
            var list = callbacks.ToList();
            callbacks.Clear();
            list.ForEach(x => x());
        }
    }
}
