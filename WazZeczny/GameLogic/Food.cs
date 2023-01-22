using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using WazZeczny.Interface;

namespace WazZeczny.GameLogic
{
    public class Food : Player
    {
        private readonly Random random = new Random();
        public override void Add(Position start)
        {
            body.AddFirst(start);
        }

        public override void Move(GridValue[,] grid, Position newHeadPos)
        {
            List<Position> empty = new List<Position>(EmptyPositions());

            if (empty.Count == 0)
            {
                return;
            }
            Position pos = empty[random.Next(empty.Count)];

            var board = BoardSingleton.GetInstance();

            board.Grid[pos.Row, pos.Col] = new GridValue(GridImage.Food);
        }

        private IEnumerable<Position> EmptyPositions()
        {
            var board = BoardSingleton.GetInstance();
            for (int r = 0; r < board.Rows; r++)
            {
                for (int c = 0; c < board.Cols; c++)
                {
                    if (board.Grid[r, c].Type == GridImage.Empty)
                    {
                        yield return new Position(r, c);
                    }
                }
            }
        }

        public override IPrototype Copy()
        {
            var outSnake = new Food();
            outSnake.Score = Score;
            outSnake.GameOver = GameOver;
            outSnake.Dir = (Direction)Dir.Copy();
            foreach (var b in body)
            {
                outSnake.body.AddLast((Position)b.Copy());
            }
            foreach (var d in dirChanges)
            {
                outSnake.dirChanges.AddLast((Direction)d.Copy());
            }
            return outSnake;
        }
    }
}
