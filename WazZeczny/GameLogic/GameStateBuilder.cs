using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazZeczny.Enum;

namespace WazZeczny.GameLogic
{
    public class GameStateBuilder
    {
        const int SnakeOptionSize = 3;
        public SnakeControllType Snake1 { get; set; }

        public SnakeControllType Snake2 { get; set; }

        public SnakeControllType Snake3 { get; set; }

        public GameStateBuilder()
        {
            Snake1 = SnakeControllType.USER;
            Snake2 = SnakeControllType.OFF;
            Snake3 = SnakeControllType.OFF;
        }

        public void Snake1SwipeLeft()
        {
            int snakeControllType = (int)(Snake1 + 1 + SnakeOptionSize);
            Snake1 = (SnakeControllType)(snakeControllType % SnakeOptionSize);
            GUIProxy.ChooseSnake1($"Snake1: {Snake1}");
        }

        public void Snake1SwipeRight()
        {
            int snakeControllType = (int)(Snake1 + 1 + SnakeOptionSize);
            Snake1 = (SnakeControllType)(snakeControllType % SnakeOptionSize);
            GUIProxy.ChooseSnake1($"Snake1: {Snake1}");
        }

        public void Snake2SwipeLeft()
        {
            int snakeControllType = (int)(Snake2 - 1 + SnakeOptionSize);
            Snake2 = (SnakeControllType)(snakeControllType % SnakeOptionSize);
            GUIProxy.ChooseSnake2($"Snake2: {Snake2}");
        }

        public void Snake2SwipeRight()
        {
            int snakeControllType = (int)(Snake2 + 1 + SnakeOptionSize);
            Snake2 = (SnakeControllType)(snakeControllType % SnakeOptionSize);
            GUIProxy.ChooseSnake2($"Snake2: {Snake2}");
        }

        public void Snake3SwipeLeft()
        {
            int snakeControllType = (int)(Snake3 - 1 + SnakeOptionSize);
            Snake3 = (SnakeControllType)(snakeControllType % SnakeOptionSize);
            GUIProxy.ChooseSnake3($"Snake3: {Snake3}");
        }

        public void Snake3SwipeRight()
        {
            int snakeControllType = (int)(Snake3 + 1 + SnakeOptionSize);
            Snake3 = (SnakeControllType)(snakeControllType % SnakeOptionSize);
            GUIProxy.ChooseSnake3($"Snake3: {Snake3}");
        }
    }
}
