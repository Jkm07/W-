using WazZeczny.GameLogic;

namespace WazZeczny
{
    public class GameState
    {

        public BoardSingleton Board { get; }

        public readonly Snake snake = new Snake();

        public readonly Food food = new Food();

        public GameState(int rows, int cols)
        {
            Board = BoardSingleton.GetNewInstance(rows, cols);
            snake.Dir = Direction.Right;

            snake.Add(new Position(Board.Rows / 2, 1));
            food.Add(new Position(Board.Rows / 2, 2));
            food.Move(null, null);
        }

        public void Move()
        {
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
