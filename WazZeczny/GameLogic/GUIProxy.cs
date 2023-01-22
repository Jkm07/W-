using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WazZeczny.GameLogic
{
    public class GUIProxy
    {
        private static MainWindow _window;

        public GUIProxy(MainWindow window)
        {
            _window = window;
        }

        public static void ChooseSnake1(string text)
        {
            _window.ChangeTextOfSnake1(text);
            _window.SetActiveSnake1();
            _window.SetUnactiveSnake2();
            _window.SetUnactiveSnake3();
        }

        public static void ChooseSnake2(string text)
        {
            _window.ChangeTextOfSnake2(text);
            _window.SetUnactiveSnake1();
            _window.SetActiveSnake2();
            _window.SetUnactiveSnake3();
        }

        public static void ChooseSnake3(string text)
        {
            _window.ChangeTextOfSnake3(text);
            _window.SetUnactiveSnake1();
            _window.SetUnactiveSnake2();
            _window.SetActiveSnake3();
        }

        public static void SwitchSnake1()
        {
            _window.SetActiveSnake1();
            _window.SetUnactiveSnake2();
            _window.SetUnactiveSnake3();
        }

        public static void SwitchSnake2()
        {
            _window.SetUnactiveSnake1();
            _window.SetActiveSnake2();
            _window.SetUnactiveSnake3();
        }

        public static void SwitchSnake3()
        {
            _window.SetUnactiveSnake1();
            _window.SetUnactiveSnake2();
            _window.SetActiveSnake3();
        }

        public static void Draw()
        {
            _window.Draw();
        }

    }
}
