using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazZeczny.GameLogic;
using WazZeczny.Interface;

namespace WazZeczny.Commands
{
    class SwipeRightOptionSnake2 : CommandBuilder
    {
        public SwipeRightOptionSnake2(GameStateBuilder builder) : base(builder)
        {
        }

        override public void Execute()
        {
            _builder.Snake2SwipeRight();
            GUIProxy.ChooseSnake2($"Snake2: {_builder.Snake2}");
        }
    }
}
