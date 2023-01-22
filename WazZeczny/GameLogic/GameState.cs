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

        public GameState(int rows, int cols, List<Snake> snakes, FacotryContainer factory)
        {
            this.Factory = factory;
            Board = BoardSingleton.GetNewInstance(rows, cols);
            AddSnakes(snakes);
            this.snakes = snakes;
            food.Add(new Position(Board.Rows / 2, 2));
            food.Move(null, null);
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
            snakes.ForEach(snake => { snake.Save(); });
        }

        private void Move(Snake snake)
        {
            if(snake.GameOver)
            {
                return;
            }
            Position newHeadPos = snake.GetNextPosition();
            GridImage hit = WillHit(newHeadPos);
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

        private bool OutsideGrid(Position pos)
        {
            return pos.Row < 0 || pos.Col < 0 || pos.Row >= Board.Rows || pos.Col >= Board.Cols; 
        }

        private GridImage WillHit(Position newHeadPos)
        {
            if(OutsideGrid(newHeadPos))
            {
                return GridImage.Outside;
            }
            return Board.Grid[newHeadPos.Row, newHeadPos.Col].Type;
        }
    }
}
