using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;

namespace DLLgraphe.TraitementGraphique
{
    public class NodeGraphic
    {

        private String name;
        private double positionY;
        private double positionX;
        private Ellipse ellipseSommet;

        public NodeGraphic(String nameS, double posY, double posX, Ellipse ellipseS)
        {
            this.name = nameS;
            this.positionY = posY;
            this.positionX = posX;
            this.ellipseSommet = ellipseS;
        }

        public void DrawNode(Canvas monCanvas)
        {
            this.ellipseSommet.Fill = Brushes.Gray;
            this.ellipseSommet.Stroke = Brushes.Black;
            this.ellipseSommet.Width = 20;
            this.ellipseSommet.Height = 20;
            Canvas.SetLeft(this.ellipseSommet, this.positionX);
            Canvas.SetTop(this.ellipseSommet, this.positionY);
            monCanvas.Children.Add(this.ellipseSommet);
            Canvas.SetZIndex(ellipseSommet, 5);
        }

        public String NameNoeud
        {
            get { return name; }
            set { name = value; }
        }
        public double PositionY
        {
            get { return positionY; }
            set { positionY = value; }
        }
        public double PositionX
        {
            get { return positionX; }
            set { positionX = value; }
        }
        public Ellipse EllipseSommet
        {
            get { return ellipseSommet; }
            set { ellipseSommet = value; }
        }
    }
}
