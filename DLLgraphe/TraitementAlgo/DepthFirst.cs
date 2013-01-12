using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DLLgraphe.Classes;


namespace DLLgraphe.TraitementAlgo
{
    public class DepthFirst
    {
        private Dictionary<Node, Node> depthFirstPath;
        private Graph g;
        private Node o;

        public DepthFirst(Graph graph, Node origine)
        {
            depthFirstPath = new Dictionary<Node, Node>();
            this.g = graph;
            this.o = origine;

            foreach (Node n in graph.getNodeList())
            {
                n.unmarkNode();
            }

            executeDFS(g, o);
        }

        public void displayDFSPath()
        {
            Console.WriteLine("DepthFirst a partir de "+o.getName());
            foreach (Node n in depthFirstPath.Keys)
            {
                Console.WriteLine(depthFirstPath[n].getName() + " --> " + n.getName());
            }
            Console.WriteLine(Environment.NewLine);
        }

        //Parcours en profondeur du graph à partir du noeud passé en paramètre
        public void executeDFS(Graph graph, Node origine)
        {
            origine.markNode();

            foreach (Arc a in origine.getEgressArc())
            {

                if (a.getEdge().getNodeState() == false)
                {
                    depthFirstPath.Add(a.getEdge(), a.getOrigin());
                    executeDFS(graph, a.getEdge());
                }
            }
        }
    }
}




/*ALGO n°1 -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

 // Console.WriteLine("Node en cours : " + node.getName());
			node.markNode();

			foreach (Arc a in node.getEgressArc())
			{
			  
				if (a.getEdge().getNodeState() == false)
				{
					Console.WriteLine("Origine de l'arc : " + a.getOrigin().getName());
					Console.WriteLine("Extremite de l'arc : " + a.getEdge().getName());
					depthFirstAlgo(graph, a.getEdge());

				}
			}

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

ALGO n°2 -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
			
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using graphTheory.dfs;

namespace graphTheory
{
	namespace dfs
	{
		enum Color : byte
		{
			White,
			Grey,
			Black
		};
	}

	class DepthFirst
	{
 *         private Graph depthFirstTree;
		private Dictionary<Node, Color> coloredNode;
		private Dictionary<Node, Node> dadSon;
		private Node temp;

		public DepthFirst()
		{
			depthFirstTree = new Graph();
			coloredNode = new Dictionary<Node, Color>();
			dadSon = new Dictionary<Node, Node>();
			temp = new Node();
		}
			foreach (Node n in graph.getNodeList())
			{
				coloredNode.Add(n, Color.White);   
			}

			while(coloredNode.ContainsValue(Color.White))
			{ 
				coloredNode[node] = Color.Grey;
				dadSon.Add(node, node);

				while (coloredNode.ContainsValue(Color.Grey))
				{  
						Random rand = new Random();
						int size = coloredNode.Count;
						int randz = rand.Next(size);
						if (coloredNode.ElementAt(randz).Value == Color.Grey)
						{
							
							temp = coloredNode.ElementAt(randz).Key;
							foreach (Arc a in graph.getArcList())
							{
								if (a.getOrigin() == temp && coloredNode[a.getEdge()] == Color.White)
								{
									coloredNode[a.getEdge()] = Color.Grey;
									dadSon.Add(a.getEdge(), temp);
									Console.WriteLine(temp.getName() + " --> " + a.getEdge().getName());
									
								}
							}

							coloredNode[temp] = Color.Black;
						}

					}
				}

			foreach(Node n in dadSon.Keys)
			{
				Console.WriteLine("Fils : " + n.getName() + " - Pere : " + dadSon[n].getName());
			}
		 }

	}
}

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

*/


/*
 
//On marque le noeud
node.markNode(0);
//On l'affiche à des fins de debuggage
Console.WriteLine("Nom du noeud : " + node.getName());
//Pour chaque arc partant du noeud :
foreach (Arc a in node.getEgressArc())
{
	if (node.getEgressArc().IndexOf(a) == 0)
	{
		temp = a.getCost();
	}
	else if (node.getEgressArc().IndexOf(a) != 0 && temp > a.getCost())
	{
		temp = a.getCost();
		//On récupère le sommet lié à l'arc en cours et on check si il est marqué ou non
		if (a.getEdge().getNodeState() == 0)
		{
			//Utilisation récursive de l'algorithme
			depthFirstAlgo(graph, a.getEdge());
		}
	}
	else
	{
		//On récupère le sommet lié à l'arc en cours et on check si il est marqué ou non
		if (a.getEdge().getNodeState() == 0)
		{
			//Utilisation récursive de l'algorithme
			depthFirstAlgo(graph, a.getEdge());
		}
	}
				
				
			   
}
}
/*
//EN COURS
//Création d'un arbre à partir du parcours en profondeur
public Graph linkedTreeToDepthFirst(Graph graph, Node node)
{
		   
//On marque le noeud
node.markNode(0);
		   
//On copie les caractéristiques du noeud dans un nouveau noeud
 Node n = new Node(node.getIndex(), node.getName());

//On ajoute ce dernier au graphe
 depthFirstTree.addNode(n);
			
//Pour chaque arc partant du noeud :
foreach (Arc a in node.getEgressArc())
{
		if (node.getEgressArc().IndexOf(a) == 0)
		{
			temp = a.getCost();
			Console.WriteLine("1 : " + temp);
		}

	   if (a.getEdge().getNodeState() == 0)
	   {
					  
				temp = a.getCost();

				Node e = new Node(a.getEdge().getIndex(), a.getEdge().getName());
				depthFirstTree.addArc(new Arc(a.getCost(), n, e));
				linkedTreeToDepthFirst(graph, a.getEdge());

				Console.WriteLine("Origine : " + n.getName() + " -- Destination : " + e.getName() + " -- Coût : " + a.getCost());

	   }
				   
}
node.markNode(1);
return depthFirstTree;
}



/*
public Boolean checkWay(Int32 tempM, Int32 cost)
{

if (tempM > cost)
{
	return true;     
}
else //if (tempM == cost || tempM < cost)
{
	return false;
}
	  
}
}
}
*/