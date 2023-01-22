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
    public class GameRunning : State
    {
        public GameRunning(GameState gameState, GameStateBuilder gameBuilder) : base(gameState, gameBuilder)
        {
        }

        public override State Handle(KeyEventArgs e)
        {
            e.Handled = true;
            if (_gameState.snake.GameOver)
            {
                return new Start(_gameState, _gameBuilder);
            }
            switch (e.Key)
            {
                case Key.Left:
                    _gameState.snake.ChangeDirection(Direction.Left);
                    break;
                case Key.Right:
                    _gameState.snake.ChangeDirection(Direction.Right);
                    break;
                case Key.Up:
                    _gameState.snake.ChangeDirection(Direction.Up);
                    break;
                case Key.Down:
                    _gameState.snake.ChangeDirection(Direction.Down);
                    break;
                case Key.Space:
                    _gameState.snake.Restore(10);
                    break;
            }
            return this;
        }
    }
}
