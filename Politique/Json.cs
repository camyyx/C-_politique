using System.Collections.Generic;
using System.IO;
   
namespace Politique
{
    internal static class Json
    {
        internal static void Enregistrer(string path, Dictionary<string, Dictionary<string, string>> lists)
        {
            Dictionary<string, Dictionary<string, string>>.Enumerator listsEnum = lists.GetEnumerator();
            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine("{");
                for (int i = 0; i < lists.Count ; i++)
                {
                    listsEnum.MoveNext(); 
                    writer.WriteLine("\"" + listsEnum.Current.Key + "\" : {");
                    Dictionary<string, string>.Enumerator listEnum = listsEnum.Current.Value.GetEnumerator();
                    for (int j = 0; j < listsEnum.Current.Value.Count; j++)
                    {
                        listEnum.MoveNext();
                        if (j != listsEnum.Current.Value.Count -1){
                            writer.WriteLine("\"" + listEnum.Current.Key + "\" : \"" + listEnum.Current.Value + "\",");
                        }else{
                            writer.WriteLine("\"" + listEnum.Current.Key + "\" : \"" + listEnum.Current.Value + "\"");
                        }
                    }
                    if (i == lists.Count - 1)
                    {
                        writer.WriteLine("}");
                    }
                    else
                    {
                        writer.WriteLine("},");
                    }
                }
                writer.WriteLine("}");
            }
        }
    }
}