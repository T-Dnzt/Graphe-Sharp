using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using DLLgraphe.Classes;

namespace DLLgraphe.ExportImport
{
    public class SaveManager     
    {

        private BinaryFormatter bf;
        private FileStream fs;

        public SaveManager()
        {
            bf = new BinaryFormatter();
        }

        public void saveGraph(Graph g)
        {
            fs = new FileStream("datas\\grapheSauve.lol", FileMode.Create);
           
            bf.Serialize(fs, g);
            fs.Close();
        }

        public Graph loadGraph(String fichier)
        {
            fs = new FileStream(fichier, FileMode.Open);

            Graph g = (Graph)bf.Deserialize(fs);
            fs.Close();
            return g;
        }
    }
}

