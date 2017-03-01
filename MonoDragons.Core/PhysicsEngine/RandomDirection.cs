using System;
using Microsoft.Xna.Framework;

namespace MonoDragons.Core.PhysicsEngine
{
    public class RandomDirection
    {
        private Vector2 _direction;

        public Vector2 Get()
        {
            if (_direction == Vector2.Zero)
                ResolveRandomDirection();
            return _direction;
        }

        private void ResolveRandomDirection()
        {
            var random = new Random(Guid.NewGuid().GetHashCode());
            _direction = new Physics().GetDirectionTowards(Vector2.Zero, new Vector2(random.Next(-100, 100), random.Next(-100, 100)));
        }
    }
}
