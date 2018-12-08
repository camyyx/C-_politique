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

        public Membre(string name){
            this.name = name;
            id = number++;
            parti = null;
        }
        public Membre(string name, int id){
            this.name = name ;
            this.id = id;
        }
        public Membre(){
            name = "inconnu";
            id = number++;
        }


        public int GetPartiId()
        {
            if (parti == null){
                return -1;
            }else{
                return parti.GetId();
            }
        }

    }
}