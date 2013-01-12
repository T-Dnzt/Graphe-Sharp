using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DLLgraphe.Classes;


namespace DLLgraphe.TraitementAlgo
{
    public class Dijkstra
    {
        private List<Node> Queue;

        private Dictionary<Node, Dictionary<List<Node>, Int32>> path;
        private List<Node> listNodePath;

        private Graph g;
        private Node o;

        public Dijkstra(Graph graph, Node origine)
        {
            path = new Dictionary<Node, Dictionary<List<Node>, Int32>>();
            this.g = graph;
            this.o = origine;
            execute(g, origine);
        }

        public Dictionary<Node, Dictionary<List<Node>, Int32>> execute(Graph g, Node origine)
        {
            
             Queue = new List<Node>();

            foreach (Node n in g.getNodeList())
            {
                Queue.Add(n);
                
                if (n.Equals(origine))
                {
                    n.setDistance(0);
                    n.setPredecessor(n);
               
                }
                else
                {
                    n.setDistance(2000000000);
                    n.setPredecessor(null);
                }
   
            }

           
            while (Queue.Count > 0)
            {
                Node u = getSmallest(Queue);

                if (u.getDistance() == 2000000000)
                {
                    break;
                }


                Queue.Remove(u);
             

                foreach (Arc a in g.getArcList())
                {
                    if (a.getOrigin() == u && Queue.Contains(a.getEdge()))
                    {
                       
                        Node z = a.getEdge();

                       // Console.WriteLine(o.getName() + " -- " + z.getName());
                        
                        Int32 tempDistance = u.getDistance() + a.getCost();
                       // Console.WriteLine("Distance origine : "+u.getDistance()+" - Cout arc : "+a.getCost()+ " tmp : "+tempDistance+" - Distance extremite : "+z.getDistance());
                        if (tempDistance < z.getDistance())
                        {
                            z.setDistance(tempDistance);
                            z.setPredecessor(u);
                           
                            Dictionary<List<Node>, Int32> dtemp = new Dictionary<List<Node>, Int32>();
                            listNodePath = new List<Node>();

                           

                            if (path.Keys.Contains(z))
                            {
                                dtemp.Remove(listNodePath);
                                path.Remove(a.getEdge());
                                
                                definePath(z);
                                listNodePath.Add(origine);
                                dtemp.Add(listNodePath, z.getDistance());
                                path.Add(z, dtemp);
                               // Console.WriteLine("lol distance : "+z.getName()+" = "+z.getDistance());
                               
                            }
                            else
                            {
                                definePath(a.getEdge());
                                listNodePath.Add(origine);
                                dtemp.Add(listNodePath, z.getDistance());
                                path.Add(z, dtemp);
                                //Console.WriteLine("lol2 distance : " + z.getName() + " = " + z.getDistance());      
                            }
                           


                        }
                      //  Console.WriteLine();

                    }
                }
            }

            return path;
        }

        public void display()
        {
            Console.WriteLine("Dijkstra : ");
            foreach (Node nx in path.Keys)
            {

                String test = "";
                test = nx.getName() + " " + path[nx].ElementAt(0).Value + " par ";

                foreach (List<Node> ln in path[nx].Keys)
                {
                    foreach (Node nz in ln)
                    {
                        test += " - " + nz.getName();
                    }
                }

                Console.WriteLine(test);
            }
            Console.WriteLine(Environment.NewLine);
        }

        public Node getSmallest(List<Node> list)
        {

            Node temp = list.ElementAt(0);
            foreach (Node n in list)
            {
                if (n.getDistance() < temp.getDistance())
                {
                    temp.setDistance(n.getDistance());
                }
            }
            return temp;
        }


        public void definePath(Node n)
        {
            if (n.getName() != n.getPredecessor().getName())
            {
              
                    if (n.getPredecessor().getPredecessor().getName() != n.getPredecessor().getName())
                    {
                        listNodePath.Add(n.getPredecessor());
                    }
                    definePath(n.getPredecessor());
         
            }

        }

       
    }
}
