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
            //Point currentPosition = new Point();
            //currentPosition = Mouse.GetPosition(this);
            //if (e.LeftButton == MouseButtonState.Pressed && IsOutside(currentPosition))
            //{
            //    DragMove();
            //}
        }
        //private bool IsOutside(Point currPos)
        //{
        //    if (currPos.X >= 750 || currPos.X <= 50)
        //        return true;
        //    else if (currPos.Y >= 750 || currPos.Y <= 50)
        //        return true;
        //    return false;
        //}


        private void white_Knight1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(white_Knight1, new DataObject(DataFormats.Serializable,white_Knight1), DragDropEffects.Move);
            }            
        }
        private void b1_Canvas_Drop(object sender, DragEventArgs e)
        {
            object data = e.Data.GetData(DataFormats.Serializable);
            if (data is UIElement element)
            {
                Point dropPosition = e.GetPosition(b1_Canvas);
                Canvas.SetLeft(element, dropPosition.X);
                Canvas.SetTop(element, dropPosition.Y);
                b1_Canvas.Children.Add(element);
            }
        }
        private void b1_Canvas_DragLeave(object sender, DragEventArgs e)
        {
            if (e.OriginalSource == b1_Canvas)
            {

                object data = e.Data.GetData(DataFormats.Serializable);
                if (data is UIElement element)
                {
                    b1_Canvas.Children.Remove(element);
                }
            }
        }


        private void white_pawn2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop(white_pawn2, new DataObject(DataFormats.Serializable, white_pawn2), DragDropEffects.Move);
            }
        }

        private void b2_Canvas_Drop(object sender, DragEventArgs e)
        {
            object data = e.Data.GetData(DataFormats.Serializable);
            if (data is UIElement element)
            {

                Point dropPosition = e.GetPosition(b2_Canvas);
                Canvas.SetLeft(element, dropPosition.X);
                Canvas.SetTop(element, dropPosition.Y);
                b2_Canvas.Children.Add(element);
            }
        }

        private void b2_Canvas_DragLeave(object sender, DragEventArgs e)
        {
            if (e.OriginalSource == b2_Canvas)
            { 
                object data = e.Data.GetData(DataFormats.Serializable);
                if (data is UIElement element)
                {
                    b2_Canvas.Children.Remove(element);
                }
            }
        }
    }
}
