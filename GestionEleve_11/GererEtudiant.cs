
using GestionEleve_11.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleve_11
{
    class GererEtudiant
    {
        linqtpEntities myEntity { get; set; }
        public GererEtudiant()
        {
            myEntity = new linqtpEntities();
        }
        public  void AjouterEtudiant(eleves e)
        {
            myEntity.eleves.Add(e);
            myEntity.SaveChanges();
        }

        public bool EtudiantExiste(string code)
        {
            return myEntity.eleves.Any(a => a.codeElev == code);
          
        }
        public  void SupprimerEtudiant(string code)
        {
            var query = from e in myEntity.eleves
                        where e.codeElev == code
                        select e;
            eleves elevesup = query.FirstOrDefault<eleves>();
            myEntity.eleves.Remove(elevesup);
            myEntity.SaveChanges();
              
        }
        public List<eleves> ListerTtEtudiant()
         {
            return myEntity.eleves.ToList<eleves>();
         }

        public eleves RechercherUnEtudiant(string code)
        {
            var query = from e in myEntity.eleves
                        where e.codeElev == code
                        select e;

            return query.FirstOrDefault();
        }
    /*    public static Etudiant RechercheE(string code)
        {
            using (MySqlConnection cnx = gestionConnection.getConnection())
            {
         
                Etudiant E = new Etudiant();
                // the state of my connection was closed sometimes so i added this line
                if (cnx.State == System.Data.ConnectionState.Closed)
                {
                    cnx.Open();
                }
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select * from eleves where codeElev='" + code + "';";
                
                cmd.Connection = cnx;
                Console.WriteLine(cnx.State);
                if (cnx.State == System.Data.ConnectionState.Closed)
                {
                    cnx.Open();
                }
                MySqlDataReader rd = cmd.ExecuteReader();
                E.Code = code;
                while (rd.Read())
                {
                    E.Nom = rd[1].ToString();
                    E.Prenom = rd[2].ToString();
                    E.Niveau = rd[3].ToString();
                    E.Code_Fil = rd[4].ToString();
                }
 

                return E;
            }
        }*/
        public  List<eleves> RechercheE(eleves Etu)
        {
            var query = from e in myEntity.eleves
                        where e.codeElev.Contains(Etu.codeElev) && e.nom.Contains(Etu.nom)
                        && e.prenom.Contains(Etu.prenom) && e.code_Fil.Contains(Etu.code_Fil)
                        && e.niveau.Contains(Etu.niveau)
                        select e;

           return query.ToList<eleves>();
          
        }

        public  void UpdateE(eleves e)
        {
            var eleveToUpdate = from elv in myEntity.eleves
                            where elv.codeElev == e.codeElev
                            select elv;

            eleveToUpdate.FirstOrDefault().code_Fil = e.code_Fil;
            eleveToUpdate.FirstOrDefault().nom = e.nom;
            eleveToUpdate.FirstOrDefault().prenom = e.prenom;
            eleveToUpdate.FirstOrDefault().niveau = e.niveau;

            myEntity.SaveChanges();

        }

        public List<eleves> RechercheParFilière(string filière)
        {
            List<eleves> Listeleves = myEntity.eleves.Where(e => e.code_Fil == filière).ToList<eleves>();

            return Listeleves;
           
        }
    }
}
