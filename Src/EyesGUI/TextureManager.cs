using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace EyesGUI
{
    public class TextureNotFoundException : Exception 
    { 
        public TextureNotFoundException(string message) : base(message) { }
    }

    public class TextureManager
    {
        public const string DefaultTexture = "DefaultTexture";

        private static object _locker = new object();
        private static TextureManager _instance;

        private Dictionary<string, Texture2D> _textures = new Dictionary<string, Texture2D>();
        private GraphicsDevice _graphicsDevice;
        private ContentManager _contentManager;

        public static TextureManager Instance
        {
            get
            {
                lock (_locker)
                {
                    if (_instance is null)
                    {
                        lock(_locker)
                        {
                            _instance = new TextureManager();
                        }
                    }

                    return _instance;
                }
            }
        }

        private TextureManager() { }

        public void Initialize(GraphicsDevice graphicsDevice, ContentManager contentManager)
        {
            _graphicsDevice = graphicsDevice;
            _contentManager = contentManager;

            AddTexture(DefaultTexture, "./Textures/TextureSample");
        }

        public void AddTexture(string textureKey, string assetName)
        {
            var texture2D = _contentManager.Load<Texture2D>(assetName);

            if (texture2D == null)
            {
                throw new FileNotFoundException(assetName);
            }

            _textures.Add(textureKey, texture2D);
        }

        public Texture2D GetTexture(string textureKey)
        {
            ArgumentNullException.ThrowIfNull(textureKey);            

            if (!_textures.ContainsKey(textureKey))
            {
                // TODO Make default texture for every component?
                throw new TextureNotFoundException($"Asset not found {textureKey}");
            }

            // TODO How to Add/Load texture dynamically?

            return _textures[textureKey];
        }
    }
}
