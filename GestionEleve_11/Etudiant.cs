using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleve_11
{
    public class Etudiant
    {
        string code;
        string nom;
        string prenom;
        private string  code_Fil;
        private string niveau;
        public Etudiant(string code="", string nom="", string prenom="", string niveau="", string codF="") 
        {
            this.code = code;
            this.nom = nom;
            this.prenom = prenom;
            this.niveau = niveau;
            this.code_Fil = codF;
           
        }
        public string Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }
        public string Prenom
        {
            get { return this.prenom; }
            set { this.prenom = value; }
        }

        public string Code
        {
            get { return this.code; }
            set { this.code = value; }
        }

       
        public string Niveau
        {
            get { return this.niveau; }
            set { this.niveau = value; }
        }

        public string Code_Fil
        {
            get { return this.code_Fil; }
            set { this.code_Fil = value; }
        }


        public override string ToString()
        {
            return "Nom etud: " + this.Nom + " " + this.Prenom + " Niveau etud : " + this.Niveau;
        }
    }
}
