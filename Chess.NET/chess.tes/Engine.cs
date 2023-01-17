using System.Net.Http.Headers;

namespace chess.tes
{
    internal class Engine
    {
        public static void Run() // type END for halt
        {
            const string endCom = "END";
            ChessLogic chess = new ChessLogic();
            chess.GenerateChessBoard();
            Console.WriteLine("Press enter to begin the game.");
            string input = Console.ReadLine();
            while (input != endCom)
            {
                Console.WriteLine(chess.PrintChessBoard());
                Console.WriteLine("Move pieces at pos: ");
                input = Console.ReadLine();
                int currX = char.Parse(input.Substring(0, 1)) - 97;
                int currY = int.Parse(input.Substring(1, 1)) - 1;
                Console.WriteLine("Move pieces to pos: ");
                input = Console.ReadLine();
                int nextX = char.Parse(input.Substring(0, 1)) - 97;
                int nextY = int.Parse(input.Substring(1, 1)) - 1;
                chess.MovePiece(currX, currY, nextX, nextY);
                //Console.Clear();
                Console.WriteLine(chess.PrintChessBoard());
                Console.WriteLine("Press enter for next move or type /END/ to close.");
                input = Console.ReadLine();
            }
            Console.Clear();
            Console.WriteLine("All moves:");
            foreach (var item in chess.moves)
            {
                Console.Write(item.Key + " " + item.Value + "|\t");
            }
        }
        //int pieceCurrPosX = char.Parse(pieceCurrPos.Substring(0, 1)) - 97;
        //int pieceCurrPosY = int.Parse(pieceCurrPos.Substring(1, 1)) - 1;
    }
}

