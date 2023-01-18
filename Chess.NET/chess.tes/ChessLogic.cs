using System.Text;

namespace chess.tes
{
    internal class ChessLogic
    {
        ChessPiece none;
        ChessPiece pawn_w;
        ChessPiece pawn_b;
        ChessPiece knight_w;
        ChessPiece knight_b;
        ChessPiece bishop_w;
        ChessPiece bishop_b;
        ChessPiece rook_w;
        ChessPiece rook_b;
        ChessPiece queen_w;
        ChessPiece queen_b;
        ChessPiece king_w;
        ChessPiece king_b;
        public ChessPiece[,] board;
        public Dictionary<string, ChessPiece> moves;
        public ChessLogic()
        {
            this.board = new ChessPiece[8, 8];
            moves = new Dictionary<string, ChessPiece>();
            none = new ChessPiece(" None ", "None", 0);
            pawn_w = new ChessPiece(" Pawn ", "White", 1);
            pawn_b = new ChessPiece(" Pawn ", "Black", 1);
            knight_w = new ChessPiece("Knight", "White", 3);
            knight_b = new ChessPiece("Knight", "Black", 3);
            bishop_w = new ChessPiece("Bishop", "White", 3);
            bishop_b = new ChessPiece("Bishop", "Black", 3);
            rook_w = new ChessPiece(" Rook ", "White", 5);
            rook_b = new ChessPiece(" Rook ", "Black", 5);
            queen_w = new ChessPiece("Queen ", "White", 9);
            queen_b = new ChessPiece("Queen ", "Black", 9);
            king_w = new ChessPiece(" King ", "White", 10);
            king_b = new ChessPiece(" King ", "Black", 10);
        }
        public void GenerateChessBoard() // works :>
        {
            for (int j = 0; j < 8; j++)
            {
                board[j, 1] = pawn_w;
            }
            board[0, 0] = rook_w; board[1, 0] = knight_w; board[2, 0] = bishop_w;

            board[3, 0] = queen_w; board[4, 0] = king_w;

            board[5, 0] = bishop_w; board[6, 0] = knight_w; board[7, 0] = rook_w;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 2; j < 6; j++)
                {
                    board[i, j] = none;
                }
            }
            board[0, 7] = rook_b; board[1, 7] = knight_b; board[2, 7] = bishop_b;

            board[3, 7] = queen_b; board[4, 7] = king_b;

