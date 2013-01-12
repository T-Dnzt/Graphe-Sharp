using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DLLgraphe;
using DLLgraphe.Classes;
using DLLgraphe.ExportImport;
using DLLgraphe.TraitementAlgo;



namespace consolegraphe
{
    class Program
    {
        static void Main(string[] args)
        {
           /*
           
            Object[,] graphComponent = new Object[,] {
            {"Paris",    int.MaxValue, 1, int.MaxValue, int.MaxValue, 11, int.MaxValue, int.MaxValue}, 
            {"Bordeaux", int.MaxValue,  int.MaxValue, 5, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue},
            {"Bayonne",  int.MaxValue,  int.MaxValue,  int.MaxValue,  5,  int.MaxValue, int.MaxValue, int.MaxValue},
            {"Pau",      3,   int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, 3},
            {"Bangkok",  int.MaxValue,  int.MaxValue, int.MaxValue,int.MaxValue, int.MaxValue, 8, 13},
            {"Yangon", int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, 3, int.MaxValue, int.MaxValue},
            {"Tarbes", int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue , int.MaxValue}, 
            };
        */
            
            Object[,] graphComponent = new Object[,] {
             {"Paris",    0, 1, 10, 3, int.MaxValue, int.MaxValue, int.MaxValue}, 
            {"Bordeaux", 4,   0, 3, 1, int.MaxValue, int.MaxValue, 5},
            {"Pau",      3,   7, 0, 1, int.MaxValue, 10, int.MaxValue},
             {"Bangkok",  52,  4, 1, 0, 8, int.MaxValue, int.MaxValue},
            {"Yangon", int.MaxValue, int.MaxValue, int.MaxValue, 8, int.MaxValue, int.MaxValue, int.MaxValue},
            {"Tarbes", int.MaxValue, 5, int.MaxValue, int.MaxValue, int.MaxValue, 0, int.MaxValue},
            {"Bayonne",  int.MaxValue,  int.MaxValue,  int.MaxValue,  int.MaxValue,  int.MaxValue, int.MaxValue, 0},
            };
     
            
            Graph g = new Graph(graphComponent);
            g.display();

            g.displayCurrentMatrix();
          
            SaveManager sm = new SaveManager();
            sm.saveGraph(g);

            
            StronglyConnectedComponent scc = new StronglyConnectedComponent();
            scc.displaySCC(g);

          
            /*
            Actions a = new Actions();
            a.testPerf(g);
            */
            Bellman bm = new Bellman(g, g.getNodeAt(0));
            bm.display();
            
            Dijkstra dj = new Dijkstra(g, g.getNodeAt(0));
            dj.display();





            /*
             * 
            Floyd flo = new Floyd(g);
            flo.display();
             * 
            DepthFirst dfs = new DepthFirst(g, g.getNodeAt(0));
            dfs.displayDFSPath();

            TreeDepthFirst tdfs = new TreeDepthFirst(g, g.getNodeAt(0));
            Graph zi = tdfs.getDFSGraph();

            zi.display();
 */
        }
    }
}
