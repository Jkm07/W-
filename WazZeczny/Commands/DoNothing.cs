using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazZeczny.GameLogic;
using WazZeczny.Interface;

namespace WazZeczny.Commands
{
    class DoNothing : CommandChangeDir
    {
        public DoNothing() : base(null)
        {
        }

        override public void Execute()
        {
        }
    }
}
