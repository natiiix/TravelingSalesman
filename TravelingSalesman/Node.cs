using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelingSalesman
{
    class Node
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Node(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
