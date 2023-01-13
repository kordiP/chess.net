using System.Text;

namespace chess.tes
{
    internal class ChessPieces
    {
        public enum ChessPiece
        {
            None, Rook, Knig, Bish, Quen, King, Pawn
        };
        public ChessPiece[,] board;
        public List<string> moves;
        public ChessPieces()
        {
            this.board = new ChessPiece[8, 8];
            moves = new List<string>();
        }
        public void GenerateChessBoard() // works :>
        {
            for (int j = 0; j < 8; j++)
            {
                board[j, 1] = ChessPiece.Pawn;
            }
            board[0, 0] = ChessPiece.Rook; board[1, 0] = ChessPiece.Knig; board[2, 0] = ChessPiece.Bish;

            board[3, 0] = ChessPiece.Quen; board[4, 0] = ChessPiece.King;
      
            board[5, 0] = ChessPiece.Bish; board[6, 0] = ChessPiece.Knig; board[7, 0] = ChessPiece.Rook;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 2; j < 6; j++)
                {
                    board[i, j] = ChessPiece.None;
                }
            }
            board[0, 7] = ChessPiece.Rook; board[1, 7] = ChessPiece.Knig; board[2, 7] = ChessPiece.Bish;

            board[3, 7] = ChessPiece.Quen; board[4, 7] = ChessPiece.King;

            board[5, 7] = ChessPiece.Bish; board[6, 7] = ChessPiece.Knig; board[7, 7] = ChessPiece.Rook;
            for (int j = 0; j < 8; j++)
            {
                board[j, 6] = ChessPiece.Pawn;
            }
        }
        public string PrintChessBoard() // works :>
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 7; i >= 0; i--)
            {
                stringBuilder.AppendLine("\n+------+------+------+------+------+------+------+------+");
                for (int j = 0; j < 8; j++)
                {
                    stringBuilder.Append("| " + board[j, i] + " ");
                }
                stringBuilder.Append("| " + (i + 1));
            }
            stringBuilder.AppendLine("\n+------+------+------+------+------+------+------+------+\n  a      b      c      d      e      f      g      h");
            return stringBuilder.ToString();        
        }
        public bool IsLegalMove(int currX, int currY, int nextX, int nextY)
        {
            ChessPiece piece = board[currX, currY];
            switch (piece)
            {
                case ChessPiece.None:
                    return false;
                case ChessPiece.Rook: // only in the same row OR the same column as the current position
                    break;
                case ChessPiece.Knig: // L position moves - hardest prolly
                    break;
                case ChessPiece.Bish: // diagonals
                    break;
                case ChessPiece.Quen: // diags + rows/columns
                    break;
                case ChessPiece.King: // 1 position in each dirrection
                    break;
                case ChessPiece.Pawn: // 1 postion on column, 2 is possible if at start
                    break;
                default:
                    return true;
            }
            return true;
        }
        public void MovePiece(int currX, int currY, int nextX, int nextY)
        {
            ChessPiece piece = board[currX, currY];
            if (IsLegalMove(currX, currY, nextX, nextY))
            {
                board[nextX, nextY] = piece;
                board[currX, currY] = ChessPiece.None;
                moves.Add($"{moves.Count + 1}.{(char)(currX + 97)}{currY + 1} -> {(char)(nextX + 97)}{nextY + 1}\t");
            }
        }
    }
}
