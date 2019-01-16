using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Politique
{
    internal static class XML
    {
        internal static void Enregistrer(string path, Dictionary<string, Dictionary<string, string>> lists)
        {
            Dictionary<string, Dictionary<string, string>>.Enumerator listsEnum = lists.GetEnumerator();
            Dictionary<string, string> list;
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine("<? xml version = \"1.0\" encoding = \"ISO - 8859 - 1\" ?>");
                while (listsEnum.MoveNext())
                {
                    writer.WriteLine("<" + listsEnum.Current.Key + ">");
                    list = listsEnum.Current.Value;
                    Dictionary<string, string>.Enumerator listEnum = list.GetEnumerator();
                    while (listEnum.MoveNext())
                    {
                        writer.WriteLine("<" + listEnum.Current.Key + ">" + listEnum.Current.Value + "</" + listEnum.Current.Key + ">");
                    }
                    writer.WriteLine("</" + listsEnum.Current.Key + ">");
                }
            }
        }

        internal static Dictionary<string, Dictionary<string, string>> Read(string path){
            Dictionary<string, Dictionary<string, string>> result = new Dictionary<string, Dictionary<string, string>>();
            using (StreamReader reader = new StreamReader(path))
            {
                string line = reader.ReadLine();
                if (!line.Equals("<? xml version = \"1.0\" encoding = \"ISO - 8859 - 1\" ?>")){
                    Console.WriteLine("c'est caca ligne 1");
                }
                Dictionary<string, string> objects = new Dictionary<string, string>();
                char[] charstotrim = { '<', '>' , '/'};
                line = reader.ReadToEnd();
                int starttag = 0;
                string tag = line.Substring(starttag, line.IndexOf('>')).Trim(charstotrim);
                int end = line.IndexOf("</" + tag) ;
                int startcontent = starttag + tag.Length + 2;
                int endcontent = end - tag.Length - 2;
                string content = line.Substring(startcontent, endcontent);
                string contenttag;
                starttag = content.IndexOf('>');
                contenttag = content.Substring(startcontent - 1, starttag - 1).Trim(charstotrim);
                Console.WriteLine("tag : " + contenttag);


            }
            return result;
        }
    }
}