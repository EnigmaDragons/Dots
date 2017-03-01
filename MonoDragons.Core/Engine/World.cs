using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using MonoDragons.Core.EventSystem;
using MonoDragons.Core.UI;

namespace MonoDragons.Core.Engine
{
    public static class World
    {
        private static readonly Events _events = new Events();

        private static Game _game;
        private static ContentManager _content;
        private static SpriteBatch _spriteBatch;
        private static INavigation _navigation;
        private static SceneContents _sceneContents;

        public static void Init(Game game, INavigation navigation, SpriteBatch spriteBatch)
        {
            _game = game;
            _content = game.Content;
            _navigation = navigation;
            _spriteBatch = spriteBatch;
            _sceneContents = new SceneContents(_content);
            DefaultFont.Load(_content);
        }

        public static void Draw(Texture2D texture, Rectangle rectangle, Color color)
        {
            _sceneContents.Put(texture.GetHashCode().ToString(), texture);
            _spriteBatch.Draw(texture, rectangle, color);
        }

        public static void PlaySound(string soundName)
        {
            Load<SoundEffect>(soundName).Play();
        }

        public static void PlayMusic(string songName)
        {
            MediaPlayer.Stop();
            MediaPlayer.Play(Load<Song>(songName));
        }

        private static T Load<T>(string resourceName) where T : IDisposable
        {
            return _sceneContents.Load<T>(resourceName);
        }

        public static void NavigateToScene(string sceneName)
        {
            var oldSceneContents = _sceneContents;
            _sceneContents = new SceneContents(_content);
            _navigation.NavigateTo(sceneName);
            oldSceneContents.Dispose();
        }

        public static void DrawBrackgroundColor(Color color)
        {
            _game.GraphicsDevice.Clear(color);
        }

        public static void Draw(string imageName, Vector2 pixelPosition)
        {
            _spriteBatch.Draw(Load<Texture2D>(imageName), pixelPosition);
        }

        public static void Draw(string imageName, Rectangle rectPostion)
        {
            _spriteBatch.Draw(Load<Texture2D>(imageName), rectPostion, Color.White);
        }

        public static void DrawText(string text, Vector2 position, Color color)
        {
            _spriteBatch.DrawString(DefaultFont.Font, text, position, color);
        }

        public static void Publish<T>(T payload)
        {
            _events.Publish(payload);
        }

        public static void Subscribe<T>(EventSubscription<T> subscription)
        {
            _events.Subscribe(subscription);
            _sceneContents.Put(Guid.NewGuid().ToString(), subscription);
        }

        public static void Unsubscribe(object owner)
        {
            _events.Unsubscribe(owner);
        }

        public static void DrawRectangle(Rectangle rectangle, Color color)
        {
            var rect = CreateRectangleTexture(rectangle.Width, rectangle.Height, color);
            _sceneContents.Put(Guid.NewGuid().ToString(), rect);
            _spriteBatch.Draw(rect, rectangle, color);
        }

        private static Texture2D CreateRectangleTexture(int width, int height, Color color)
        {
            var data = new Color[width * height];
            for (var i = 0; i < data.Length; ++i)
                data[i] = color;

            var texture = new Texture2D(_game.GraphicsDevice, width, height);
            texture.SetData(data);
            return texture;
        }

        public static void Draw(Texture2D texture, Vector2 position)
        {
            _sceneContents.Put(texture.GetHashCode().ToString(), texture);
            _spriteBatch.Draw(texture, position);
        }
    }
}
