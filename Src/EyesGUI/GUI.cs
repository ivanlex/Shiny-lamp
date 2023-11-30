using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EyesGUI
{
    public class GUI
    {
        private static object _lock = new object();
        private static GUI _instance;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ContentManager _content;
        private GUIComponent _frame;
        private Game _game;

        public ContentManager Content
        {
            get => _content;
        }

        public SpriteBatch SpriteBatch
        {
            get => _spriteBatch;
        }

        public GraphicsDeviceManager Graphics
        {
            get => _graphics;
        }

        public GUIComponent Frame
        {
            get => _frame;
            set => _frame = value;
        }

        private GUI() { }

        public static GUI Instance
        {
            get
            {
                lock(_lock)
                {
                    if(_instance == null)
                    {
                        lock (_lock)
                        {
                            _instance = new GUI();
                        }
                    }

                    return _instance;
                }
            }
        }

        public void Prepare(Game game)
        {
            _game = game;

            _graphics = new GraphicsDeviceManager(_game);
            _graphics.IsFullScreen = true;

            _content = _game.Content;

            _game.Content.RootDirectory = "Content";
            _game.IsMouseVisible = true;
            _game.Window.AllowUserResizing = true;
            
        }

        public void Initial()
        {
            _spriteBatch = new SpriteBatch(_game.GraphicsDevice);
            TextureManager.Instance.Initialize(_graphics.GraphicsDevice, _content);
        }

        public void DrawChildren(GUIComponent Frame, SpriteBatch spriteBatch)
        {
            if (Frame.Children != null)
            {
                foreach (var child in Frame.Children)
                {
                    child.Draw(spriteBatch);

                    DrawChildren(child, spriteBatch);
                }
            }
        }

        public void UpdateChildren(GUIComponent Frame)
        {
            if (Frame.Children != null)
            {
                foreach (var child in Frame.Children)
                {
                    child.Update();

                    UpdateChildren(child);
                }
            }
        }

        public void Update()
        {
            if (_frame != null)
            {
                _frame.Update();
                UpdateChildren(_frame);
            }
        }

        public void Draw()
        {
            if (_frame != null)
            {
                _frame.Draw(_spriteBatch);
                DrawChildren(_frame, _spriteBatch);
            }
        }
    }
}
