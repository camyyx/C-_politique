using System;
using System.IO;

namespace Politique
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Membre UnCandidat = new Membre("Donald");
            Membre UnautreCandidat = new Membre();
            Membre UndernierCandidat = new Membre();
            UnautreCandidat.SetName("Hilary");
            Console.WriteLine("Le second candidat est :" + UnautreCandidat.GetName());
            Console.WriteLine("Le premier candidat est :" + UnCandidat.GetName());
            Console.WriteLine("Le dernier cadidat est :" + UndernierCandidat.GetName());

            Parti LePartiRepublicain = new Parti("Républicain");
            Parti LePartiDemocrate = new Parti("Démocrate");
            UnCandidat.SetLeParti(LePartiRepublicain);
            UnautreCandidat.SetLeParti(LePartiDemocrate);
            UndernierCandidat.SetLeParti(LePartiDemocrate);
            Console.WriteLine("Le(s) membre(s) du parti démocrate sont :" + LePartiDemocrate.GiveLesMembres());
            Console.WriteLine("Le(s) membre(s) du parti Républicain sont :" + LePartiRepublicain.GiveLesMembres());
            //using (StreamWriter writer = new StreamWriter("/home/camelia/tests/log.txt", true)){
            //    writer.WriteLine("Hello World!");
            //}
            ModeleMetier modele = new ModeleMetier();
            modele.AddMembre(UnCandidat);
            modele.AddMembre(UnautreCandidat);
            modele.AddMembre(UndernierCandidat);
            modele.AddParti(LePartiDemocrate);
            modele.AddParti(LePartiRepublicain);
            //string path = "/home/camelia/tests/log.txt";
            //int lastindex = path.LastIndexOf("/");
            //string path1 = path.Remove(lastindex);
            //Console.WriteLine(path);
            //Console.WriteLine(path1);
            modele.Enregistrer("/home/camelia/tests/log.txt","json");
        }
    }
}
