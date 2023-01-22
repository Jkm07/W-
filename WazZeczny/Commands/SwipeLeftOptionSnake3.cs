using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WazZeczny.GameLogic;
using WazZeczny.Interface;

namespace WazZeczny.Commands
{
    class SwipeLeftOptionSnake3 : CommandBuilder
    {
        public SwipeLeftOptionSnake3(GameStateBuilder builder) : base(builder)
        {
        }

        override public void Execute()
        {
            _builder.Snake3SwipeLeft();
            GUIProxy.ChooseSnake3($"Snake3: {_builder.Snake3}");
        }
    }
}
