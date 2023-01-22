using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WazZeczny.GameLogic;
using WazZeczny.Interface;
using WazZeczny.States;

namespace WazZeczny.States
{
    public class Start : State
    {
        public Start(GameState gameState, GameStateBuilder gameBuilder) : base(gameState, gameBuilder)
        {
        }

        public override State Handle(KeyEventArgs e)
        {
            e.Handled = true;
            switch (e.Key)
            {
                case Key.Up:
                    GUIProxy.SwitchSnake3();
                    return new Snake3Set(_gameState, _gameBuilder);
                case Key.Down:
                    GUIProxy.SwitchSnake1();
                    return new Snake1Set(_gameState, _gameBuilder);
                case Key.Space:
                    return new GameRunning(_gameState, _gameBuilder);
                default:
                    return this;
            }
        }
    }
}
