using System;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.UserInterface;

namespace Dots.Scenes
{
    public class Logo : IScene
    {
        private bool _begunTransition;

        public void Init()
        {
        }

        public async void Update(TimeSpan delta)
        {
            if (_begunTransition)
                return;
            
            _begunTransition = true;
            await Task.Delay(2000);
            World.NavigateToScene("MainMenu");
        }

        public void Draw()
        {
            UI.DrawBackgroundColor(Color.Black);
            UI.DrawCentered("Images/Logo/enigmadragons");
        }
    }
}
