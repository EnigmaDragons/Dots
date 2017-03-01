using System;
using System.Collections.Generic;
using Dots.Characters;
using Dots.Visuals;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;

namespace Dots.Scenes
{
    public class PlayerTest : IScene
    {
        private List<IVisual> _visuals = new List<IVisual>();
        private List<IAutomaton> _automatons = new List<IAutomaton>();

        public void Init()
        {
            Input.ClearBindings();
            var player = new PlayerBlob(Color.Red);
            var enemies = new List<EnemyBlob> { new EnemyBlob(), new EnemyBlob(), new EnemyBlob(), new EnemyBlob()};
            var gameBackground = new GameBackground();
            _visuals.Add(player);
            _visuals.AddRange(enemies);
            _visuals.Add(gameBackground);
            _automatons.Add(player);
            _automatons.AddRange(enemies);
            _automatons.Add(gameBackground);
        }

        public void Update(TimeSpan delta)
        {
            _automatons.ForEach(x => x.Update(delta));
        }

        public void Draw()
        {
            World.DrawBrackgroundColor(Color.Black);
            _visuals.ForEach(x => x.Draw(new Vector2(775, 425)));
        }
    }
}
