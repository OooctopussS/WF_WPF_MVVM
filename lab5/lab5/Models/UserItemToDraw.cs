using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace lab5.Models
{
    internal abstract class UserItemToDraw : Control
    {
        public double XPointCanvasLeft { get; set; }
        public double YPointCanvasTop { get; set; }

        public bool IsSelected { get; set; }

        protected override void OnRender(DrawingContext drawingContext)
        {

        }
    }
}
