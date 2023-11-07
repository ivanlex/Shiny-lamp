using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EyesGUI
{
    public delegate void ButtonClickHandler();

    public class GUIButton : GUIComponent
    {
        public Texture2D Foreground;

        public ButtonClickHandler OnClick;

        public GUIButton(Rectangle rectangle) : base(rectangle)
        {
            LoadContent();
        }

        private void LoadContent()
        {
            Foreground = GUI.Content.Load<Texture2D>("Textures/TextureSample");
        }

        public override void Update()
        {
            base.Update();

            if (Rect.Contains(PlayerInput.MousePosition))
            {
                if (PlayerInput.IsMouseClicked())
                {
                    OnClick?.Invoke();
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.Begin();
            spriteBatch.Draw(Foreground, Rect, Color.White);
            spriteBatch.End();
        }
    }
}
