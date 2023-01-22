using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazZeczny.GameLogic;

namespace WazZeczny.Interface
{
    public abstract class CommandChangeDir : Command
    {
        protected Snake _snake;
        public Direction Dir { get; set; }
        public CommandChangeDir(Snake snake)
        {
            _snake = snake;
        }
    }
}
