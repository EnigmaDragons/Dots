using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;

namespace Dots.Characters
{
    public abstract class Blob : IVisual
    {
        protected readonly Color _color;

        protected Vector2 _center;

        protected float _speed = 0.1f;
        protected float _size = 25;

        protected Blob(Color color)
        {
            _color = color;
        }

        public void Draw(Vector2 offset)
        {
            World.DrawCircle(_size, _color, new Vector2(_center.X - _size + offset.X, _center.Y - _size + offset.Y));
        }
    }
}
