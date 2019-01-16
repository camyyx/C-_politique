using System.Collections.Generic;
using System.IO;


namespace Politique
{
    internal class Cus
    {
        internal static void Enregistrer(string path, char eltbr, char linebr, List<List<string>> lists)
        {
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                foreach (List<string> list in lists)
                {
                    writer.WriteLine(CusLine(list, eltbr) + linebr);
                }

            }
        }
        //todo:methodes name
        private static string CusLine(List<string> list, char eltbr)
        {
            string s = "";
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count - 1; i++)
                {
                    s = s + (list[i] + eltbr);
                }
                s = s + (list[list.Count - 1]);
            }
            return s;
        }


        internal static List<List<string>> Read(string path, char brline, char britem)
        {
            List<List<string>> lists = new List<List<string>>();
            string line = "";
            using (StreamReader reader = new StreamReader(path))
            {
                line = reader.ReadToEnd();
                string[] coll = line.Split(new char[] { brline });
                foreach(string s in coll){
                    string[] elts = s.Split(new char[] { britem });
                    List<string> list = new List<string>(elts);
                    lists.Add(list);
                }
            }
            return lists;
        }
    }
}