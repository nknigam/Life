using System;
using System.Threading;
using System.Threading.Tasks;

namespace Life.Entities
{
    public class Game
    {

        #region Private Members variables

        private const int MAX_GENERATION_LIMIT = 10000;
        private Board _input;

        private int _generation = 1;
        private int _rowCount;
        private int _columnCount;
        private int _interval = 250;

        #endregion Private Members


        #region Public Properties

        /// <summary>
        /// Max generations to be played
        /// </summary>
        public int MaxGeneration { get; set; }

        /// <summary>
        /// MilliSecond Delay for Next generation
        /// </summary>
        public int Delay
        {
            set
            {
                _interval = value;
            }
        }

        /// <summary>
        /// Board having the cells
        /// </summary>
        public Board GameBoard
        {
            get
            {
                return _input;
            }
        }

        #endregion Public Properties

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <param name="timeInterval"></param>
        public Game(int rows, int columns)
        {
            _rowCount = rows;
            _columnCount = columns;

            _input = new Board(_rowCount, _columnCount);
        }


        /// <summary>
        /// Display the Board on console
        /// </summary>
        internal void DisplayBoard()
        {
            Console.SetCursorPosition(1, 0);
            foreach (CellRow row in GameBoard.Cells)
            {
                foreach (Cell cell in row.Cells)
                {
                    Console.Write(cell.ToString());
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("Generation: {0}", _generation);
        }

        /// <summary>
        /// Start the Life game with given sleep time.
        /// </summary>
        public void Play()
        {
            while (_generation < MaxGeneration)
            {
                Thread.Sleep(_interval);
                ProcessNextGeneration();
                DisplayBoard();
            }
        }

        /// <summary>
        /// process the next generation on game board
        /// </summary>
        public void ProcessNextGeneration()
        {
            // begin the next generation's processing asynchronously
            Task<Board> ProcessNextGenerationTask = Task.Factory.StartNew(() => NextState());

            ProcessNextGenerationTask.ContinueWith((task) =>
            {
                if (task.IsCompleted)
                {
                    UpdateBoard(task.Result);
                }
            }).Wait();
        }

        /// <summary>
        /// compute the next state of board on next generation
        /// </summary>
        /// <returns>Board</returns>
        public Board NextState()
        {
            Board output = new Board(_rowCount, _columnCount);

            Parallel.For(0, _rowCount - 1, x =>
            {
                Parallel.For(0, _columnCount - 1, y =>
                {
                    int numberOfNeighbors = NeighbourCell.CountNeighbours(_input, x, y);

                    bool shouldLive = false;
                    bool isAlive = _input[x, y];

                    if (isAlive && (numberOfNeighbors == 2 || numberOfNeighbors == 3))
                    {   //living cell with exactly 2 or 3 neighbour will be still alive
                        shouldLive = true;
                    }
                    else if (!isAlive && numberOfNeighbors == 3)
                    {   // dead cell with 3 neighbour will get life
                        shouldLive = true;
                    }

                    output[x, y] = shouldLive;

                });
            });

            return output;
        }

        /// <summary>
        /// Update the game board with next generation output
        /// </summary>
        /// <param name="nextGenBoard">output of next generation</param>
        /// <returns>async task</returns>
        public Task UpdateBoard(Board nextGenBoard)
        {
            return Task.Factory.StartNew(() =>
            {
                // when a generation has completed
                // now assign next generation output to the game board.
                _input = nextGenBoard;
                _generation++;
            });
        }

        /// <summary>
        /// Add Default Cells on Game start
        /// </summary>
        internal void InitDefaultGameBoard()
        {
            // toad vertical 
            _input.GiveLife(5, 10);
            _input.GiveLife(5, 11);
            _input.GiveLife(5, 12);
            _input.GiveLife(6, 11);
            _input.GiveLife(6, 12);
            _input.GiveLife(6, 13);

            // tub
            _input.GiveLife(3, 14);
            _input.GiveLife(3, 16);
            _input.GiveLife(2, 15);
            _input.GiveLife(4, 15);

            // glider
            _input.GiveLife(7, 2);
            _input.GiveLife(7, 3);
            _input.GiveLife(7, 4);
            _input.GiveLife(8, 4);
            _input.GiveLife(9, 3);

            // blinker 
            _input.GiveLife(2, 5);
            _input.GiveLife(3, 5);
            _input.GiveLife(4, 5);

            //// blinker 
            _input.GiveLife(1, 7);
            _input.GiveLife(1, 8);
            _input.GiveLife(1, 9);


            // some random cells
            Random random = new Random();
            int randomX, randomY;

            // 50 random cells
            for (int i = 0; i < 50; i++)
            {
                randomX = random.Next(3, _rowCount - 1);
                randomY = random.Next(3, _columnCount - 1);

                _input.GiveLife(randomX, randomY);
            }

            DisplayBoard();
        }
    }

}
