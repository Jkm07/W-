using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazZeczny.Commands;
using WazZeczny.Interface;

namespace WazZeczny.Factories
{
    public class DoNothingFactory : ICommandFactory
    {
        public CommandChangeDir CreateCommand()
        {
            return new DoNothing();
        }

        public CommandChangeDir CreateSpecialMoveCommand()
        {
            return new DoNothing();
        }
    }
}
