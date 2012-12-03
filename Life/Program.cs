using System;
using System.Threading.Tasks;
using Life.Entities;

namespace Life
{
    class Program
    {
        static void Main(string[] args)
        {
            //configure the game
            Game lifeGame = new Game(11, 25);
            lifeGame.Delay = 500;   //ms
            lifeGame.MaxGeneration = 100;

            //Add default cells on the board
            lifeGame.InitDefaultGameBoard();

            //Play
            Task.Factory.StartNew(() => lifeGame.Play());

            Console.Read();
        }
    }
}
