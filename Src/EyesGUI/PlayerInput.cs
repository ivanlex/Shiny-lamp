using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EyesGUI
{
    public static class PlayerInput
    {
        static MouseState oldMouseState;
        static MouseState currentMouseState;

        public static bool IsMouseClicked()
        {
            return oldMouseState.LeftButton == ButtonState.Pressed && currentMouseState.LeftButton == ButtonState.Released;
        }

        public static Vector2 MousePosition
        {
            get => new Vector2(currentMouseState.X, currentMouseState.Y);
        }

        public static void Update()
        {
            oldMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
        }
    }
}
