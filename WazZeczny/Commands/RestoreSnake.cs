using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazZeczny.GameLogic;
using WazZeczny.Interface;

namespace WazZeczny.Commands
{
    class RestoreSnake : CommandChangeDir
    {
        public RestoreSnake(Snake snake) : base(snake)
        {
            Dir = Direction.Left;
        }

        override public void Execute()
        {
            _snake.Restore(10);
        }
    }
}
