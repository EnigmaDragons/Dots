using System.Collections.Generic;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Common;
using MonoDragons.Core.Engine;

namespace MonoDragons.Core.Render
{
    public class Camera
    {
        private Vector2 _position;

        public Camera(Vector2 startingPosition)
        {
            _position = startingPosition;
        }

        public void Move(Vector2 amount)
        {
            _position = _position - amount;
        }

        public void Draw(IVisual visual)
        {
            visual.Draw(_position);
        }

        public void Draw(IEnumerable<IVisual> visuals)
        {
            visuals.ForEach(Draw);
        }
    }
}
