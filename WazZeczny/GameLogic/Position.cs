using System;
using System.Collections.Generic;
using WazZeczny.Interface;

namespace WazZeczny
{
    public class Position : IPrototype
    {
        public int Row { get; }
        public int Col { get; }

        public Position(int row, int col) { Row = row; Col = col; }

        public Position Translate(Direction dir)
        {
            return new Position(Row + dir.RowOffset, Col + dir.ColOffset);
        }

        public override bool Equals(object obj)
        {
            return obj is Position position &&
                   Row == position.Row &&
                   Col == position.Col;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Row, Col);
        }

        public IPrototype Copy()
        {
            return new Position(Row, Col);
        }

        public static bool operator ==(Position left, Position right)
        {
            return EqualityComparer<Position>.Default.Equals(left, right);
        }

        public static bool operator !=(Position left, Position right)
        {
            return !(left == right);
        }
    }
}
