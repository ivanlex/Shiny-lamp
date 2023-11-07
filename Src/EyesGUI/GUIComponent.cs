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
        /// The point for position and resize control
        /// </summary>
        public Point Anchor { get; set; }
        /// <summary>
        /// The point for rotation control
        /// </summary>
        public Point Pivot { get; set; }


        public GUIComponent(Rectangle rectangle)
        {
            Rect = rectangle;
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
