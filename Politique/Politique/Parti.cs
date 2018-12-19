using System.Collections.Generic;

namespace Politique
{
    internal class Parti
    {
        private static int number;
        private int id;
        public int Id{
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        private string name;
        public string Name    
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        private List<Membre> membres;
        private Membre chef;
        public Membre Chef{
            get
            {
                return chef;
            }
            set
            {
                chef = value;
            }
        }

        public Parti(string name){
            this.name = name;
            this.membres = new List<Membre>();
            this.chef = null;
            this.id = number++;
        }
        public Parti(){
            this.name = "inconnu";
            this.membres = new List<Membre>();
            this.chef = null;
            this.id = -1;
        }

        public Parti(string name, int id)
        {
            this.name = name;
            this.membres = new List<Membre>();
            this.chef = null;
            this.id = id;
        }
        public string GetName(){
            return this.name;
        }
        public void AddMembre(Membre membre){
            if (chef == null){
                chef = membre;
            }
            membres.Add(membre);
        }
        public string GiveLesMembres(){
            string s = "";
            foreach(Membre elt in membres){
                s = s + elt.Name + "\n"; 
            }
            return s;
        }

        public List<Membre> GetMembres(){
            return membres;
        }
        public string Tostring(){
            return (id.ToString() + " " + name + " " + GiveLesMembres());
        }
    }

}