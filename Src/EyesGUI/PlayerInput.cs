using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace EyesGUI
{
    public static class PlayerInput
    {
        static MouseState _oldMouseState;
        static MouseState _currentMouseState;

        public static bool IsMouseClicked()
        {
            return _oldMouseState.LeftButton == ButtonState.Pressed && _currentMouseState.LeftButton == ButtonState.Released;
        }

        public static bool IsMouseRightClicked()
        {
            return _oldMouseState.RightButton == ButtonState.Pressed && _currentMouseState.RightButton == ButtonState.Released;
        }

        public static bool IsMouseMiddleClicked()
        {
            return _oldMouseState.MiddleButton == ButtonState.Pressed && _currentMouseState.MiddleButton == ButtonState.Released;
        }

        [Obsolete]
        public static bool IsMouseDoubleClicked()
        {
            throw new NotImplementedException();
        }

        public static bool IsMouseWheeled()
        {
            return HorizontalScrollWheelOffset > 0;
        }

        public static Vector2 MousePosition
        {
            get => new Vector2(_currentMouseState.X, _currentMouseState.Y);
        }

        public static int HorizontalScrollWheelOffset
        {
            get => _currentMouseState.HorizontalScrollWheelValue - _oldMouseState.HorizontalScrollWheelValue;
        }

        public static void Update()
        {
            // For current time
            _oldMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();
        }
    }
}
