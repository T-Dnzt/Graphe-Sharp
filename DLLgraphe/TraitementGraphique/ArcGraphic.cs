using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;

namespace DLLgraphe.TraitementGraphique
{
    public class ArcGraphic
    {
        private Int32 cout;
        private NodeGraphic origine;
        private NodeGraphic arrivee;
        private Line ligneArc;

        public ArcGraphic(Int32 coutA, NodeGraphic origineA, NodeGraphic arriveeA)
        {
            this.cout = coutA;
            this.origine = origineA;
            this.arrivee = arriveeA;
        }

        public void DrawArc(Canvas monCanvas)
        {
            LigneArc = new Line();
            this.LigneArc.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            this.LigneArc.X1 = origine.PositionX + 10;
            this.LigneArc.Y1 = origine.PositionY + 10;
            this.LigneArc.X2 = arrivee.PositionX + 10;
            this.LigneArc.Y2 = arrivee.PositionY + 10;
            this.LigneArc.HorizontalAlignment = HorizontalAlignment.Left;
            this.LigneArc.VerticalAlignment = VerticalAlignment.Center;
            this.LigneArc.StrokeThickness = 5;          
            monCanvas.Children.Add(this.LigneArc);
            Canvas.SetZIndex(this.LigneArc, 1);
        }

        public Line LigneArc
        {
            get { return ligneArc; }
            set { ligneArc = value; }
        }

        public Int32 Cout
        {
            get { return cout; }
            set { cout = value; }
        }

        public NodeGraphic Origine
        {
            get { return origine; }
            set { origine = value; }
        }

        public NodeGraphic Arrivee
        {
            get { return arrivee; }
            set { arrivee = value; }
        }
    }
}
