using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DLLgraphe.Classes;


namespace DLLgraphe.TraitementAlgo
{
    public class TreeDepthFirst
    {
        private Graph depthFirstTree;
        private Graph graph;
        private Node origine;


        public TreeDepthFirst(Graph graph, Node origine)
        {
            depthFirstTree = new Graph();
            depthFirstTree.setMatrix(graph.getMatrix());
            this.graph = graph;
            this.origine = origine;

            foreach (Node n in graph.getNodeList())
            {
                n.unmarkNode();
            }
        }

        public Graph getDFSGraph()
        {
            execute(this.graph, this.origine);
            return depthFirstTree;
        }

		public void execute(Graph graph, Node node)
		{			   
                //On marque le noeud
                node.markNode();
		   
                //On copie les caractéristiques du noeud dans un nouveau noeud
                 Node n = new Node(node.getIndex(), node.getName());

                //On ajoute ce dernier au graphe
                 depthFirstTree.addNode(n);
                 
                //Pour chaque arc partant du noeud :
                foreach (Arc a in node.getEgressArc())
                {
				    if (a.getEdge().getNodeState() == false)
				    {
                        Node e = new Node(a.getEdge().getIndex(), a.getEdge().getName());
                        depthFirstTree.addArc(new Arc(a.getCost(), n, e));
                        execute(graph, a.getEdge());
				    }
                }
        }
    }
}

