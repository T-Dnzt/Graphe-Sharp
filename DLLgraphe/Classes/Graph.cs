using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;

namespace DLLgraphe.Classes
{
    [Serializable]
    public class Graph
    {
        private List<Arc> _arcs;
        private List<Node> _nodes;
        Matrix costMatrix; //La matrice des coûts. 
        //Elle permettra d'effectuer des calculs plus simples et plus rapides pour les différents algorithmes utilisés.

        public Graph()
        {
            this._arcs = new List<Arc>();
            this._nodes = new List<Node>();
            this.costMatrix = new Matrix();
        }

        public Graph(List<Arc> arcs, List<Node> nodes)
        {
            this._arcs = arcs;
            this._nodes = nodes;
        }

        //Constructeur d'un graphe à partir d'une matrice des coûts
        public Graph(Object[,] costM)
        {
            this._arcs = new List<Arc>();
            this._nodes = new List<Node>();
            this.costMatrix = new Matrix(costM);
            this.generateGraph(costM);
        }

        //Permet de générer un graphe à partir de la matrice des coûts
        public void generateGraph(Object[,] costM)
        {  
            if (costM != null)
            {
                if (costM.GetLength(0) == costM.GetLength(1) - 1) // On vérifie que la matrice est carrée
                {
                    //Création des sommets
                    for (int i = 0; i < costM.GetLength(0); i++)
                        _nodes.Add(new Node(i, (String)costM[i,0]));

                    for (int i = 0; i < costM.GetLength(0); i++)
                    {
                        for (int j = 1; j < costM.GetLength(1); j++)
                        {
                            if (costM[i, j] != null)
                            {
                                if ((Int32)costM[i, j] != 0 && (Int32)costM[i, j] != int.MaxValue) //Si la valeur est de 0, c-à-d d'un sommet vers lui même avec un chemin de valeur 0, alors il n'y a pas d'arcs. 
                                {
                                    Arc a = new Arc((Int32)costM[i, j], _nodes[i], _nodes[j - 1]);
                                    _nodes[i].addLinkedArc(a, false); //ajout d'un degré sortant au noeud d'origine de l'arc
                                    _nodes[j - 1].addLinkedArc(a, true);  //ajout d'un degré entrant au noeud d'extrémité de l'arc
                                    _arcs.Add(a);
                                }
                            } 
                        }
                    }
                }
                else
                    Console.WriteLine("Erreur: La matrice n'est pas carrée.");
            }
        }

        public void generateMatrix()
        {
            costMatrix.generateMatrix(this);
        }

        public Matrix getMatrix()
        {
            return costMatrix;
        }

        public void setMatrix(Matrix mat)
        {
            costMatrix = mat;
        }

        public void setMatrixAt(int row, int col, Int32 val)
        {
            
        }

        /// <summary>
        ///  Ajoute un arc au graphe: void addArc(Arc)
        /// </summary>
        public void addArc(Arc arc)
        {
            _arcs.Add(arc);
            sortArcList(); //replace l'arc dans le tableau
            int x = 0, y = 0;
            x = arc.getOrigin().getIndex();
            y = arc.getEdge().getIndex();
            costMatrix.setValueAt(arc.getCost(), x, y);
        }

        public void deleteArc(Arc arc)
        {
            //On enlève l'arc des noeuds lui étant liés
            arc.getOrigin().removeLinkedArc(arc, false);
            arc.getEdge().removeLinkedArc(arc, true);
            //On actualise la valeur dans la matrice
            int x = arc.getOrigin().getIndex();
            int y = arc.getEdge().getIndex();
            costMatrix.setValueAt(int.MaxValue, x, y);
            //On enlève l'arc du graphe
            _arcs.Remove(arc);
            //On actualise l'ordre des arbres dans la liste
            sortArcList();
        }

