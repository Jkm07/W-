using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazZeczny.GameLogic;
using WazZeczny.Interface;

namespace WazZeczny.Commands
{
    class GoToOptionSnake1 : Command
    {
        override public void Execute()
        {
            GUIProxy.SwitchSnake1();
        }
    }
}
