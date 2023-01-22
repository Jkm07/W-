using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WazZeczny.Commands;
using WazZeczny.GameLogic;
using WazZeczny.Interface;

namespace WazZeczny.States
{
    public class Snake3Set : State
    {
        public Snake3Set(GameState gameState, GameStateBuilder gameBuilder) : base(gameState, gameBuilder)
        {
            KEY_UP = new GoToOptionSnake2();
            KEY_DOWN = new GoToOptionSnake1();
            KEY_LEFT = new SwipeLeftOptionSnake3(gameBuilder);
            KEY_RIGHT = new SwipeRightOptionSnake3(gameBuilder);
        }

        public override State Handle(KeyEventArgs e)
        {
            e.Handled = true;
            switch (e.Key)
            {
                case Key.Up:
                    KEY_UP.Execute();
                    return new Snake2Set(_gameState, _gameBuilder);
                case Key.Down:
                    KEY_DOWN.Execute();
                    return new Snake1Set(_gameState, _gameBuilder);
                case Key.Left:
                    KEY_LEFT.Execute();
                    return this;
                case Key.Right:
                    KEY_RIGHT.Execute();
                    return this;
                case Key.Space:
                    return new GameRunning(_gameState, _gameBuilder);
                default:
                    return this;
            }
        }
    }
}
