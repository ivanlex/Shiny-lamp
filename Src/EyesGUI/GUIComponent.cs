using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EyesGUI
{
    public abstract class GUIComponent
    {
        /// <summary>
        /// The parent component
        /// </summary>
        public GUIComponent? Parent { get; set; }
        /// <summary>
        /// The children components
        /// </summary>
        public List<GUIComponent>? Children { get; set; }
        /// <summary>
        /// The position and size for the Component
        /// </summary>
        public Rectangle Rect { get; set; }
        /// <summary>
        /// The Asset for GUIComponent
        /// </summary>
        public string AssetKey { get; set; }
        /// <summary>
        /// The point for position and resize control
        /// </summary>
        public Point Anchor { get; set; }
        /// <summary>
        /// The point for rotation control
        /// </summary>
        public Point Pivot { get; set; }

        protected abstract void LoadContent();

        public GUIComponent(Rectangle rectangle) : this(rectangle, string.Empty) { }

        public GUIComponent(Rectangle rectangle, string assetKey)
        {
            Rect = rectangle;
            AssetKey = assetKey;

            LoadContent();
        }

        /// <summary>
        /// Data update logical for UI
        /// </summary>
        public virtual void Update() { }

        /// <summary>
        /// Drawing logical for UI
        /// </summary>
        public virtual void Draw(SpriteBatch spriteBatch) { }
    }
}
