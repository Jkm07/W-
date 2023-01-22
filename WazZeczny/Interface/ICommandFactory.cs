using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WazZeczny.Interface
{
    public interface ICommandFactory
    {
        CommandChangeDir CreateCommand();

        CommandChangeDir CreateSpecialMoveCommand();

    }
}
