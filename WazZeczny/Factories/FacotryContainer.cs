using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazZeczny.Interface;

namespace WazZeczny.Factories
{
    public class FacotryContainer
    {
        public ICommandFactory Snake1Command { get; }

        public ICommandFactory Snake2Command { get; }

        public ICommandFactory Snake3Command { get; }
        public FacotryContainer(ICommandFactory snake1command, ICommandFactory snake2command, ICommandFactory snake3command)
        {
            Snake1Command = snake1command;
            Snake2Command = snake2command;
            Snake3Command = snake3command;
        }
    }
}
