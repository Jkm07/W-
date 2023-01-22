using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WazZeczny.GameLogic
{
    public class CareTaker
    {
        public LinkedList<Mememto> Mementos { get; }
        public CareTaker()
        {
            Mementos = new LinkedList<Mememto>();
        }
        public void AddMemento(Mememto memento)
        {
            Mementos.AddFirst(memento);
        }
        public Mememto Undo()
        {
            var oldState = Mementos.First();
            Mementos.RemoveFirst();
            return oldState;
        }
    }
}
