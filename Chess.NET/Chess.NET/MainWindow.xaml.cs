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
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point currentPosition = new Point();
            currentPosition = Mouse.GetPosition(this);
            if (e.LeftButton == MouseButtonState.Pressed && IsOutside(currentPosition))
            {
                DragMove();
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


        private void white_Knight1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {

            }
        }
        private void white_pawn2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {

            }
        }

    }
}
