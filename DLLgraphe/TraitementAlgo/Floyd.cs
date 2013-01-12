using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DLLgraphe.Classes;

namespace DLLgraphe.TraitementAlgo
{
    public class Floyd
    {
        int[,] Matrix;
        int[,] floydMatrix;
        int n;
        Graph g;

        public Floyd(Graph graph)
        {
            //On récupère la matrice du graphe
            this.Matrix = graph.getMatrix().getCalcM();
            //On récupère la longueur des lignes de la matrice
            n = Matrix.GetLength(0);
            //Création d'un tableau d'entier qui contiendra les résultats de l'agorithme de Floyd
            floydMatrix = new int[n, n];

            execute(graph);
        }
        //Fonctionnel
        public int[,] execute(Graph graph)
        {
            //On copie les éléments de la matrice du graphe dans la matrice floydMatrix
            for (int g = 0; g < n; g++)
            {
                for (int o = 0; o < n; o++)
                {
                    floydMatrix[g, o] = (int)Matrix[g, o];
                }
            }

            //Algorithme de Floyd
            for (int a = 0; a < n; ++a)
            {
                for (int z = 0; z < n; ++z)
                {
                    for (int e = 0; e < n; ++e)
                    {
                        if (floydMatrix[z, a] != int.MaxValue && floydMatrix[a, e] != int.MaxValue)
                        {
                            int d = floydMatrix[z, a] + floydMatrix[a, e];

                            if (floydMatrix[z, e] > d)
                                floydMatrix[z, e] = d;
                        }
                    }
                }
            }

            //On copie les éléments de la matrice floydMatrix vers la matrice Matrix, pour l'homogénéité des types
            for (int g = 0; g < n; g++)
            {
                for (int o = 0; o < n; o++)
                {
                    Matrix[g, o] = floydMatrix[g, o];
                }
            }
            return Matrix;
        }

        public void display()
        {
            Console.WriteLine("Floyd : " + Environment.NewLine);
            for (int x = 0; x < Matrix.GetLength(0); x++)
            {
                for (int w = 0; w < Matrix.GetLength(1); w++)
                {
                    if (floydMatrix[x, w] == int.MaxValue)
                    {
                        Console.Write(" inf | ");
                    }
                    else
                    {
                        Console.Write(" " + floydMatrix[x, w] + " | ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine(Environment.NewLine);
        }
    }
}
