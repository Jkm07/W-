using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazZeczny.GameLogic;

namespace WazZeczny.Interface
{
    public abstract class CommandBuilder : Command
    {
        protected GameStateBuilder _builder;
        public CommandBuilder(GameStateBuilder builder)
        {
            _builder = builder;
        }
    }
}
