using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace WazZeczny.GameLogic
{
    public class BoardSingleton : IEnumerable<GridValue>
    {
        public int Rows { get; }
        public int Cols { get; }
        public GridValue[,] Grid { get; }

        private static bool isInit = false;

        private static BoardSingleton _instance;

        public static BoardSingleton GetInstance(int rows = 30, int cols = 30)
        {
            if (!isInit)
            {
                isInit = true;
                _instance = new BoardSingleton(rows, cols);
            }
            return _instance;
        }

        public static BoardSingleton GetNewInstance(int rows, int cols)
        {
            isInit = true;
            _instance = new BoardSingleton(rows, cols);
            return _instance;
        }

        private BoardSingleton(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            Grid = new GridValue[Rows, Cols];
            for (int r = 0; r < Rows; r++)
                for (int c = 0; c < Cols; c++)
                    Grid[r, c] = new GridValue();
        }

        public IEnumerator<GridValue> GetEnumerator()
        {
            for (int r = 0; r < Rows; r++)
                for (int c = 0; c < Cols; c++)
                    yield return Grid[r, c];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int r = 0; r < Rows; r++)
                for (int c = 0; c < Cols; c++)
                    yield return Grid[r, c];
        }

        private bool OutsideGrid(Position pos)
        {
            return pos.Row < 0 || pos.Col < 0 || pos.Row >= Rows || pos.Col >= Cols;
        }

        public GridImage WillHit(Position newHeadPos)
        {
            if (OutsideGrid(newHeadPos))
            {
                return GridImage.Outside;
            }
            return Grid[newHeadPos.Row, newHeadPos.Col].Type;
        }
    }
}
