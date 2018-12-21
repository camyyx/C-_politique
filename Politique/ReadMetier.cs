using System;
using System.IO;
using System.Collections.Generic;

namespace Politique
{
    public class ReadMetier

    {
        private List<Parti> lespartis;
        private List<Membre> lesmembres;

        public void Getmembres()
        {
            foreach (Membre m in lesmembres)
            {
                Console.WriteLine(m.Tostring());
            }
        }
        public void Getpartis(){
            foreach (Parti p in lespartis)
            {
                Console.WriteLine(p.Tostring());
            }
        }



        public ReadMetier(){
            lespartis = new List<Parti>();
            lesmembres = new List<Membre>();
        }

        public void Read(string path, string format)
        {
            string pathMembers = "";
            string pathPartis = "";
            using (StreamReader reader = File.OpenText(path))
            {
                pathMembers = reader.ReadLine();
                pathPartis = reader.ReadLine();
            }
            switch (format)
            {
                case "csv":
                    ReadCSV(pathMembers, pathPartis);
                    break;
                //case "xml":
                //    ChargerXML(pathMembers, pathPartis);
                //    break;
                //case "json":
                    //ChargerJSON(pathMembers, pathPartis);
                    //break;
                default:
                    throw new Exception("Format non reconnu");
            }
        }

        //static void ChargerJSON(string pathMembers, string pathPartis)
        //{
        //    throw new NotImplementedException();
        //}

        //static void ChargerXML(string pathMembers, string pathPartis)
        //{
        //    throw new NotImplementedException();
        //}

        public void ReadCSV(string pathMembers, string pathPartis)
        {
            
            List<List<string>> listsMembres = CSV.Read(pathMembers);
            Dictionary<Membre, int> membres = new Dictionary<Membre, int>();
            foreach (List<string> listMembre in listsMembres){
                int parti;
                Membre membre = new Membre();
                for (int i = 0; i < listMembre.Count; i++){
                    switch (i)
                    {
                        case 0:
                            membre.Id = (int.Parse(listMembre[i]));
                            break;
                        case 1:
                            membre.Name = (listMembre[i]) ;
                            break;
                        case 2:
                            parti = int.Parse(listMembre[i]);
                            membres.Add(membre, parti);
                            break;
                        default:
                            throw new Exception("Fichier non conforme " + "ligne : " + listsMembres.IndexOf(listMembre).ToString() + ",  " + i);
                    }
                }
            }

            List<List<string>> listspartis= CSV.Read(pathPartis);
            foreach (List<string> list in listspartis)
            {
                Parti parti  = new Parti();
                int chef = -1;
                Dictionary<Membre, int>.Enumerator membre = membres.GetEnumerator();
                for (int i = 0; i < list.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            parti.Id = (int.Parse(list[i]));
                            break;
                        case 1:
                            parti.Name = (list[i]);
                            break;
                        case 2:
                            chef = int.Parse(list[i]);
                            membre = membres.GetEnumerator();
                            membre.MoveNext();
                            while(membre.MoveNext()){
                                if (membre.Current.Key.Id == chef && membre.Current.Value == parti.Id){
                                    parti.Chef = membre.Current.Key;
                                    break;
                                }
                            }
                            break;
                        case int n when (n > 2 && n < list.Count):
                            membre = membres.GetEnumerator();
                            membre.MoveNext();
                            while (membre.MoveNext()){
                                if(membre.Current.Key.Id == int.Parse(list[i]) && membre.Current.Value == parti.Id){
                                    membre.Current.Key.Parti = parti;
                                    lesmembres.Add(membre.Current.Key);
                                    break;
                                }
                            }
                            lespartis.Add(parti);
                            break;
                        default:
                            throw new Exception("Fichier non conforme " + "ligne : " + listspartis.IndexOf(list).ToString() + ",  " + i);
                    }
                }
            }
        }
    }
}
