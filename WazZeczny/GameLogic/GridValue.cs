using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WazZeczny.GameLogic
{
    public class GridValue
    {
        public GridImage Type { get;}
        public int Rotation { get; }

        public GridValue(GridImage image = GridImage.Empty, int rotation = 0)
        {
            Type= image;
            Rotation = rotation;
        }
    }
}