            board[5, 7] = bishop_b; board[6, 7] = knight_b; board[7, 7] = rook_b;
            for (int j = 0; j < 8; j++)
            {
                board[j, 6] = pawn_b;
            }
        }
        public string PrintChessBoard() // works :>
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 7; i >= 0; i--)
            {
                stringBuilder.AppendLine("\n+--------+--------+--------+--------+--------+--------+--------+--------+");
                for (int j = 0; j < 8; j++)
                {
                    stringBuilder.Append("| " + board[j, i] + " ");
                }
                stringBuilder.Append("| " + (i + 1));
            }
            stringBuilder.AppendLine("\n+--------+--------+--------+--------+--------+--------+--------+--------+\n    a        b        c        d        e        f        g        h");
            return stringBuilder.ToString();
        }
        public bool IsLegalMove(int currX, int currY, int nextX, int nextY) // add color check to all checks for <if (none)...>
        {
            ChessPiece currPiece = board[currX, currY];
            switch (currPiece.Name)
            {
                case "None":
                    return false;
                case " Rook ":
                    if (nextX != currX && nextY != currY)
                        return false; // check if its on the same row/column
                    else if (nextX - currX == 0 && nextY - currY == 0)
                        return false; // check if it even moves, or else it "eats" itself
                    else if (!board[nextX, nextY].Equals(none) && board[nextX, nextY].Color == currPiece.Color)
                        return false;
                    // from here down
                    else if (nextX > currX)
                    {
                        for (int i = currX + 1; i < nextX; i++)
                            if (!board[i, currY].Equals(none))
                                return false; 
                    }
                    else if (nextX < currX)
                    {
                        for (int i = currX - 1; i > nextX; i--)
                            if (!board[i, currY].Equals(none))
                                return false;
                    }
                    else if (nextY > currY)
                    {
                        for (int i = currY + 1; i < nextY; i++)
                            if (!board[currX, i].Equals(none))
                                return false;
                    }
                    else if (nextY < currY)
                    {
                        for (int i = currY - 1; i > nextY; i--)
                            if (!board[currX, i].Equals(none))
                                return false;
                    }
                    break;
                case "Knight":
                    if (!board[nextX, nextY].Equals(none) && board[nextX, nextY].Color == currPiece.Color)
                        return false;
                    else if (Math.Abs(nextX - currX) > 2 || Math.Abs(nextX - currX) < 1)
                        return false;
                    else if (Math.Abs(nextY - currY) > 2 || Math.Abs(nextY - currY) < 1)
                        return false;
                    else if(Math.Abs(nextX - currX) + Math.Abs(nextY - currY) !=3)
                        return false;
                    break;
                case "Bishop":
                    if (!board[nextX, nextY].Equals(none) && board[nextX, nextY].Color == currPiece.Color)
                        return false;
                    else if (Math.Abs(nextX - currX) != Math.Abs(nextY - currY))
                        return false; // check if its on the diagonal
                    if (nextX > currX)
                    {
                        for (int i = currX + 1; i < nextX; i++) 
                        {
                            for (int j = currY + 1; j < nextY; j++) 
                            {
                                if (Math.Abs(nextX - i) == Math.Abs(nextY - j))
                                    if (!board[i, j].Equals(none)) return false;
                            }
                            for (int j = currY - 1; j > nextY; j--)  
                            {
                                if (Math.Abs(nextX - i) == Math.Abs(nextY - j))
                                    if (!board[i, j].Equals(none)) return false;
                            }
                        }
                    }
                    else
                    {
                        for (int i = currX - 1; i > nextX; i--) 
                        {
                            for (int j = currY + 1; j < nextY; j++) 
                            {
                                if (Math.Abs(nextX - i) == Math.Abs(nextY - j))
                                    if (!board[i, j].Equals(none)) return false;
                            }
                            for (int j = currY - 1; j > nextY; j--) 
                            {
                                if (Math.Abs(nextX - i) == Math.Abs(nextY - j))
                                    if (!board[i, j].Equals(none)) return false;
                            }
                        }
                    }
                    break;
                case "Queen ": // diags + rows/columns
                    if (!board[nextX, nextY].Equals(none) && board[nextX, nextY].Color == currPiece.Color)
                        return false;
                    else if (Math.Abs(nextX - currX) != Math.Abs(nextY - currY) && nextX != currX && nextY != currY)
                        return false;
                    if (nextX > currX && nextY == currY)
                    {
                        for (int i = currX + 1; i < nextX; i++)
                            if (!board[i, currY].Equals(none))
                                return false;
                    }
                    else if (nextX < currX && nextY == currY)
                    {
                        for (int i = currX - 1; i > nextX; i--)
                            if (!board[i, currY].Equals(none))
                                return false;
                    }
                    else if (nextY > currY && nextX == currX)
                    {
                        for (int i = currY + 1; i <= nextY; i++)
                            if (!board[currX, i].Equals(none))
                                return false;
                    }
                    else if (nextY < currY && nextX == currX)
                    {
                        for (int i = currY - 1; i >= nextY; i--)
                            if (!board[currX, i].Equals(none))
                                return false;
                    }
                    else if (nextX > currX && nextY != currY)
                    {
                        for (int i = currX + 1; i < nextX; i++) // x +
                        {
                            for (int j = currY + 1; j < nextY; j++) // y + 
                            {
                                if (Math.Abs(nextX - i) == Math.Abs(nextY - j))
                                    if (!board[i, j].Equals(none)) return false;
                            }
                            for (int j = currY - 1; j > nextY; j--) // y - 
                            {
                                if (Math.Abs(nextX - i) == Math.Abs(nextY - j))
                                    if (!board[i, j].Equals(none)) return false;
                            }
                        }
                    }
                    else if (nextX < currX && nextY != currY)
                    {
                        for (int i = currX - 1; i > nextX; i--) // x -
                        {
                            for (int j = currY + 1; j < nextY; j++) // y +
                            {
                                if (Math.Abs(nextX - i) == Math.Abs(nextY - j))
                                    if (!board[i, j].Equals(none)) return false;
                            }
                            for (int j = currY - 1; j > nextY; j--) // y -
                            {
                                if (Math.Abs(nextX - i) == Math.Abs(nextY - j))
                                    if (!board[i, j].Equals(none)) return false;
                            }
                        }
                    }
                    break;
                case " King ": // 1 position in each dirrection
                    if (!board[nextX, nextY].Equals(none) && board[nextX, nextY].Color == currPiece.Color)
                        return false;
                    else if (Math.Abs(nextX - currX) > 1 || Math.Abs(nextY - currY) > 1)
                        return false;
                    break;
                case " Pawn ": // + en-passant?
                    if (currPiece.Color == "White") // White case
                    {
                        if (nextX == currX) // check for forward movement (1 space), (2 spaces)
                        {
                            if (nextY - currY > 2 || nextY - currY < 0) // (1 space)
                                return false;
                            else if (nextY - currY == 2 && currY != 1 || nextY - currY == 2 && !board[nextX, currY+1].Equals(none)) // (2 spaces) //
                                return false;
                            else if (!board[nextX, nextY].Equals(none)) // check if next space is free, because capturing is possible only in diagonals
                                return false;
                        }
                        else if (nextX != currX && Math.Abs(nextX - currX) == nextY - currY) // check for capture
                        {
                            if (!board[nextX, nextY].Equals(none) && board[nextX, nextY].Color == currPiece.Color || board[nextX, nextY].Equals(none))
                                return false;
                            else if (nextY - currY > 1)
                                return false;
                        }
                    }
                    else // Black case
                    {
                        if (nextX == currX) // check for forward movement (1 space), (2 spaces)
                        {
                            if (currY - nextY > 2 || currY - nextY < 0) // (1 space)
                                return false;
                            else if (currY - nextY == 2 && currY != 6 || currY - nextY == 2 && !board[nextX, currY - 1].Equals(none)) // (2 spaces) //
                                return false;
                            else if (!board[nextX, nextY].Equals(none)) // check if next space is free, because capturing is possible only in diagonals
                                return false;
                        }
                        else if (nextX != currX && Math.Abs(nextX - currX) == currY - nextY) // check for capture
                        {
                            if (!board[nextX, nextY].Equals(none) && board[nextX, nextY].Color == currPiece.Color || board[nextX, nextY].Equals(none))
                                return false;
                            else if (currY - nextY > 1)
                                return false;
                        }

                    }
                    return true;
                default:
                    return false;
            }
            return true;
        }
        public void MovePiece(int currX, int currY, int nextX, int nextY)
        {
            ChessPiece currPiece = board[currX, currY];
            if (IsLegalMove(currX, currY, nextX, nextY))
            {
                board[nextX, nextY] = currPiece;
                board[currX, currY] = none;
                moves.Add($"{moves.Count + 1}.{(char)(currX + 97)}{currY + 1} -> {(char)(nextX + 97)}{nextY + 1}\t*{currPiece.Color}*", currPiece);
            }
        }

    }
}
