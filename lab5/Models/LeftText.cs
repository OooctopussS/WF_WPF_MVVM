using lab5.Models;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace lab5
{
    internal class LeftText : UserItemToDraw
    {
        protected override void OnRender(DrawingContext drawingContext)
        {
            string testString = "Налево";

            FormattedText formattedText = new(testString, CultureInfo.CurrentCulture, FlowDirection.LeftToRight,
                new Typeface("Verdana"), 16, Brushes.Navy);


            if (IsSelected)
            {
                Geometry textGeometry = formattedText.BuildGeometry(new Point(0, 0));
                drawingContext.DrawGeometry(null, new Pen(new SolidColorBrush(Color.FromRgb(128, 00, 00)), 1), textGeometry);
            }

            drawingContext.DrawText(formattedText, new Point(0, 0));
        }
    }
}
