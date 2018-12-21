using System;
using System.Collections.Generic;
using System.IO;

namespace Politique
{
    internal static class StringWriter
    {
        //TODO: liste de chemins dans un fichier
        internal static void write(string path, Boolean notOver, List<string> list)
        {
            using (StreamWriter writer = new StreamWriter(path, notOver))
            {
                foreach (string elt in list)
                {
                    writer.WriteLine(elt);
                }
            }
        }
    }
}