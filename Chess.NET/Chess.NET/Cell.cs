using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.NET
{
    class Cell
    {
        public bool IsOccupied { get; set; }
        public Cell(bool isOccupied)
        {
            IsOccupied = isOccupied;
        }
    }
}
