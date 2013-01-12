using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLLgraphe.Classes
{
    [Serializable]
    public class Arc
    {
        private Int32 cost;
        private Node origin;
        private Node edge;

        public Arc()
        {
            this.cost = 0;
            this.origin = null;
            this.edge = null;
        }

        public Arc(Int32 cost, Node origin)
        {
            this.cost = cost;
            this.origin = origin;
            this.edge = null;
        }

        public Arc(Int32 cost, Node origin, Node edge)
        {
            this.cost = cost;
            this.origin = origin;
            this.edge = edge;
        }

        public Boolean equals(Arc arc)
        {
            //La valeur est unique à chaque Noeud.
            if(this.cost == arc.cost && this.origin == arc.getOrigin() && this.edge == arc.getEdge())
                return true;
            else
                return false;
        }

        public Int32 getCost()
        {
            return this.cost;
        }

        public void setCost(Int32 cost)
        {
            this.cost = cost;
        }

        public Node getOrigin()
        {
            return this.origin;
        }

        public void setOrigin(Node origin)
        {
            this.origin = origin;
        }

        public Node getEdge()
        {
            return this.edge;
        }

        public void setEdge(Node edge)
        {
           bool exist = false;
            int i = 0;
            //On vérifie qu'il n'y a pas déjà un arc existant entre le sommet d'origine et d'extrêmité.
            while (!exist && i < edge.getIngressArc().Count())
            {
                if (this.origin == edge.getIngressArc().ElementAt(i).getOrigin())
                    exist = true;
                i++;
            }
            if (!exist)
                this.edge = edge;
           else
                Console.WriteLine("This arc already exist");
        }
    }
}
