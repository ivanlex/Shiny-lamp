using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace EyesGUI
{
    public static class GUI
    {
        public static ContentManager Content { get; set; }

        public static GUIComponent Frame { get; set; }

        public static void DrawChildren(GUIComponent Frame, SpriteBatch spriteBatch)
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

        public static void UpdateChildren(GUIComponent Frame)
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

        public static void Update()
        {
            if (Frame != null)
            {
                Frame.Update();
                UpdateChildren(Frame);
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            if (Frame != null)
            {
                Frame.Draw(spriteBatch);
                DrawChildren(Frame, spriteBatch);
            }
        }
    }
}
