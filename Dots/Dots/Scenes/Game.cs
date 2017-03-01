using System;
using System.Collections.Generic;
using Dots.Characters;
using Dots.Visuals;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.Render;

namespace Dots.Scenes
{
    public class Game : IScene
    {
        private readonly List<IVisual> _visuals = new List<IVisual>();
        private readonly List<IAutomaton> _automatons = new List<IAutomaton>();
        private Camera _camera;

        public void Init()
        {
            World.PlayMusic("Music/thechase");
            Input.ClearBindings();
            Input.OnDirection(UpdateCamera);
            _camera = new Camera(new Vector2(775, 425));
            var player = new PlayerBlob(Color.Red);
            var enemies = new List<EnemyBlob> { new EnemyBlob(), new EnemyBlob(), new EnemyBlob(), new EnemyBlob() };
            var gameBackground = new GameBackground();
            _visuals.Add(gameBackground);
            _visuals.Add(player);
            _visuals.AddRange(enemies);
            _automatons.Add(gameBackground);
            _automatons.Add(player);
            _automatons.AddRange(enemies);
        }

        public void Update(TimeSpan delta)
        {
            _automatons.ForEach(x => x.Update(delta));
        }

        public void Draw()
        {
            World.DrawBackgroundColor(Color.Black);
            _camera.Draw(_visuals);
        }

        private void UpdateCamera(Direction direction)
        {
            _camera.Move(new Vector2((float) direction.HDir, (float) direction.VDir));
        }
    }
}
