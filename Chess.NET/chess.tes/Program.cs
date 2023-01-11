namespace chess.tes
{
    internal class Program
    {
        static void Main()
        {
            chessPieces[,] chessBoard = new chessPieces[8, 8];
            GenerateChessBoard(chessBoard);
            PrintChessBoard(chessBoard);

        }
        enum chessPieces
        {
            None, Rook, Knig, Bish, Quen, King, Pawn
        };
        static void PrintChessBoard(chessPieces[,] chessBoard)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(chessBoard[i, j] + " | ");
                }
                Console.WriteLine("\n-----+------+------+------+------+------+------+------+");
            }

        }
        static void GenerateChessBoard(chessPieces[,] chessBoard)
        {
            for (int j = 0; j < 8; j++)
            {
                chessBoard[1, j] = chessPieces.Pawn;
            }
            chessBoard[0, 0] = chessPieces.Rook;
            chessBoard[0, 1] = chessPieces.Knig;
            chessBoard[0, 2] = chessPieces.Bish;
            chessBoard[0, 3] = chessPieces.Quen;
            chessBoard[0, 4] = chessPieces.King;
            chessBoard[0, 5] = chessPieces.Bish;
            chessBoard[0, 6] = chessPieces.Knig;
            chessBoard[0, 7] = chessPieces.Rook;
            for (int i = 2; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    chessBoard[i, j] = chessPieces.None;
                }
            }
            chessBoard[7, 0] = chessPieces.Rook;
            chessBoard[7, 1] = chessPieces.Knig;
            chessBoard[7, 2] = chessPieces.Bish;
            chessBoard[7, 3] = chessPieces.Quen;
            chessBoard[7, 4] = chessPieces.King;
            chessBoard[7, 5] = chessPieces.Bish;
            chessBoard[7, 6] = chessPieces.Knig;
            chessBoard[7, 7] = chessPieces.Rook;
            for (int j = 0; j < 8; j++)
            {
                chessBoard[6, j] = chessPieces.Pawn;
            }

        }
    }
}