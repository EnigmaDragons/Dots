using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.PhysicsEngine;

namespace Dots.Player
{
    public class PlayerBlob : IVisualAutomaton
    {
        private const float Speed = 0.1f;

        private readonly Color _color;

        private Vector2 _center; 
        private Direction _direction;
        private float _size = 20;

        public PlayerBlob(Color color)
        {
            Input.OnDirection(x => _direction = x);
            _color = color;
        }

        public void Update(TimeSpan delta)
        {
            new Physics().Move(_center, new Vector2((float)_direction.HDir, (float)_direction.VDir), Speed, delta, x => _center = x);
        }

        public void Draw(Vector2 offset)
        {
            World.DrawCircle(_size, _color, new Vector2(_center.X - _size + offset.X, _center.Y - _size + offset.Y));
        }
    }
}
