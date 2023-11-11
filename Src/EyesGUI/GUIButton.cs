using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EyesGUI
{
    public delegate void ButtonClickHandler();
    public delegate void ButtonRightClickHandler();
    public delegate void ButtonMiddleClickHandler();
    public delegate void ButtonWheeledHandler(int positionChanged);

    public class GUIButton : GUIComponent
    {
        public Texture2D Foreground;

        public ButtonClickHandler OnClick;
        public ButtonRightClickHandler OnRightClick;
        public ButtonMiddleClickHandler OnMiddleClick;
        public ButtonWheeledHandler OnWheeled;

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
                else if (PlayerInput.IsMouseRightClicked())
                {
                    OnRightClick?.Invoke();
                }
                else if (PlayerInput.IsMouseMiddleClicked())
                {
                    OnMiddleClick?.Invoke();
                }
                else if (PlayerInput.IsMouseWheeled())
                {
                    OnWheeled?.Invoke(PlayerInput.HorizontalScrollWheelOffset);
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
