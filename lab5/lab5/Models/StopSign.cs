using lab5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace lab5
{
    internal class StopSign : UserItemToDraw
    {
        protected override void OnRender(DrawingContext drawingContext)
        {
            if (IsSelected)
            {
                Pen myPenBorder = new(Brushes.Maroon, 10);
                drawingContext.DrawEllipse(Brushes.Red, myPenBorder, new Point(0, 0), 60, 60);
            }

            Rect myRect = new(0 - 40, 0 - 10, 80, 20);
            
            drawingContext.DrawEllipse(Brushes.Red, null, new Point(0, 0), 60, 60);
            drawingContext.DrawRoundedRectangle(Brushes.White, null, myRect, 5, 5);
        }

    }
}
