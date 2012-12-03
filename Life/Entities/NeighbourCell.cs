
namespace Life.Entities
{
    public class NeighbourCell
    {
        /// <summary>
        /// Count neighbours of given coordinate.
        /// </summary>
        /// <param name="x">x-axis</param>
        /// <param name="y">y-axis</param>
        /// <returns>count of neighbour</returns>
        public static int CountNeighbours(Board board, int x, int y)
        {
            // 1,1      2,1     3,1
            // 1,2      2,2     3,2
            // 1,3      2,3     3,3
            int neighbours = 0;

            if (board.IsCellExist(x - 1, y - 1))
                neighbours++;

            if (board.IsCellExist(x, y - 1))
                neighbours++;

            if (board.IsCellExist(x + 1, y - 1))
                neighbours++;

            if (board.IsCellExist(x - 1, y))
                neighbours++;

            if (board.IsCellExist(x + 1, y))
                neighbours++;

            if (board.IsCellExist(x - 1, y + 1))
                neighbours++;

            if (board.IsCellExist(x, y + 1))
                neighbours++;

            if (board.IsCellExist(x + 1, y + 1))
                neighbours++;

            return neighbours;
        }
    }
}
