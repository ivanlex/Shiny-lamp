using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace EyesGUI
{
    public static class PlayerInput
    {
        const int DoubleClickValidDistance = 5;

        static MouseState _oldMouseState;
        static MouseState _currentMouseState;

        static bool _isLastTimeClicked = false;
        static Vector2 _clickPosition;

        public static bool IsMouseClicked()
        {
            return _oldMouseState.LeftButton == ButtonState.Pressed && _currentMouseState.LeftButton == ButtonState.Released;
        }

        public static bool IsMouseDoubleClicked()
        {
            var lastTime = _isLastTimeClicked;
            var distance = Vector2.DistanceSquared(MousePosition, _clickPosition) < DoubleClickValidDistance * DoubleClickValidDistance;

            return lastTime && distance;
        }

        public static Vector2 MousePosition
        {
            get => new Vector2(_currentMouseState.X, _currentMouseState.Y);
        }

        public static void Update()
        {
            // For last time
            _isLastTimeClicked = IsMouseClicked();

            if (_isLastTimeClicked)
            {
                _clickPosition = new Vector2(_currentMouseState.X, _currentMouseState.Y);
            }

            // For current time
            _oldMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();
        }
    }
}
