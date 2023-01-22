using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazZeczny.GameLogic;
using WazZeczny.Interface;

namespace WazZeczny.Commands
{
    class SwipeRightOptionSnake3 : CommandBuilder
    {
        public SwipeRightOptionSnake3(GameStateBuilder builder) : base(builder)
        {
        }

        override public void Execute()
        {
            _builder.Snake3SwipeRight();
            GUIProxy.ChooseSnake3($"Snake3: {_builder.Snake3}");
        }
    }
}
