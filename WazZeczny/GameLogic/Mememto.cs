using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WazZeczny.GameLogic
{
    public  class Mememto
    {
        public LinkedList<Position> Body { get;  }

        public Mememto(LinkedList<Position> body)
        {
            var saveState = new LinkedList<Position>();
            foreach (var b in body)
            {
                saveState.AddLast(new Position(b.Row, b.Col));
            }
            Body = saveState;
        }
    }
}
