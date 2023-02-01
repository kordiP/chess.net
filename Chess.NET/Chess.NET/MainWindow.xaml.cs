using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Chess.NET
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ChessLogic board = new ChessLogic();
        public MainWindow()
        {
            InitializeComponent();
            board.GenerateChessBoard();
            //for (int i = 'a'; i < 'i'; i++) 
            //{
            //    for (int j = 0; j < 8; j++)
            //    {
            //        grid.Add(board.chessBoard[i - 97, j], a1_Path); //replace "a1_Path" with the code for fields in solitaire game from school
            //    }
            //}
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point currentPosition = Mouse.GetPosition(this);
            if (e.LeftButton == MouseButtonState.Pressed && IsOutside(currentPosition))
            {
                DragMove();
            }
            else if (true)
            {

            }
        }
        private bool IsOutside(Point currPos)
        {
            if (currPos.X >= 750 || currPos.X <= 50)
                return true;
            else if (currPos.Y >= 750 || currPos.Y <= 50)
                return true;
            return false;
        }


        private void SwapPieces(Path piece1, Path piece2) // SwapPieces(Piece1, Piece2); *mouseLeftDown*
        {
            (piece1.Data, piece2.Data) = (piece2.Data, piece1.Data);
            (piece1.RenderTransform, piece2.RenderTransform) = (piece2.RenderTransform, piece1.RenderTransform);
            (piece1.Width, piece2.Width) = (piece2.Width, piece1.Width);
            (piece1.Height, piece2.Height) = (piece2.Height, piece1.Height);
            (piece1.Style, piece2.Style) = (piece2.Style, piece1.Style);
        }
    }
}
