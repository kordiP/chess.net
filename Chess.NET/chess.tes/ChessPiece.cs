using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess.tes
{
    internal class ChessPiece
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Value { get; set; }

        public ChessPiece(string name, string color, int value)
        {
            Name = name;
            Color = color;
            Value = value;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
