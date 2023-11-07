using EyesGUI;
using EyesGUITester.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EyesGUITester
{
    public class EyesGUITesterMain : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private MainScreen _screen;

        public EyesGUITesterMain()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            GUI.Content = Content;

            Window.AllowUserResizing = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _screen = new MainScreen(
                new Rectangle(
                    0, 0, 
                    _graphics.GraphicsDevice.Viewport.Width,
                    _graphics.GraphicsDevice.Viewport.Height
            ));

            GUI.Frame = _screen;
        }

        protected override void Update(GameTime gameTime)
        {
            GUI.Update();
            PlayerInput.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            GUI.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}