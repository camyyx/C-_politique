using System.Collections.Generic;
using System.IO;


namespace Politique
{
    internal class Cus
    {
        internal static void Enregistrer(string path, string eltbr, string linebr, List<List<string>> lists)
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
        private static string CusLine(List<string> list, string eltbr)
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


        internal static List<List<string>> Read(string path, string brline, string britem)
        {
            List<List<string>> lists = new List<List<string>>();
            string line = "";
            using (StreamReader reader = new StreamReader(path))
            {
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