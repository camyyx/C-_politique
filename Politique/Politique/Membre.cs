namespace Politique
{
    //TODO: id unique
    internal class Membre
    {
        private static int number;
        private int id;
        public int Id    // the Name property
        {
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
        public string Name    // the Name property
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
        string prenom;
        public string Prenom{
            get{
                return prenom;
            }
            set{
                prenom = value;
            }
        }
        private Parti parti;
        public Parti Parti    // the Name property
        {
            get
            {
                return parti;
            }
            set
            {
                parti = value;
                parti.AddMembre(this);
            }
        }

        public Membre(string name, string prenom){
            this.name = name;
            this.prenom = prenom;
            id = number++;
            parti = null;
        }
        public Membre(string name,string prenom,  int id){
            this.name = name ;
            this.prenom = prenom;
            this.id = id;
        }
        public Membre(){
            name = "inconnu";
            prenom = "inconnu";
            id = number++;
        }


        public int GetPartiId()
        {
            if (parti == null){
                return -1;
            }else{
                return parti.Id;
            }
        }

        public string Tostring(){
            return (id.ToString() + " " + name + " " + GetPartiId().ToString() +"\n");
        }

    }
}