using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazZeczny.GameLogic;
using WazZeczny.Interface;

namespace WazZeczny.Commands
{
    class SwipeRightOptionSnake1 : CommandBuilder
    {
        public SwipeRightOptionSnake1(GameStateBuilder builder) : base(builder)
        {
        }

        override public void Execute()
        {
            _builder.Snake1SwipeRight();
            GUIProxy.ChooseSnake1($"Snake1: {_builder.Snake1}");
        }
    }
}
