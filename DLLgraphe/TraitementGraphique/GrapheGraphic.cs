using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;

namespace DLLgraphe.TraitementGraphique
{
    public class GrapheGraphic
    {
        public static Canvas monCanvas;
        public List<NodeGraphic> mesNoeud = new List<NodeGraphic>();
        public List<ArcGraphic> mesArcs = new List<ArcGraphic>();
        public Boolean booleen = false;
        public NodeGraphic sommetSelect;

        public GrapheGraphic(Canvas canvas_graphe)
        {
            monCanvas = canvas_graphe;
        }

        public void graphique(MouseButtonEventArgs monEvenement, int monMode)
        {
            NodeGraphic monSommet;
            Point monPoint = monEvenement.GetPosition(monCanvas);
            //ajout d'un point
            if (monMode == 2)
            {
                monSommet = new NodeGraphic("", monPoint.Y - 10, monPoint.X - 10, new Ellipse());
                monSommet.DrawNode(monCanvas);
                mesNoeud.Add(monSommet);
            }

            else if (monMode == 1)
            {

            }
            //ajout d'un arc
            else if (monMode == 5)
            {
                Ellipse monEllipse = new Ellipse();
                if (booleen == false)
                {
                    //test si l'ellipse est bien cliqué.
                    HitTestResult result = VisualTreeHelper.HitTest(monCanvas, monPoint);
                    if ((result != null) && (result.VisualHit is Ellipse))
                    {
                        monEllipse = (Ellipse)result.VisualHit;
                        foreach (NodeGraphic i in mesNoeud)
                        {
                            if (i.PositionX == Canvas.GetLeft(monEllipse) && i.PositionY == Canvas.GetTop(monEllipse))
                            {
                                sommetSelect = i;
                            }
                        }
                        booleen = true;
                    }
                }
                else
                {
                    //test si l'ellipse est bien cliqué.
                    HitTestResult result = VisualTreeHelper.HitTest(monCanvas, monPoint);
                    if ((result != null) && (result.VisualHit is Ellipse))
                    {
                        monEllipse = (Ellipse)result.VisualHit;
                        foreach (NodeGraphic i in mesNoeud)
                        {
                            if (i.PositionX == Canvas.GetLeft(monEllipse) && i.PositionY == Canvas.GetTop(monEllipse))
                            {
                                ArcGraphic monArc = new ArcGraphic(0, sommetSelect, i);
                                monArc.DrawArc(monCanvas);
                                mesArcs.Add(monArc);
                            }
                        }
                    }
                    booleen = false;
                }
            }
            else if (monMode == 4)
            {

                Ellipse monEllipse = new Ellipse();
                //test si l'ellipse est bien cliqué.
                HitTestResult result = VisualTreeHelper.HitTest(monCanvas, monPoint);
                if ((result != null) && (result.VisualHit is Ellipse))
                {
                    List<ArcGraphic> arcaSupprimer = new List<ArcGraphic>();
                    List<NodeGraphic> nodeaSupprimer = new List<NodeGraphic>();
                    monEllipse = (Ellipse)result.VisualHit;
                    foreach (NodeGraphic i in mesNoeud)
                    {
                        if (i.PositionX == Canvas.GetLeft(monEllipse) && i.PositionY == Canvas.GetTop(monEllipse))
                        {
                            nodeaSupprimer.Add(i);
                            if (mesArcs.Count != 0)
                            {
                                foreach (ArcGraphic j in mesArcs)
                                {
                                    if (j.Arrivee == i || j.Origine == i)
                                    {
                                        arcaSupprimer.Add(j);
                                    }
                                }
                            }     
                        }
                    }

                    foreach (NodeGraphic i in nodeaSupprimer)
                    { 
                        monCanvas.Children.Remove(i.EllipseSommet);
                        mesNoeud.Remove(i);
                    }
                    foreach (ArcGraphic j in arcaSupprimer)
                    {
                        monCanvas.Children.Remove(j.LigneArc);
                        mesArcs.Remove(j);
                    }
                }
            }

        }

        public void dragndrop()
        {


        }
    }
}
