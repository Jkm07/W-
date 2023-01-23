using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using WazZeczny.Commands;
using WazZeczny.GameLogic;
using WazZeczny.StrategiesAI;

namespace WazZeczny.Interface
{
    public abstract class Player : IPrototype
    {
        public Direction Dir { get; set; }
        public int Score { get; protected set; }
        public bool GameOver { get; set; }
        public StrategyAI AI { get; set; }

        protected LinkedList<Position> body = new LinkedList<Position>();
        protected readonly LinkedList<Direction> dirChanges = new LinkedList<Direction>();
        private readonly CareTaker careTaker = new CareTaker();


        protected Player() 
        {
            AI = new DoNothingAI(this);
        }

        public virtual void Add(Position start)
        {
            int r = start.Row;

            for (int c = start.Col; c <= 3; c++)
            {
                body.AddLast(new Position(r, c));
            }
        }

        public virtual void Move(GridValue[,] grid, Position newHeadPos)
        {

        }

        public virtual void ClearFromGrid()
        {
            var board = BoardSingleton.GetInstance();
            foreach(var b in body)
            {
                board.Grid[b.Row, b.Col] = new GridValue(GridImage.Empty);
            }
        }

        public virtual void DrawOnGrid()
        {
            var board = BoardSingleton.GetInstance();
            foreach (var b in body)
            {
                board.Grid[b.Row, b.Col] = new GridValue(GridImage.Snake);
            }
        }

        public void Save()
        {
            var nMemento = new Mememto(body);
            careTaker.AddMemento(nMemento);
        }

        public void Restore()
        {
            var oldState = careTaker.Undo();
            ClearFromGrid();
            body = oldState.Body;
            DrawOnGrid();
        }

        public void Restore(int times)
        {
            while(times> 0)
            {
                Restore();
                times--;
            }
        }

        public Position HeadPosition()
        {
            return body.First.Value;
        }

        protected Position TailPosition()
        {
            return body.Last.Value;
        }

        public Position GetNextPosition()
        {
            return HeadPosition().Translate(Dir);
        }

        public virtual void ChangeDirection(Direction dir) { }

        public abstract IPrototype Copy();
    }
}
