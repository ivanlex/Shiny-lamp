using EyesGUI;
using EyesGUITester.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EyesGUITester
{
    public class EyesGUITesterMain : Game
    {
        private MainScreen _screen;

        public EyesGUITesterMain()
        {
            GUI.Instance.Prepare(this);
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            GUI.Instance.Initial();

            _screen = new MainScreen(
                new Rectangle(
                    0, 0,
                    GUI.Instance.Graphics.GraphicsDevice.Viewport.Width,
                    GUI.Instance.Graphics.GraphicsDevice.Viewport.Height)
            );

            GUI.Instance.Frame = _screen;
        }

        protected override void Update(GameTime gameTime)
        {
            GUI.Instance.Update();
            PlayerInput.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            GUI.Instance.Draw();

            base.Draw(gameTime);
        }
    }
}