using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using WazZeczny.GameLogic;
using WazZeczny.Interface;

namespace WazZeczny.StrategiesAI
{
    public class CircleAI : StrategyAI
    {
        private Direction _lastDir = Direction.Right; 
        private int _counter = 0;
        public CircleAI(Player player) : base(player)
        {
        }

        public override void Execute()
        {
            _counter = (_counter + 1) % 5;
            if(_counter != 0 )
            {
                return;
            }
            _lastDir = GetNextDir();
            _player.ChangeDirection(_lastDir);
        }

        private Direction GetNextDir()
        {
            if(_lastDir == Direction.Left)
            {
                return Direction.Up;
            }
            else if (_lastDir == Direction.Up)
            {
                return Direction.Right;
            }
            else if (_lastDir == Direction.Right)
            {
                return Direction.Down;
            }
            else
            {
                return Direction.Left;
            }
        }
    }
}
