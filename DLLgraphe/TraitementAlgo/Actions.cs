using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DLLgraphe.Classes;
using System.Diagnostics;

namespace DLLgraphe.TraitementAlgo
{
    public class Actions
    {
        private Bellman bell;
        private DepthFirst dfs;
        private Dijkstra dijk;
        private Floyd flo;

        public Actions()
        {
         
        }

        public void testPerf(Graph g)
        {
            long milliseconds;

            Stopwatch stopDij = new Stopwatch();
            stopDij.Start();
            Dijkstra dj = new Dijkstra(g, g.getNodeAt(0));
            stopDij.Stop();
            milliseconds = stopDij.ElapsedMilliseconds;
            Console.WriteLine("Dijkstra : " + milliseconds + " ms");




            Stopwatch stopBell = new Stopwatch();
            stopBell.Start();
            Bellman bm = new Bellman(g, g.getNodeAt(0));
            stopBell.Stop();
            milliseconds = stopBell.ElapsedMilliseconds;
            Console.WriteLine("Bellman : " + milliseconds + " ms");



            Stopwatch stopDFS = new Stopwatch();
            stopDFS.Start();
            DepthFirst dfs = new DepthFirst(g , g.getNodeAt(0));
            stopDFS.Stop();
            milliseconds = stopDFS.ElapsedMilliseconds;
            Console.WriteLine("DFS : " + milliseconds + " ms");


            Stopwatch stopFloyd = new Stopwatch();
            stopFloyd.Start();
            Floyd fl = new Floyd(g);
            stopFloyd.Stop();
            milliseconds = stopFloyd.ElapsedMilliseconds;
            Console.WriteLine("Floyd : " + milliseconds + " ms");

        }



        //Recherche d'un arbre couvrant à partir d'un sommet racine par parcours en profondeur.
        //Ajout d'un sommet d'arrivé en option ?
        public String depthFirst(ref Graph graph, ref Node node)
        {
            return "";
        }
       
        //Algorithmes de recherche du plus court chemin
        //Dijkstra: Ne prend pas les valeurs négatives
        public String dijkstra(ref Graph graph, ref Node node)
        {
            return "";
        }
        //Floyd
        public String Floyd(ref Graph graph, ref Node node)
        {
            return "";
        }
        //Bellman
        public String Bellman(ref Graph graph, ref Node node)
        {
            return "";
        }

        //Recherche des composantes fortement connexes
        public List<String> strConComponent(ref Graph graph)
        {
            List<String> temp = null;
            return temp;
        }
    }
}
