using System;
using System.Collections.Generic;
using Dots.Player;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;

namespace Dots.Scenes
{
    public class PlayerTest : IScene
    {
        private List<IVisual> _visuals = new List<IVisual>();
        private List<IAutomaton> _automatons = new List<IAutomaton>();

        public void Init()
        {
            var player = new PlayerBlob(Color.Red);
            _visuals.Add(player);
            _automatons.Add(player);
        }

        public void Update(TimeSpan delta)
        {
            _automatons.ForEach(x => x.Update(delta));
        }

        public void Draw()
        {
            World.DrawBrackgroundColor(Color.Black);
            _visuals.ForEach(x => x.Draw(Vector2.Zero));
        }
    }
}
