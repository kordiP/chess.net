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
        public Dictionary<string, ChessPiece> moves;
        public ChessPieces()
        {
            this.board = new ChessPiece[8, 8];
            moves = new Dictionary<string, ChessPiece>();
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
            ChessPiece currPiece = board[currX, currY];
            switch (currPiece)
            {
                case ChessPiece.None:
                    return false;
                case ChessPiece.Rook:
                    if (nextX != currX && nextY != currY)
                        return false; // check if its on the same row/column
                    if (nextX > currX)
                    {
                        for (int i = currX; i < nextX; i++)
                            if (!board[currY, i].Equals(ChessPiece.None))
                                return false; // check if there is piece between currPos and nextPos
                    }
                    else
                    {
                        for (int i = currX; i > nextX; i--)
                            if (!board[currY, i].Equals(ChessPiece.None))
                                return false; // check if there is piece between currPos and nextPos
                    }
                    if (nextY > currY)
                    {
                        for (int i = currY; i <= nextY; i++)
                            if (!board[i, currX].Equals(ChessPiece.None))
                                return false; // check if there is piece between currPos and nextPos
                    }
                    else
                    {
                        for (int i = currY; i >= nextY; i--)
                            if (!board[i, currX].Equals(ChessPiece.None))
                                return false; // check if there is piece between currPos and nextPos
                    }
                    return true;
                case ChessPiece.Knig:
                    if (!board[nextX, nextY].Equals(ChessPiece.None))
                        return false;
                    else if (Math.Abs(nextX - currX) > 2 || Math.Abs(nextX - currX) < 1)
                        return false;
                    else if (Math.Abs(nextY - currY) > 2 || Math.Abs(nextY - currY) < 1)
                        return false;
                    else if(Math.Abs(nextX - currX) + Math.Abs(nextY - currY) !=3)
                        return false;
                    return true;
                case ChessPiece.Bish:
                    if (!board[nextX, nextY].Equals(ChessPiece.None))
                        return false;
                    else if (Math.Abs(nextX - currX) != Math.Abs(nextY - currY))
                        return false; // check if its on the diagonal
                    if (nextX > currX)
                    {
                        for (int i = currX + 1; i < nextX; i++) // x +
                        {
                            for (int j = currY + 1; j < nextY; j++) // y + 
                            {
                                if (Math.Abs(nextX - i) == Math.Abs(nextY - j))
                                    if (!board[i, j].Equals(ChessPiece.None)) return false;
                            }
                            for (int j = currY - 1; j > nextY; j--) // y - 
                            {
                                if (Math.Abs(nextX - i) == Math.Abs(nextY - j))
                                    if (!board[i, j].Equals(ChessPiece.None)) return false;
                            }
                        }
                    }
                    else
                    {
                        for (int i = currX - 1; i > nextX; i--) // x -
                        {
                            for (int j = currY + 1; j < nextY; j++) // y +
                            {
                                if (Math.Abs(nextX - i) == Math.Abs(nextY - j))
                                    if (!board[i, j].Equals(ChessPiece.None)) return false;
                            }
                            for (int j = currY - 1; j > nextY; j--) // y -
                            {
                                if (Math.Abs(nextX - i) == Math.Abs(nextY - j))
                                    if (!board[i, j].Equals(ChessPiece.None)) return false;
                            }
                        }
                    }
                    break;
                case ChessPiece.Quen: // diags + rows/columns
                    if (!board[nextX, nextY].Equals(ChessPiece.None))
                        return false;

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
        private bool IsCheck(int currX, int currY, int nextX, int nextY)
        {
            // check if next position is occupied
            return true;
        }
        public void MovePiece(int currX, int currY, int nextX, int nextY)
        {
            ChessPiece piece = board[currX, currY];
            if (IsLegalMove(currX, currY, nextX, nextY))
            {
                board[nextX, nextY] = piece;
                board[currX, currY] = ChessPiece.None;
                moves.Add($"{moves.Count + 1}.{(char)(currX + 97)}{currY + 1} -> {(char)(nextX + 97)}{nextY + 1}", piece);
            }
        }

    }
}
