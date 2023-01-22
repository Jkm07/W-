using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WazZeczny.GameLogic;
using WazZeczny.Interface;

namespace WazZeczny.States
{
    public class Snake2Set : State
    {
        public Snake2Set(GameState gameState, GameStateBuilder gameBuilder) : base(gameState, gameBuilder)
        {
        }

        public override State Handle(KeyEventArgs e)
        {
            e.Handled = true;
            switch (e.Key)
            {
                case Key.Up:
                    GUIProxy.SwitchSnake1();
                    return new Snake1Set(_gameState, _gameBuilder);
                case Key.Down:
                    GUIProxy.SwitchSnake3();
                    return new Snake3Set(_gameState, _gameBuilder);
                case Key.Left:
                    _gameBuilder.Snake2SwipeLeft();
                    return this;
                case Key.Right:
                    _gameBuilder.Snake2SwipeRight();
                    return this;
                case Key.Space:
                    return new GameRunning(_gameState, _gameBuilder);
                default:
                    return this;
            }
        }
    }
}
