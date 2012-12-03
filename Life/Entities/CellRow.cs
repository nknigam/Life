using System;
using System.Collections.Generic;

namespace Life.Entities
{
    public class CellRow
    {
        //list of cells
        public List<Cell> Cells { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        public CellRow()
        {
            Cells = new List<Cell>();
        }


        public Cell this[int y]
        {
            get
            {
                if (y < Cells.Count)
                    return Cells[y];
                
                throw new ArgumentOutOfRangeException("out of range");
            }
            set
            {
                if (y < Cells.Count)
                    Cells[y] = value;
                else
                    throw new ArgumentOutOfRangeException("out of range");   
            }
        }

        /// <summary>
        /// Add a cell into the row
        /// </summary>
        /// <param name="cell"></param>
        public void Add(Cell cell)
        {
            Cells.Add(cell);
        }

    }
}
