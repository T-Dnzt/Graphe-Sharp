using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DLLgraphe.Classes;


namespace DLLgraphe.TraitementAlgo
{

    public class StronglyConnectedComponent
    {

        List<List<Node>> scc;
   
        Int32 index;
        List<Node> s;

        public StronglyConnectedComponent()
        {
    
            s = new List<Node>();
            scc = new List<List<Node>>();
            index = 0; 
        }

        public void displaySCC(Graph g)
        {
            List<List<Node>> disp = compute(g);

            Console.WriteLine("Composantes fortement connexes : ");
            foreach (List<Node> list in disp)
            {
                foreach (Node n in list)
                {
                    Console.WriteLine(n.getName());
                }
                Console.WriteLine("Fin de la composante"+Environment.NewLine);
            }
            Console.WriteLine(Environment.NewLine);
        }

        public List<List<Node>> compute(Graph g)
        {
            foreach (Node no in g.getNodeList())
            {
                no.setIndexSCC(Int32.MaxValue);
            }
       
            foreach (Node n in g.getNodeList())
            {
                if (n.getIndexSCC() == Int32.MaxValue)
                {
                    strongConnect(g, n);
                }
            }

            return scc;
   
        }

        private void strongConnect(Graph g, Node n)
        {

            n.setIndexSCC(index);
            n.setLowlink(index);
    
            index++;

            s.Add(n);

            foreach (Arc a in g.getArcList())
            {
                if (a.getOrigin() == n)
                {
                    if (a.getEdge().getIndexSCC() == int.MaxValue)
                    {
                        strongConnect(g, a.getEdge());
                        n.setLowlink(Math.Min(n.getLowlink(), a.getEdge().getLowlink()));
                    }
                    else if(s.Contains(a.getEdge()))
                    {
                        n.setLowlink(Math.Min(n.getLowlink(), a.getEdge().getIndexSCC()));
                         
                    }
                    
                }

            }

            if (n.getLowlink() == n.getIndexSCC())
            {
              
               scc.Add(new List<Node>());
               Node w = new Node();

                do
                {
                    w = s.Last();
                    
                    s.Remove(s.Last());
                    scc.Last().Add(w);

                }
                while (n != w);

                

            }


           
         

        }

    }
}
