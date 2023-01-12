using System.Net.Http.Headers;

namespace chess.tes
{
    internal class Engine
    {
        public static void Run()
        {
            ChessPieces[,] board = new ChessPieces[8, 8];
            GenerateChessBoard(board);
            PrintChessBoard(board);
            Console.WriteLine("Which piece do you want to move? /type a1, b1, d3 etc/ :");
            string pieceCurrPos = Console.ReadLine();
            int pieceCurrPosX = char.Parse(pieceCurrPos.Substring(0,1)) - 97;
            int pieceCurrPosY = int.Parse(pieceCurrPos.Substring(1,1)) - 1;
            Console.WriteLine(pieceCurrPosX + "-" + pieceCurrPosY);
            ChessPieces selectedPiece = FindPiece(board, pieceCurrPosX, pieceCurrPosY);
            Console.WriteLine("Where do you want it to move? /type a1, b1, d3 etc/ :");
            string pieceNextPos = Console.ReadLine();
            int pieceNextPosX = char.Parse(pieceNextPos.Substring(0, 1)) - 97; // -97 because character 'a' sits at position 97
            int pieceNextPosY = int.Parse(pieceNextPos.Substring(1, 1)) - 1; // -1 because a1 = 0-0
            MovePiece(board, selectedPiece, pieceNextPosX, pieceNextPosY);
            PrintChessBoard(board);
        }
        enum ChessPieces
        {
            None, Rook, Knig, Bish, Quen, King, Pawn
        };
        static void PrintChessBoard(ChessPieces[,] chessBoard)
        {
            for (int i = 7; i >= 0; i--)
            {
                Console.WriteLine("\n+------+------+------+------+------+------+------+------+");
                for (int j = 0; j < 8; j++)
                {
                    Console.Write("| " + chessBoard[j, i] + " ");
                }
                Console.Write("| " + (i + 1));
            }
            Console.WriteLine("\n+------+------+------+------+------+------+------+------+\n  a      b      c      d      e      f      g      h");
        }
        static void GenerateChessBoard(ChessPieces[,] chessBoard)
        {
            for (int j = 0; j < 8; j++)
            {
                chessBoard[j, 1] = ChessPieces.Pawn;
            }
            chessBoard[0, 0] = ChessPieces.Rook;
            chessBoard[1, 0] = ChessPieces.Knig;
            chessBoard[2, 0] = ChessPieces.Bish;
            chessBoard[3, 0] = ChessPieces.Quen;
            chessBoard[4, 0] = ChessPieces.King;
            chessBoard[5, 0] = ChessPieces.Bish;
            chessBoard[6, 0] = ChessPieces.Knig;
            chessBoard[7, 0] = ChessPieces.Rook;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 2; j < 6; j++)
                {
                    chessBoard[i, j] = ChessPieces.None;
                }
            }
            chessBoard[0, 7] = ChessPieces.Rook;
            chessBoard[1, 7] = ChessPieces.Knig;
            chessBoard[2, 7] = ChessPieces.Bish;
            chessBoard[3, 7] = ChessPieces.Quen;
            chessBoard[4, 7] = ChessPieces.King;
            chessBoard[5, 7] = ChessPieces.Bish;
            chessBoard[6, 7] = ChessPieces.Knig;
            chessBoard[7, 7] = ChessPieces.Rook;
            for (int j = 0; j < 8; j++)
            {
                chessBoard[j, 6] = ChessPieces.Pawn;
            }

        }
        static void MovePiece(ChessPieces[,] chessBoard, ChessPieces piece, int pieceNextPosX, int pieceNextPosY)
        {
            if (IsLegalMove(chessBoard, piece, pieceNextPosX, pieceNextPosY))
            {
                chessBoard[pieceNextPosX, pieceNextPosY] = piece;
            }
        }
        static ChessPieces FindPiece(ChessPieces[,] chessBoard, int X, int Y)
        {
            return chessBoard[X, Y];
        }
        static bool IsLegalMove(ChessPieces[,] chessBoard, ChessPieces piece, int nextX, int nextY)
        {
            switch (piece)
            {
                case ChessPieces.None:
                    return false;
                case ChessPieces.Rook: // only in the same row OR the same column as the current position
                    break;
                case ChessPieces.Knig: // L position moves - hardest prolly
                    break;
                case ChessPieces.Bish: // diagonals
                    break;
                case ChessPieces.Quen: // diags + rows/columns
                    break;
                case ChessPieces.King: // 1 position in each dirrection
                    break;
                case ChessPieces.Pawn: // 1 postion on column, 2 is possible if at start
                    break;
                default:
                    return false;           }
            return false;
        }
    }
}

