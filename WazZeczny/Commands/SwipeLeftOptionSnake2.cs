using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazZeczny.GameLogic;
using WazZeczny.Interface;

namespace WazZeczny.Commands
{
    class SwipeLeftOptionSnake2 : CommandBuilder
    {
        public SwipeLeftOptionSnake2(GameStateBuilder builder) : base(builder)
        {
        }

        override public void Execute()
        {
            _builder.Snake2SwipeLeft();
            GUIProxy.ChooseSnake2($"Snake2: {_builder.Snake2}");
        }
    }
}
