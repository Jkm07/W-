using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WazZeczny.Interface
{
    public abstract class StrategyAI
    {
        protected Player _player { get; }

        protected StrategyAI(Player player) 
        {
            _player = player;
        }

        public virtual  void Execute() { }
    }
}
