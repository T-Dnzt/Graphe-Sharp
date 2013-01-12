using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DLLgraphe.Classes;

namespace DLLgraphe.TraitementAlgo
{
    public class Bellman
    {
        //On crée un dictionnaire qui contient une clé correspondant au noeud d'arrivée et une valeur définissant la longueur du chemin
        private Dictionary<Node, Dictionary<List<Node>, Int32>> path;

        //private String chemin;
        private List<Node> listNodePath;

        private Graph g;
        private Node o;
        


        //Fonctionnel
        public Bellman(Graph graph, Node origine)
        { 
            path = new Dictionary<Node, Dictionary<List<Node>, Int32>>();
            this.g = graph;
            this.o = origine;
            execute(g, o);
        }
       


        //Méthode implémentant l'algorithme de Bellman-Ford
        public Dictionary<Node, Dictionary<List<Node>, Int32>> execute(Graph graph, Node origine)
        {

            //Pour chaque noeud contenu dans le graphe
            foreach (Node n in graph.getNodeList())
            {
                //Si le noeud est égal à l'origine(passée en paramètre)
                if (n.Equals(origine))
                {
                    //La distance est donc de 0
                    n.setDistance(0);
                    //On définit le prédécesseur de l'origine à lui même
                    n.setPredecessor(n);
                }
                else
                {
                    //Si le noeud n'est pas l'origine, on définit une valeur correspondant à "l'infini"
                    n.setDistance(2000000000);
                    //On vide les variables predecessor de noeuds
                    n.setPredecessor(null);
                }
            }

            //Pour le nombre de noeud contenu dans le graphe
            for (Int32 i = 1; i < graph.getNodeList().Count; i++)
            {

                //Pour chaque arc du graphe
                foreach (Arc az in graph.getArcList())
                {
                    //On définit l'origine de l'arc en cours dans le noeud a
                    Node a = az.getOrigin();
                    //On définit l'extrémité de l'arc en cours dans le noeud z
                    Node z = az.getEdge();

                    //Si la distance pour atteindre le noeud a + le coût de l'arc en cours est inférieur à la distance pour atteindre le noeud z
                    if (a.getDistance() + az.getCost() < z.getDistance())
                    {
                        //Alors on définit une nouvelle distance pour atteindre z égale à la distance pour atteindre le noeud a + le coût de l'arc en cours
                        z.setDistance(a.getDistance() + az.getCost());
                        //De plus, on définit l'origine de l'arc en cours en tant que prédécesseur de l'extrémité z
                        z.setPredecessor(a);

                        //Création d'une chaîne de caractères qui contiendra les noeuds de passage
                        //chemin = "";
                        //Ajoute des informations dans le tableau listString
                        //listString.Add("Origine : "+node.getName()+" - Extrémité : "+z.getName()+" - Distance : "+z.getDistance()+" - Par "+definePath(z));

                        Dictionary<List<Node>, Int32> dtemp = new Dictionary<List<Node>, Int32>();
                        listNodePath = new List<Node>();

                      
                            if (path.Keys.Contains(z))
                            {
                                dtemp.Remove(listNodePath);
                                path.Remove(z);
                                definePath(z);
                                listNodePath.Add(origine);
                                dtemp.Add(listNodePath, z.getDistance());
                                path.Add(z, dtemp);

                            }
                            else
                            {

                                definePath(z);
                                listNodePath.Add(origine);
                                dtemp.Add(listNodePath, z.getDistance());
                                path.Add(z, dtemp);
                              
                            }

                        

                    }
                }
            }

            //Boucle foreach permettant de vérifier que le graphe ne contient pas de cycle de poids négatif
            foreach (Arc az in graph.getArcList())
            {
                Node a = az.getOrigin();
                Node z = az.getEdge();
                if (a.getDistance() + az.getCost() < z.getDistance())
                {
                    Console.WriteLine("Le graphe contient un cycle de poids négatif");
                }
            }

            return path;


        }

        public void display()
        {
            Console.WriteLine("Bellman a partir de "+o.getName());
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
     
        private void definePath(Node n)
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
