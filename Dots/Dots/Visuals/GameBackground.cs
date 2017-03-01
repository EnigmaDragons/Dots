using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Graphics;

namespace Dots.Visuals
{
    public class GameBackground : IVisualAutomaton
    {
        private readonly Texture2D _theLine;
        private const int CellWidth = 32;
        private readonly Color _lineColor = Color.FromNonPremultiplied(120, 120, 255, 50);

        public GameBackground()
        {
            _theLine = new LineTexture(Color.White).Create();
        }

        public void Update(TimeSpan delta)
        {
        }

        public void Draw(Vector2 offset)
        {
            World.DrawBrackgroundColor(Color.FromNonPremultiplied(30, 30, 30, 255));
            for (var x = 0; x < 50; x++)
                World.Draw(_theLine, new Rectangle(x * CellWidth + (int)offset.X % 32, 0, 1, 1080), _lineColor);
            for (var y = 0; y < 28; y++)
                World.Draw(_theLine, new Rectangle(0, y * CellWidth + (int)offset.Y % 32, 1920, 1), _lineColor);
        }
    }
}
