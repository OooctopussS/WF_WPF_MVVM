using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using lab5.Models;
using lab5.ViewModels;

namespace lab5
{
    internal class SquareWithBorder : UserItemToDraw
    {

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (IsSelected)
            {
                Pen myPenBorder = new(Brushes.Maroon, 10);
                Rect myRectBorder = new(0, 0, 80, 80);
                drawingContext.DrawRectangle(Brushes.LimeGreen, myPenBorder, myRectBorder);
            }

            Pen myPen = new(Brushes.Black, 5);
            Rect myRect = new(0, 0, 80, 80);

            
            drawingContext.DrawRectangle(Brushes.LimeGreen, myPen, myRect);
        }
    }
}
