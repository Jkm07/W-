using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WazZeczny.GameLogic;
using WazZeczny.Interface;
using WazZeczny.Commands;

namespace WazZeczny.States
{
    public class Start : State
    {
        public Start(GameState gameState, GameStateBuilder gameBuilder) : base(gameState, gameBuilder)
        {
            KEY_UP = new GoToOptionSnake3();
            KEY_DOWN = new GoToOptionSnake3();
        }

        public override State Handle(KeyEventArgs e)
        {
            e.Handled = true;
            switch (e.Key)
            {
                case Key.Up:
                    KEY_UP.Execute();
                    return new Snake3Set(_gameState, _gameBuilder);
                case Key.Down:
                    KEY_DOWN.Execute();
                    return new Snake1Set(_gameState, _gameBuilder);
                case Key.Space:
                    return new GameRunning(_gameState, _gameBuilder);
                default:
                    return this;
            }
        }
    }
}
