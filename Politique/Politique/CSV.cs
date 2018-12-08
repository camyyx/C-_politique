using System.Collections.Generic;
using System.IO;

namespace Politique
{
    internal class CSV
    {
        private static string csvligne(List<string> list)
        {
            string s = "";
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count - 1; i++)
                {
                    s = s + (list[i] + ",");
                }
                s = s + (list[list.Count - 1]);
            }
            return s;
        }

        internal static void enregistrer(string path, List<List<string>> lists){
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                foreach (List<string> list in lists)
                {
                    writer.WriteLine(csvligne(list));
                }

            }
        }
        internal static List<List<string>> Read(string path){
            List<List<string>> lists = new List<List<string>>();
            string line = "";
            using (StreamReader reader = new StreamReader(path)){
                while ((line = reader.ReadLine()) != null)
                {
                    string[] coll = line.Split(new char[] { ',' });
                    List<string> list = new List<string>(coll);
                    lists.Add(list);
                }            
            }
            return lists;
        }
    }
}