using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DLLgraphe.Classes
{
    [Serializable]
    public class Matrix
    {
        private Object[,] costMatrix; //Matrice de cout avec le nom des sommets
        private int[,] calcMatrix; //Matrice de cout sans le nom des sommets, + pratique pour les calcules. OBJECT permet de mettre des valeurs null.

        public Matrix()
        {
            this.costMatrix = new Object[0, 0];
            this.calcMatrix = new int[0, 0];
        }
        
        public Matrix(Graph g)//Création de la matrice à partir d'un graphe
        {
            generateMatrix(g);
            refreshCalcM();
        }
        public Matrix(Object[,] m)//Création de la matrice à partir d'une matrice existante
        {
            this.costMatrix = m;
            refreshCalcM();
        }

        public void refreshCalcM() //Actualise la matrice de calcules
        {
            int[,] tempM = new int[costMatrix.GetLength(0), costMatrix.GetLength(1) - 1];
            for (int i = 0; i < costMatrix.GetLength(0); i++)
            {
                for (int j = 1; j < costMatrix.GetLength(1); j++)
                {
                    if (costMatrix[i, j] != null)
                        tempM[i, j - 1] = (int) costMatrix[i, j];
                }  
            }
            this.calcMatrix = tempM;
        }


        public void generateMatrix(Graph g)
        {
            int dim = g.getNodeList().Count();
            Object[,] matrixC = new Object[dim, dim + 1]; //+1 <=> colonne ajoutée pour les noms

            //On ajoute les noms de noeuds à la matrice
            for (int i = 0; i < dim; i++)
                matrixC[i, 0] = g.getNodeAt(i).getName();

            //On remplit les cases connues
            foreach (Node n in g.getNodeList())
            {
                foreach (Arc a in n.getEgressArc())
                {
                    int x = a.getOrigin().getIndex();
                    int y = a.getEdge().getIndex();
                    setValueAt(matrixC, a.getCost(), x, y+1);
                }
            }
            //On remplie les cases inconnues 
            for (int i = 0; i < dim; i++)
            {
                for (int j = 1; j < dim + 1; j++)
                {
                   if(matrixC[i, j]==null)
                   {
                       if (i + 1 == j)
                           matrixC[i, j] = 0;
                       else
                           matrixC[i, j] = int.MaxValue;  
                   }
                }
            }
            this.costMatrix = matrixC;
            refreshCalcM();
        }

     /// <summary>
     /// Supprime un noeud
     /// </summary>
     /// <param name="nIndex"></param>
        public void removeNode(int nIndex) 
        {
            int nbRow = costMatrix.GetLength(0);
            int nbCol = costMatrix.GetLength(1);

            if (nIndex < 0 || nIndex >= nbRow)   
                return; //pas valide

            Object[,] matrixC = new Object[nbRow-1, nbCol-1];  //nouvelle matrice
            int i2 = 0, j2 = 0;
            for (int i = 0; i < nbRow; i++)
            {
                j2 = 0;
                if (i != nIndex)
                {
                    for (int j = 0; j < nbCol; j++)
                    {
                        if (j != nIndex + 1)
                        {
                            matrixC[i2, j2] = costMatrix[i, j];
                            j2++;
                        }
                    }
                    i2++;
                }
            }
            this.costMatrix=matrixC;
            refreshCalcM();
        }

        public Object[,] getCostM()
        {
            return this.costMatrix;
        }

        public int[,] getCalcM()
        {
            return this.calcMatrix;
        }

        public void setValueAt(int val, int row, int col)
        {
            if (row < 0 || row >= costMatrix.GetLength(0))
            {
                Console.WriteLine("Row out of bounds");
                return;  //invalide
            }
            if (col < 0 || col + 1 >= costMatrix.GetLength(1))
            {
                Console.WriteLine("Col out of bounds");
                return;  //invalide
            }

            costMatrix[row, col + 1] = val;
            calcMatrix[row, col] = val;
        }

        public void setValueAt(Object[,] mat, int val, int row, int col)
        {
            if (row < 0 || row >= mat.GetLength(0))
            {
                Console.WriteLine("Row out of bounds");
                return;  //invalide
            }
            if (col < 0 || col >= mat.GetLength(1))
            {
                Console.WriteLine("Col out of boundslol");
                return;  //invalide
            }

            mat[row, col] = val;
        }

        public int getValAt(int row, int col)
        {
            if (row < 0 || row >= calcMatrix.GetLength(0)) 
                return 0;  //pas valide
            if (col < 0 || col >= calcMatrix.GetLength(0)) 
                return 0;  //pas valide

            return (int)calcMatrix[row,col];  //valeur dans la matrice
        }
    }
}
