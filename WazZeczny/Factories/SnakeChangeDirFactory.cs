using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazZeczny.Commands;
using WazZeczny.GameLogic;
using WazZeczny.Interface;

namespace WazZeczny.Factories
{
    public class SnakeChangeDirFactory : ICommandFactory
    {
        private Snake _snake;

        public SnakeChangeDirFactory(Snake snake)
        {
            _snake = snake;
        }

        public CommandChangeDir CreateCommand()
        {
            return new ChangeDirectionSnake(_snake);
        }

        public CommandChangeDir CreateSpecialMoveCommand()
        {
            return new RestoreSnake(_snake);
        }
    }
}
