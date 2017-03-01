using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Graphics;

namespace Dots.Animation
{
    public class MovingPoint : IVisualAutomaton
    {
        private readonly bool _movesHorizontally;

        private readonly Texture2D _movingPoint;
        private const int Width = 3;
        private const int Length = 20;
        private const int Speed = 3;
        private const int MaxPosition = 1920;
        
        private float _position;

        private double _elapsedMills = 0;

        public MovingPoint(float start, bool movesHorizontally, Color color)
        {
            _position = start;
            _movesHorizontally = movesHorizontally;
            _movingPoint = new CometTexture(color, movesHorizontally).Create();
        }

        public void Update(TimeSpan delta)
        {
            _elapsedMills += delta.TotalMilliseconds;
            if (!(_elapsedMills > 20)) return;

            UpdatePosition();
            _elapsedMills -= 20;
        }

        public void Draw(Vector2 offset)
        {
            World.Draw(_movingPoint, new Rectangle(Get2DPosition().ToPoint() + offset.ToPoint(), new Point(Width, Length)), Color.Purple);
        }

        private void UpdatePosition()
        {
            if (_position > MaxPosition)
                _position = 0;
            _position = _position + Speed;
        }

        private Vector2 Get2DPosition()
        {
            return _movesHorizontally ? new Vector2(_position, 0) : new Vector2(0, _position);
        }
    }
}
