using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WazZeczny.Interface;

namespace WazZeczny.States
{
    public class DoNothing : State
    {
        public DoNothing(GameState gameState) : base(gameState, null)
        {
        }

        public override State Handle(KeyEventArgs e)
        {
            return this;
        }
    }
}
