using System;
using System.Collections.Generic;
using System.IO;

namespace Politique
{
    class MainClass
    {
        static void Main(string[] args)
        {
            //Membre UnCandidat = new Membre("Donald");
            //Membre UnautreCandidat = new Membre();
            //Membre UndernierCandidat = new Membre();
            //UnautreCandidat.Name ="Hilary";
            //Console.WriteLine("Le second candidat est :" + UnautreCandidat.Name);
            //Console.WriteLine("Le premier candidat est :" + UnCandidat.Name);
            //Console.WriteLine("Le dernier cadidat est :" + UndernierCandidat.Name);

            //Parti LePartiRepublicain = new Parti("Républicain");
            //Parti LePartiDemocrate = new Parti("Démocrate");
            //UnCandidat.Parti = LePartiRepublicain;
            //UnautreCandidat.Parti = LePartiDemocrate;
            //UndernierCandidat.Parti = LePartiDemocrate;
            //Console.WriteLine("Le(s) membre(s) du parti démocrate sont :" + LePartiDemocrate.GiveLesMembres());
            //Console.WriteLine("Le(s) membre(s) du parti Républicain sont :" + LePartiRepublicain.GiveLesMembres());
            ////using (StreamWriter writer = new StreamWriter("/home/camelia/tests/log.txt", true)){
            ////    writer.WriteLine("Hello World!");
            ////}
            //ModeleMetier modele = new ModeleMetier();
            //modele.AddMembre(UnCandidat);
            //modele.AddMembre(UnautreCandidat);
            //modele.AddMembre(UndernierCandidat);
            //modele.AddParti(LePartiDemocrate);
            //modele.AddParti(LePartiRepublicain);
            ////string path = "/home/camelia/tests/log.txt";
            ////int lastindex = path.LastIndexOf("/");
            ////string path1 = path.Remove(lastindex);
            ////Console.WriteLine(path);
            ////Console.WriteLine(path1);
            //modele.Enregistrer("/home/camelia/tests/log.txt","json");
            //ReadMetier reader = new ReadMetier();
            //reader.ReadCSV("/home/camelia/tests/membres.cvs", "/home/camelia/tests/partis.csv");
            //reader.Getmembres();
            //Console.WriteLine("les partis");
            //reader.Getpartis();
            //Console.WriteLine("les membres");
            //List<List<string>> list = CSV.Read("/home/camelia/tests/membres.cvs");
            //foreach(List<string> l in list){
            //    foreach(string s in l){
            //        Console.WriteLine(s);
            //    }
            //}
            //Console.WriteLine("les partis");
            //list = CSV.Read("/home/camelia/tests/partis.csv");
            //foreach (List<string> l in list)
            //{
            //    foreach (string s in l)
            //    {
            //        Console.WriteLine(s);
            //    }
            //}
            //Console.WriteLine("les membres");
            //List<List<string>> list = Cus.Read("/home/camelia/tests/membres.cus",'|', 'ù');
            //foreach (List<string> l in list)
            //{
            //    foreach (string s in l)
            //    {
            //        Console.WriteLine(s);
            //    }
            //}
            //Console.WriteLine("les partis");
            //list = Cus.Read("/home/camelia/tests/partis.cus", '|', 'ù');
            //foreach (List<string> l in list)
            //{
            //    foreach (string s in l)
            //    {
            //        Console.WriteLine(s);
            //    }
            //}
            XML.Read("/home/camelia/tests/membres.xml");
        }
    }
}
