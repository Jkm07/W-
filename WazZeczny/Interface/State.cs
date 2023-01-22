using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WazZeczny.GameLogic;

namespace WazZeczny.Interface
{
    public abstract class State
    {
        protected GameState _gameState;

        protected GameStateBuilder _gameBuilder;
        public abstract State Handle(KeyEventArgs e);

        public Command KEY_UP, KEY_DOWN, KEY_LEFT, KEY_RIGHT;

        public State(GameState gameState, GameStateBuilder gameBuilder)
        {
            _gameState = gameState;
            _gameBuilder = gameBuilder;
        }
    }
}
