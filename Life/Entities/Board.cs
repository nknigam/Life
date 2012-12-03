using System;
using System.Collections.Generic;

namespace Life.Entities
{
    public class Board
    {
        /// <summary>
        /// cells on the game board
        /// </summary>
        public List<CellRow> Cells { get; set; }

        /// <summary>
        /// Row count on the game board
        /// </summary>
        private int _rows { get; set; }

        /// <summary>
        /// Column count on the game board
        /// </summary>
        private int _columns { get; set; }


        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        public Board(int rows, int columns)
        {
            _rows = rows;
            _columns = columns;
            Init(rows, columns);
        }


        public bool this[int x, int y]
        {
            get { return this.Cells[x][y].IsActive; }
            set { this.Cells[x][y].IsActive = value; }
        }

        public bool IsCellExist(int x, int y)
        {
            //boundary conditions
            if (x < 0 || y < 0 || x >= _rows || y >= _columns) 
                return false;

            return Cells[x][y].IsActive;
        }

        /// <summary>
        /// Init Board with all InActive cells
        /// </summary>
        /// <param name="rows">number of rows on the board</param>
        /// <param name="columns">Number of columns on the board</param>
        private void Init(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0) 
                throw new ArgumentOutOfRangeException("out of range");

            Cells = new List<CellRow>();
            for (int i = 0; i < rows; i++)
            {
                CellRow row = new CellRow();
                for (int j = 0; j < columns; j++)
                {
                    Cell cell = new Cell(false);    //InActive cells
                    row.Add(cell);
                }
                Cells.Add(row);
            }
        }

        /// <summary>
        /// Activate the cell on the game board
        /// </summary>
        /// <param name="x">X-axiz coordinate</param>
        /// <param name="y">Y-axis coordinate</param>
        public void GiveLife(int x, int y)
        {
            Cells[x][y].IsActive = true;
        }

    }
}
