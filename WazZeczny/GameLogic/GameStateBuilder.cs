using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazZeczny.Enum;
using WazZeczny.Factories;
using WazZeczny.Interface;

namespace WazZeczny.GameLogic
{
    public class GameStateBuilder
    {
        const int SnakeOptionSize = 3;

        private int rows = 15, cols = 30;

        public SnakeControllType Snake1 { get; set; }

        public SnakeControllType Snake2 { get; set; }

        public SnakeControllType Snake3 { get; set; }

        public GameStateBuilder()
        {
            Snake1 = SnakeControllType.USER;
            Snake2 = SnakeControllType.OFF;
            Snake3 = SnakeControllType.OFF;
        }

        public GameState Build()
        {
            var snakes = new List<Snake>();
            ICommandFactory snake1 = new DoNothingFactory();
            ICommandFactory snake2 = new DoNothingFactory();
            ICommandFactory snake3 = new DoNothingFactory();
            if (Snake1 == SnakeControllType.USER)
            {
                var snake = new Snake();
                snakes.Add(snake);
                snake1 = new SnakeChangeDirFactory(snake);
            }
            if (Snake2 == SnakeControllType.USER)
            {
                var snake = new Snake();
                snakes.Add(snake);
                snake2 = new SnakeChangeDirFactory(snake);
            }
            if (Snake3 == SnakeControllType.USER)
            {
                var snake = new Snake();
                snakes.Add(snake);
                snake3 = new SnakeChangeDirFactory(snake);
            }
            return new GameState(rows, cols, snakes, new FacotryContainer(snake1, snake2, snake3));
        }

        public void Snake1SwipeLeft()
        {
            int snakeControllType = (int)(Snake1 - 1 + SnakeOptionSize);
            Snake1 = (SnakeControllType)(snakeControllType % SnakeOptionSize);
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
