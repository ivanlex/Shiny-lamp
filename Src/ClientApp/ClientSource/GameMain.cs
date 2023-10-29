using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;

namespace ClientApp.ClientSource
{
    public class GameMain : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Model _boxesModel;
        private Texture2D _boxTexture;

        private MouseState _oldMouseState;
        private MouseState _mouseState;

        private bool _buttonSelected;
        private Rectangle _buttonRect;

        private Vector2 _playMouseInput
        {
            get => new Vector2(_mouseState.X, _mouseState.Y);
        }

        public int GraphicsWidth
        {
            get;
            private set;
        }

        public int GraphicsHeight
        {
            get;
            private set;
        }

        public GameMain()
        {
            _graphics = new GraphicsDeviceManager(this)
            {
                IsFullScreen = false,
                GraphicsProfile = GraphicsProfile.HiDef
            };
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);            

            _boxesModel = Content.Load<Model>("Boxes");
            _boxTexture = Content.Load<Texture2D>("BoxesTexture");

            _buttonRect = new Rectangle(10, 10, _boxTexture.Width, _boxTexture.Height);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            _mouseState = Mouse.GetState();

            if (_buttonRect.Contains(_playMouseInput) && _mouseState.LeftButton == ButtonState.Released && _oldMouseState.LeftButton == ButtonState.Pressed)
            {
                Debug.WriteLine("Button on clicked");
            }

            _oldMouseState = _mouseState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            _spriteBatch.Draw(_boxTexture, _buttonRect, Color.AliceBlue);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}