        /*Classe les arcs dans la liste d'arc selon un ordre logique.  Exemple ci-dessous:
         * [0] : n1 -> n1
         * [1] : n1 -> n2
         * [2] : n1 -> n3
         * [3] : n2 -> n1
         * [4] : n2 -> n2
         * [5] : n2 -> n3 ...
         */
        public void sortArcList()
        {
            if (_arcs != null)
            {
                for (int i = 0; i < _arcs.Count(); i++)
                {
                    for (int j = 0; j < _arcs.Count() - 1; j++)
                    {
                        //On compare l'index du noeud d'origine de deux arcs
                        if (_arcs[j].getOrigin().getIndex() > _arcs[j + 1].getOrigin().getIndex()) 
                        {
                            Arc tmp = _arcs[j];
                            _arcs[j] = _arcs[j + 1];
                            _arcs[j + 1] = tmp;
                        }
                        //Si les origines sont égales on compare les extrémités
                        else if (_arcs[j].getOrigin().getIndex() == _arcs[j + 1].getOrigin().getIndex()) 
                        {
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
        }

        public List<Arc> getArcList()
        {
            return _arcs;
        }

        public Arc getArcAt(int index)
        {
            if (_arcs != null)
            {
                if (_arcs.Count > 0)
                {
                    if (index < 0)
                        return _arcs.First();
                    else if (index >= _nodes.Count)
                        return _arcs.Last();

                    return _arcs[index];
                }
               
            }
            return null;
        }

        /// <summary>
        /// Node's methods
        /// </summary>
        /// 

        public List<Node> getNodeList()
        {
            return _nodes;
        }

        public Node getNodeAt(int index)
        {
            if (_nodes != null)
            {
                if (_nodes.Count > 0)
                {
                    if (index < 0)
                        return _nodes.First();
                    else if (index >= _nodes.Count)
                        return _nodes.Last();

                    return _nodes[index];
                }
            }
            return null;
        }

        public void refreshIndex()
        {
            for (int i = 0; i < _nodes.Count; i++)
                _nodes[i].setIndex(i);
        }

        public void addNode(Node nodes)
        {
            refreshIndex();//On s'assure de la bonne position des index

            int index = 0;
            if(_nodes.Count > 0)
                index = _nodes.Last().getIndex() + 1;
            nodes.setIndex(index);
            _nodes.Add(nodes);
            updateMatrix();
        }

        public void insertNode(Node nodes) // NOT OK
        {
            _nodes.Insert(nodes.getIndex(), nodes);
            refreshIndex();
            updateMatrix();
        }


        public void deleteNode(Node node)
        {
            Console.WriteLine("Suppresion du noeud: " + node.getName());
           
            //Suppression des arcs liés au sommet supprimé
            List<Arc> arcToDelete = new List<Arc>(); //Liste des arcs qui seront supprimés.
            
            foreach(Arc val in node.getIngressArc())
                arcToDelete.Add(val);
            foreach (Arc val in node.getEgressArc())
                arcToDelete.Add(val);
            foreach (Arc val in arcToDelete)
                deleteArc(val);
       
            _nodes.Remove(node);
            //updateMatrix();
            costMatrix.removeNode(node.getIndex());
            refreshIndex();
        }

        public void renameNode(int index, String newName)
        {
            if(_nodes != null)
            {
                if(index < 0 || index >= _nodes.Count)
                {
                    Console.WriteLine("Index out of bounds");
                    return;
                }
                _nodes[index].setName(newName);
            }          
        }

        public void renameNode(String oldName, String newName)
        {
            if (_nodes != null)
            {
                foreach (Node n in _nodes)
                {
                    if (n.getName().Equals(oldName))
                        n.setName(newName);
                }
            }
        }

        /// <summary>
        /// affiche les noeuds et arcs composants le graphe
        /// </summary>
        public void display()
        {
            Console.WriteLine();
            Console.WriteLine("Le graphe est composé des arcs suivant: ");
           foreach(Arc value in _arcs)
                Console.WriteLine(value.getOrigin().getIndex() + " -> " + value.getEdge().getIndex() +
                    ": "+ value.getOrigin().getName() + " -- "+value.getCost()+" --> " + value.getEdge().getName());
            Console.Write("Le graphe est composé des noeuds suivant: ");
            foreach (Node value in _nodes)
                Console.Write(value.getName()+", ");

            Console.WriteLine();
            Console.WriteLine();
        }

        public void displayCurrentMatrix()
        {
            char infini = 'x'; //Caractère UNICODE de l'infini
            for (int i = 0; i < costMatrix.getCostM().GetLength(0); i++)
            {
                for (int j = 0; j < costMatrix.getCostM().GetLength(1); j++)
                {
                    if (costMatrix.getCostM()[i, j] != null)
                    {
                        if (j == 0)
                            Console.Write(costMatrix.getCostM()[i, j] + " | ");
                        else if ((int)costMatrix.getCostM()[i, j] != int.MaxValue)
                            Console.Write(costMatrix.getCostM()[i, j] + " | ");
                        else
                            Console.Write(infini + " | ");
                    }
                }
                Console.WriteLine();
            }
            for (int i = 0; i < costMatrix.getCalcM().GetLength(0); i++)
            {
                for (int j = 0; j < costMatrix.getCalcM().GetLength(1); j++)
                {
                    if((int)costMatrix.getCalcM()[i, j] != int.MaxValue)
                        Console.Write(costMatrix.getCalcM()[i, j] + " | ");
                    else
                        Console.Write(infini + " | ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void updateMatrix()
        {
            this.costMatrix.generateMatrix(this);
        }

        /// <summary>
        /// Graph's methods
        /// </summary>
        /// 
    
    }
}
