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
    public class StandardAI : StrategyAI
    {
        private const int tries = 100;
        private readonly Random random = new Random();
        private int _counter = 0;
        public StandardAI(Player player) : base(player)
        {
        }

        public override void Execute()
        {
            _counter = (_counter + 1) % 3;
            if(_counter != 0 )
            {
                return;
            }
            var board = BoardSingleton.GetInstance();
            for (int i = 0; i < tries; i++)
            {
                var dir = GetRandomDir();
                var nPosition = _player.HeadPosition().Translate(dir);
                GridImage hit = board.WillHit(nPosition);
                if (hit == GridImage.Empty || hit == GridImage.Food)
                {
                    _player.ChangeDirection(dir);
                    return;
                }
            }
        }

        private Direction GetRandomDir()
        {
            var dir = random.Next(4);
            switch(dir)
            {
                case 0:
                    return Direction.Left;
                case 1:
                    return Direction.Right;
                case 2:
                    return Direction.Up;
                default:
                    return Direction.Down;
            }
        }
    }
}
