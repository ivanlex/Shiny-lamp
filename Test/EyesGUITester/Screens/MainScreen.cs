using EyesGUI;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EyesGUITester.Screens
{
    public class MainScreen : GUIComponent
    {
        private const int ButtonWidth = 100;
        private const int ButtonHeight = 100;
        private const int Margin = 10;

        private GUIButton _button1;
        private GUIButton _button2;
        private GUIButton _button3;

        public MainScreen(Rectangle rectangle) : base(rectangle)
        {
            _button1 = new GUIButton(new Rectangle(Margin, 10, ButtonWidth, ButtonHeight))
            {
                OnClick = () =>
                {
                    MessageBox.Show("Hello World");
                }
            };
            _button2 = new GUIButton(new Rectangle(_button1.Rect.X + _button1.Rect.Width + Margin, 10, ButtonWidth, ButtonHeight));
            _button3 = new GUIButton(new Rectangle(_button2.Rect.X + _button2.Rect.Width + Margin, 10, ButtonWidth, ButtonHeight));

            if (Children is null)
            {
                Children = new List<GUIComponent>();
            }

            Children.Add(_button1);
            Children.Add(_button2);
            Children.Add(_button3);
        }
    }
}
