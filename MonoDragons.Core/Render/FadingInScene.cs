using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;

namespace MonoDragons.Core.Render
{
    public sealed class FadingInScene : IScene
    {
        private readonly TimeSpan _duration;
        private readonly Func<IScene> _sceneFactory;
        
        private double _elapsedMillis;
        private bool _hasBegun;

        private IScene _scene;

        public FadingInScene(IScene scene)
            : this (TimeSpan.FromMilliseconds(2000), scene) { }

        public FadingInScene(TimeSpan duration, IScene scene)
            : this (duration, () => scene) { }

        public FadingInScene(TimeSpan duration, Func<IScene> sceneFactory)
        {
            _duration = duration;
            _sceneFactory = sceneFactory;
        }

        public void Init()
        {
            _scene = _sceneFactory.Invoke();
            _scene.Init();
        }

        public void Update(TimeSpan delta)
        {
            if (!_hasBegun)
            {
                _elapsedMillis += delta.TotalMilliseconds;
                _hasBegun = _elapsedMillis > _duration.TotalMilliseconds;
                return;
            }

            _scene.Update(delta);
        }

        public void Draw()
        {
            _scene.Draw();

            if (!_hasBegun)
                World.DrawRectangle(new Rectangle(0, 0, 1920, 1080),
                    Color.FromNonPremultiplied(0, 0, 0, (int)(255 - 255 * (_elapsedMillis / _duration.TotalMilliseconds))));
        }
    }
}
