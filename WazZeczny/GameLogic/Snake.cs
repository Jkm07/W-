using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using WazZeczny.Interface;

namespace WazZeczny.GameLogic
{
    public class Snake : Player
    {
        private readonly Dictionary<Direction, int> dirToRotation = new()
        {
            {Direction.Up, 0},
            {Direction.Right, 90},
            {Direction.Down, 180},
            {Direction.Left, 270}
        };

        private Position HeadPosition()
        {
            return body.First.Value;
        }

        private Position TailPosition()
        {
            return body.Last.Value;
        }

        private void AddHead(Position pos)
        {
            body.AddFirst(pos);
        }

        private void RemoveTail()
        {
            body.RemoveLast();
        }
        public override void Move(GridValue[,] grid, Position newHeadPos)
        {
            if (dirChanges.Count > 0)
            {
                Dir = dirChanges.First.Value;
                dirChanges.RemoveFirst();
            }

            GridImage value = grid[newHeadPos.Row, newHeadPos.Col].Type;

            if (value == GridImage.Outside || value == GridImage.Snake)
            {
                GameOver = true;
            }
            else if (value == GridImage.Empty)
            {
                Position tail = TailPosition();
                grid[tail.Row, tail.Col] = new GridValue();
                RemoveTail();
                AddHead(newHeadPos);
            }
            else if (value == GridImage.Food)
            {
                AddHead(newHeadPos);
                Score++;
            }
            foreach (var b in body)
            {
                grid[b.Row, b.Col] = new GridValue(GridImage.Snake);
            }
            Position head = HeadPosition();
            grid[head.Row, head.Col] = new GridValue(GridImage.SnakeHead, dirToRotation[Dir]);
        }

        public void ChangeDirection(Direction dir)
        {
            if (CanChangeDirection(dir))
            {
                dirChanges.AddLast(dir);
            }
        }

        private bool CanChangeDirection(Direction newDir)
        {
            if (dirChanges.Count == 2)
            {
                return false;
            }

            Direction lastDir = GetLastDirection();
            return newDir != lastDir && newDir != lastDir.Opposite();
        }

        private Direction GetLastDirection()
        {
            if (dirChanges.Count == 0)
            {
                return Dir;
            }
            return dirChanges.Last.Value;
        }

        public Position GetNextPosition()
        {
            return HeadPosition().Translate(Dir);
        }

        public override IPrototype Copy()
        {
            var outSnake = new Snake();
            outSnake.Score = Score;
            outSnake.GameOver = GameOver;
            outSnake.Dir = (Direction)Dir.Copy();
            foreach(var b in body)
            {
                outSnake.body.AddLast((Position)b.Copy());
            }
            foreach(var d in dirChanges)
            {
                outSnake.dirChanges.AddLast((Direction)d.Copy());
            }
            return outSnake;
        }

        public override void DrawOnGrid()
        {
            base.DrawOnGrid();
            var first = body.First();
            var board = BoardSingleton.GetInstance();
            board.Grid[first.Row, first.Col] = new GridValue(GridImage.SnakeHead);
        }
    }
}
