using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLLgraphe.Classes
{
    [Serializable]

    public class Node
    {
        private String name;
        private Int32 index; //Index du noeud
        private List<Arc> ingressArc;
        private List<Arc> egressArc;
        private List<Node> egressNode;


        private Int32 distance;
        private Node predecessor;
       
        private Boolean nodeState;

        private int indexSCC;
        private int lowlink;

        public Node()
        {
            this.name = "";
            this.index = 0;
            this.ingressArc = new List<Arc>();
            this.egressArc = new List<Arc>();
            this.egressNode = new List<Node>();
            setEgressNode();

            nodeState = false;

           
        }

        public Node(Int32 index)
        {
            this.name = "node "+index;
            this.index = index;
            this.ingressArc = new List<Arc>();
            this.egressArc = new List<Arc>();
            this.egressNode = new List<Node>();
            setEgressNode();
            nodeState = false;
         
        }

        public Node(Int32 index, String name)
        {
            this.name = name;
            this.index = index;
            this.ingressArc = new List<Arc>();
            this.egressArc = new List<Arc>();
            this.egressNode = new List<Node>();
            setEgressNode();
            nodeState = false;
        }

        public Node(Int32 index, String name, List<Arc> ingressArc, List<Arc> egressArc)
        {
            this.name = name;
            this.index = index;
            this.ingressArc = ingressArc;
            this.egressArc = egressArc;
            sortArcList(this.ingressArc);
            sortArcList(this.egressArc);
            this.egressNode = new List<Node>();
            setEgressNode();
            nodeState = false;
        }



        public int getLowlink()
        {
            return lowlink;
        }

        public int getIndexSCC()
        {
            return indexSCC;
        }

        public void setLowlink(int i)
        {
            lowlink = i;
        }
      

        public void setIndexSCC(int i)
        {
            indexSCC = i;
        }



        public void unmarkNode()
        {
            nodeState = false;
        }



        public void markNode()
        {
            nodeState = true;
        }

        public Boolean getNodeState()
        {
            return nodeState;
        }




        public void setDistance(Int32 d)
        {
             distance = d;
        }

        public Int32 getDistance()
        {
            return distance;
        }

        public void setPredecessor(Node n)
        {
            predecessor = n;
        }

        public Node getPredecessor()
        {
            return predecessor;
        }



  

        public Int32 getDegree()
        {

            return Math.Abs(ingressDegree()) + Math.Abs(egressDegree());
        }





        public Int32 ingressDegree()
        {
            if (ingressArc == null)
                return 0;
            else
                return this.ingressArc.Count;
        }

        public Int32 egressDegree()
        {
            if (egressArc == null)
                return 0;
            else
                return this.egressArc.Count;
        }

        public void addLinkedArc(Arc arc, bool ingress)
        {
            if (ingress)
            {
                sortArcList(this.ingressArc);
                this.ingressArc.Add(arc);
            }
            else
            {
                sortArcList(this.egressArc);
                this.egressArc.Add(arc);
            }
        }

        public void removeLinkedArc(Arc arc, bool ingress)
        {
            if (ingress)
                this.ingressArc.Remove(arc);
            else
                this.egressArc.Remove(arc);
        }

        public void sortArcList(List<Arc> _arcs)
        {
            if (_arcs != null)
            {
                for (int i = 0; i < _arcs.Count(); i++)
                {
                    for (int j = 0; j < _arcs.Count() - 1; j++)
                    {
                        //On compare l'index du noeud d'origine de deux arcs
                        if (_arcs[j].getEdge().getIndex() > _arcs[j + 1].getEdge().getIndex())
                        {
                            Arc tmp = _arcs[j];
                            _arcs[j] = _arcs[j + 1];
                            _arcs[j + 1] = tmp;
                        }
                    }
                }
            }
        }

        public String getName()
        {
            return this.name;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public Int32 getIndex()
        {
            return this.index;
        }

        public void setIndex(Int32 index)
        {
            this.index = index;
        }

        public List<Arc> getIngressArc()
        {
            return ingressArc;
        }

        public List<Arc> getEgressArc()
        {
            return egressArc;
        }

        public void setEgressNode()
        {
            foreach (Arc a in egressArc)
            {
                egressNode.Add(a.getEdge());
            }
        }

        public List<Node> getEgressNode()
        {
            return egressNode;
        }

        public Node getEgressNodeAt(Int32 i)
        {
            return egressNode[i];
        }
    }
}
