using System;
using System.Collections.Generic;
using Dots.Scenes;
using Microsoft.Xna.Framework.Input;
using MonoDragons.Core.Engine;
using MonoDragons.Core.Inputs;

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
            using (var game = new MainGame("PlayerTest", new ScreenSize(1600, 900), CreateSceneFactory(), CreateKeyboardContoller()))
                game.Run();
        }

        private static IController CreateKeyboardContoller()
        {
            return new KeyboardController(new Map<Keys, Control>
            {
            });
        }

        private static SceneFactory CreateSceneFactory()
        {
            return new SceneFactory(new Dictionary<string, Func<IScene>>
            {
                { "PlayerTest", () => new PlayerTest() },
            });
        }
    }
#endif
}
