using System;
using Microsoft.Xna.Framework;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.UserInterface;

namespace Dots.Scenes
{
    public class MainMenu : IScene
    {
        public void Init()
        {
            Input.ClearBindings();
            Input.On(Control.Start, () => World.NavigateToScene("Game"));
        }

        public void Update(TimeSpan delta)
        {
        }

        public void Draw()
        {
            UI.DrawBackgroundColor(Color.Black);
            UI.DrawCentered("Images/Backgrounds/mainmenu", new Vector2(1600, 900));
            UI.DrawCenteredWithOffset("Images/Logo/dots", new Vector2(0, -140));
            UI.DrawCenteredWithOffset("Images/Logo/pressenter", new Vector2(0, 200));
        }
    }
}
