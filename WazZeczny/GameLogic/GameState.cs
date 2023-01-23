using System.Collections.Generic;
using WazZeczny.GameLogic;
using WazZeczny.Factories;

namespace WazZeczny
{
    public class GameState
    {

        public BoardSingleton Board { get; }

        public FacotryContainer Factory { get; }

        public readonly List<Snake> snakes;

        public readonly Food food = new Food();

        private delegate void Notify();

        private event Notify _saveSnakes;

        private event Notify _RunAI;

        public GameState(int rows, int cols, List<Snake> snakes, FacotryContainer factory)
        {
            this.Factory = factory;
            Board = BoardSingleton.GetNewInstance(rows, cols);
            AddSnakes(snakes);
            this.snakes = snakes;
            food.Add(new Position(Board.Rows / 2, 2));
            food.Move(null, null);
            snakes.ForEach(snake => { _saveSnakes += snake.Save; _RunAI += snake.AI.Execute; });
        }

        private void AddSnakes(List<Snake> snakes)
        {
            int qrtP = Board.Rows / 4;
            int p = 1;
            foreach(var snake in snakes)
            {
                snake.Dir = Direction.Right;
                snake.Add(new Position(qrtP * p, 1));
                p++;
            }
        }

        public void SaveAllSnake()
        {
            _saveSnakes?.Invoke();
        }

        public void RunAllAI()
        {
            _RunAI?.Invoke();
        }

        private void Move(Snake snake)
        {
            if(snake.GameOver)
            {
                return;
            }
            Position newHeadPos = snake.GetNextPosition();
            GridImage hit = Board.WillHit(newHeadPos);
            if (hit == GridImage.Outside || hit == GridImage.Snake)
            {
                snake.GameOver = true;
                return;
            }
            snake.Move(Board.Grid, newHeadPos);
            if (hit == GridImage.Food)
            {
                food.Move(null, null);
            }
        }

        public void Move()
        {
            snakes.ForEach(snake => { Move(snake); });
        }

        public bool GameOver()
        {
            bool gameOver = true;
            snakes.ForEach(snake => { gameOver &= snake.GameOver; });
            return gameOver;
        }
    }
}
