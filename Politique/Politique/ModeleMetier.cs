﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Politique
{
    internal class ModeleMetier
    {
        private List<Membre> membres;
        private List<Parti> partis;

        public ModeleMetier(){
            membres = new List<Membre>();
            partis = new List<Parti>();
        }
        public void AddMembre(Membre m){
            membres.Add(m);
        }
        public void AddParti(Parti p){
            partis.Add(p);
        }
        public void Enregistrer(string path, string format){
            switch (format){
                case "csv":
                    EnregistrerCSV(path);
                    break;
                case "xml":
                    EnregistrerXML(path);
                    break;
                case "json":
                    EnregistrerJSON(path);
                    break;
                default:
                    throw new Exception("Format non reconnu");
            }
        }
       

        public void Enregistrer(string path, string format, char eltbr, char linebr){
            List<List<string>> lists = new List<List<string>>();
            if (format == "custom"){
                string pathMembres, pathPartis;
                pathMembres = TrimPath(path);
                pathPartis = TrimPath(path);
                pathPartis = pathPartis + "/partis.cus";
                pathMembres = pathMembres + "/membres.cus";
                using (StreamWriter writer = new StreamWriter(path, false))
                {
                    writer.WriteLine(pathMembres);
                    writer.WriteLine(pathPartis);
                }
                List<string> list = new List<string>();
                foreach (Membre elt in membres)
                {
                    list.Add(elt.Id.ToString());
                    list.Add(elt.Name);
                    list.Add(elt.GetPartiId().ToString());
                    lists.Add(list);
                    list.Clear();
                }
                Cus.Enregistrer(path, eltbr, linebr, lists);
                lists.Clear();

                foreach (Parti elt in partis)
                {
                    list.Add(elt.Id.ToString());
                    list.Add(elt.Name);
                    list.Add(elt.Chef.Id.ToString());
                    foreach (Membre m in elt.GetMembres())
                    {
                        list.Add(m.Id.ToString());
                    }
                    lists.Add(list);
                    list.Clear();
                }
                Cus.Enregistrer(path, eltbr, linebr, lists);
            }else{
                throw new Exception("Format non reconnu");
            }
        }

        private void EnregistrerJSON(string path)
        {
            string pathMembres, pathPartis;
            pathMembres = TrimPath(path) + "/membres.json";
            pathPartis = TrimPath(path) + "/partis.json";
            List<string> paths = new List<string>
            {
                pathPartis,
                pathMembres
            };
            StringWriter.write(path, false, paths);
            Dictionary<string, Dictionary<string, string>> lists = new Dictionary<string, Dictionary<string, string>>();
            foreach (Membre elt in membres)
            {
                Dictionary<string, string> list = new Dictionary<string, string>
                {
                    { "id", elt.Id.ToString() },
                    { "name", elt.Name },
                    {"prenom", elt.Prenom},
                    { "parti", elt.GetPartiId().ToString() }
                };
                lists.Add("membre" + elt.Id.ToString(), list);
            }
            Json.Enregistrer(pathMembres, lists);
            lists.Clear();
            foreach (Parti elt in partis)
            {
                Dictionary<string, string> list = new Dictionary<string, string>
                {
                    { "id", elt.Id.ToString() },
                    { "name", elt.Name },
                    { "chef", elt.Chef.Id.ToString() }
                };
                foreach (Membre m in elt.GetMembres())
                {
                    list.Add("membre" + m.Id.ToString(), m.Id.ToString());
                }
                lists.Add("parti" + elt.Id.ToString(), list);
            }
            Json.Enregistrer(pathPartis, lists);
        }

        void EnregistrerXML(string path)
        {
            string pathMembres, pathPartis;
            pathMembres = TrimPath(path)+ "/membres.xml";
            pathPartis = TrimPath(path) + "/partis.xml";
            List<string> paths = new List<string>
            {
                pathPartis,
                pathMembres
            };
            StringWriter.write(path,false,paths);
            Dictionary<string, Dictionary<string, string>> lists = new Dictionary<string, Dictionary<string, string>>();
            foreach (Membre elt in membres)
            {
                Dictionary<string, string> list = new Dictionary<string, string>
                {
                    { "id", elt.Id.ToString() },
                    { "name", elt.Name },
                    { "parti", elt.GetPartiId().ToString() }
                };
                lists.Add("membre" + elt.Id.ToString(), list);
            }

            XML.Enregistrer(pathMembres, lists);
            lists.Clear();
            foreach (Parti elt in partis)
            {
                Dictionary<string, string> list = new Dictionary<string, string>
                {
                    { "id", elt.Id.ToString() },
                    { "name", elt.Name },
                    { "chef", elt.Chef.Id.ToString() }
                };
                foreach (Membre m in elt.GetMembres())
                {
                    list.Add("membre" + m.Id.ToString(), m.Id.ToString());
                }
                lists.Add("parti" + elt.Id.ToString(), list);
            }
            XML.Enregistrer(pathPartis, lists);
        }
        void EnregistrerCSV(string path){
            string pathMembres, pathPartis;
            pathMembres = TrimPath(path) + "/membres.cs";
            pathPartis = TrimPath(path) + "/partis.csv";
            List<string> paths = new List<string>{
                pathMembres,
                pathPartis
            };
            StringWriter.write(path, false, paths);
            List<List<string>> lists = new List<List<string>>();
            foreach (Membre elt in membres)
            {
                List<string> list = new List<string>
                {
                    elt.Id.ToString(),
                    elt.Name,
                    elt.Prenom,
                    elt.GetPartiId().ToString()
                };
                lists.Add(list);
            }
            CSV.enregistrer(pathMembres, lists);
            lists.Clear();
            foreach (Parti elt in partis)
            {
                List<string> list = new List<string>
                {
                    elt.Id.ToString(),
                    elt.Name,
                    elt.Chef.Id.ToString()
                };
                foreach (Membre m in elt.GetMembres()){
                    list.Add(m.Id.ToString());
                }
                lists.Add(list);
            }
            CSV.enregistrer(pathPartis, lists);
        }


        string TrimPath(string path)
        {
            int pos = path.LastIndexOf("/", StringComparison.Ordinal);
            return path.Remove(pos);
        }
    }
    //TODO: sensible casse
    //TODO: var escapedXml = System.Security.SecurityElement.Escape(@"&<>'""’éûÉغ");‎
    //TODO class cherger/enreg
}