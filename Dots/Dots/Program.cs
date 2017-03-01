using System;
using System.Collections.Generic;
using Dots.Scenes;
using Microsoft.Xna.Framework.Input;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;
using MonoDragons.Core.Render;

namespace Dots
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new MainGame("Logo", new ScreenSettings(1600, 900, false), CreateSceneFactory(), CreateKeyboardController()))
                game.Run();
        }

        private static IController CreateKeyboardController()
        {
            return new KeyboardController(new Map<Keys, Control>
            {
                { Keys.Enter, Control.Start }
            });
        }

        private static SceneFactory CreateSceneFactory()
        {
            return new SceneFactory(new Dictionary<string, Func<IScene>>
            {
                { "PlayerTest", () => new PlayerTest() },
                { "MainMenu", () => new FadingInScene(new MainMenu()) },
                { "Game", () => new Game() },
                { "Logo", () => new FadingInScene(new Logo()) },
            });
        }
    }
#endif
}
