using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

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

        private GUI() { }

        public void Prepare(Game game)
        {
            _graphics = new GraphicsDeviceManager(game);

        }

        public void Initial(Game game)
        {
            _spriteBatch = new SpriteBatch(game.GraphicsDevice);
            TextureManager.Instance.Initialize(_graphics.GraphicsDevice);
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
