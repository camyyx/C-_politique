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
    }
}