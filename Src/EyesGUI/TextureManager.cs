using Microsoft.Xna.Framework.Graphics;

namespace EyesGUI
{
    public class TextureManager
    {
        private static object _locker = new object();
        private static TextureManager _instance;

        private Dictionary<string, Texture2D> _textures = new Dictionary<string, Texture2D>();
        private GraphicsDevice _graphicsDevice;

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

        public void Initialize(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }

        public void AddTexture(string textureKey, string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(filePath);
            }

            var texture2D = Texture2D.FromFile(_graphicsDevice, filePath);

            _textures.Add(textureKey, texture2D);
        }

        public Texture2D GetTexture(string textureKey)
        {
            ArgumentNullException.ThrowIfNull(textureKey);

            if (!_textures.ContainsKey(textureKey))
            {
                throw new KeyNotFoundException($"Asset not found {textureKey}");
            }

            return _textures[textureKey];
        }
    }
}
