using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;

namespace Dots.Scenes
{
    public class MainMenu : IScene
    {
        public void Init()
        {
            Input.On(Control.Start, () => World.NavigateToScene("GameBackground"));
        }

        public void Update(TimeSpan delta)
        {
        }

        public void Draw()
        {
            World.DrawBrackgroundColor(Color.Black);
            World.Draw("Images/Backgrounds/mainmenu", new Rectangle(0, 0, 1600, 900));
            World.Draw("Images/Logo/dots", new Vector2(520, 220));
            World.Draw("Images/Logo/pressenter", new Vector2(340, 600));
        }
    }
}
