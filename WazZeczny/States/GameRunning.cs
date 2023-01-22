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
            if (_gameState.GameOver())
            {
                return new Start(_gameState, _gameBuilder);
            }
            CommandChangeDir command;
            switch (e.Key)
            {
                //Snake 1
                case Key.A:
                    command = _gameState.Factory.Snake1Command.CreateCommand();
                    command.Dir = Direction.Left;
                    command.Execute();
                    break;
                case Key.D:
                    command = _gameState.Factory.Snake1Command.CreateCommand();
                    command.Dir = Direction.Right;
                    command.Execute();
                    break;
                case Key.W:
                    command = _gameState.Factory.Snake1Command.CreateCommand();
                    command.Dir = Direction.Up;
                    command.Execute();
                    break;
                case Key.S:
                    command = _gameState.Factory.Snake1Command.CreateCommand();
                    command.Dir = Direction.Down;
                    command.Execute();
                    break;
                case Key.Space:
                    command = _gameState.Factory.Snake1Command.CreateSpecialMoveCommand();
                    command.Execute();
                    break;
                //Snake 2
                case Key.Left:
                    command = _gameState.Factory.Snake2Command.CreateCommand();
                    command.Dir = Direction.Left;
                    command.Execute();
                    break;
                case Key.Right:
                    command = _gameState.Factory.Snake2Command.CreateCommand();
                    command.Dir = Direction.Right;
                    command.Execute();
                    break;
                case Key.Up:
                    command = _gameState.Factory.Snake2Command.CreateCommand();
                    command.Dir = Direction.Up;
                    command.Execute();
                    break;
                case Key.Down:
                    command = _gameState.Factory.Snake2Command.CreateCommand();
                    command.Dir = Direction.Down;
                    command.Execute();
                    break;
                case Key.RightCtrl:
                    command = _gameState.Factory.Snake2Command.CreateSpecialMoveCommand();
                    command.Execute();
                    break;
                //Snake 3
                case Key.NumPad4:
                    command = _gameState.Factory.Snake3Command.CreateCommand();
                    command.Dir = Direction.Left;
                    command.Execute();
                    break;
                case Key.NumPad6:
                    command = _gameState.Factory.Snake3Command.CreateCommand();
                    command.Dir = Direction.Right;
                    command.Execute();
                    break;
                case Key.NumPad8:
                    command = _gameState.Factory.Snake3Command.CreateCommand();
                    command.Dir = Direction.Up;
                    command.Execute();
                    break;
                case Key.NumPad5:
                    command = _gameState.Factory.Snake3Command.CreateCommand();
                    command.Dir = Direction.Down;
                    command.Execute();
                    break;
                case Key.NumPad0:
                    command = _gameState.Factory.Snake3Command.CreateSpecialMoveCommand();
                    command.Execute();
                    break;
            }
            return this;
        }
    }
}
