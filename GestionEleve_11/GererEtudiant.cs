using Dao.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleve_11
{
    class GererEtudiant
    {
        linqtpEntities myEntity { get; set; }
        GererEtudiant()
        {
            myEntity = new linqtpEntities();
        }
        public  void AjouterEtudiant(eleves e)
        {
            myEntity.eleves.Add(e);
            //using (MySqlConnection cnx = gestionConnection.getConnection())
            //{
                
            //    MySqlCommand cmd = new MySqlCommand();
            //    cmd.CommandText = "insert into eleves values('" + e.Code + "','" + e.Nom + "','" + e.Prenom + "','" + e.Niveau + "','" + e.Code_Fil + "');";

            //    cmd.Connection = cnx;
            //    Console.WriteLine(cnx.State);
            //    if (cnx.State == System.Data.ConnectionState.Closed)
            //    {
            //        cnx.Open();
            //    }
                
            //    cmd.ExecuteNonQuery();
            //}
               
        }

        public static bool EtudiantExiste(string code)
        {
            using (MySqlConnection cnx = gestionConnection.getConnection())
            {
                
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select * from eleves where codeElev='" + code + "';";

                cmd.Connection = cnx;
                if (cnx.State == System.Data.ConnectionState.Closed)
                {
                    cnx.Open();
                }
                MySqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    return true;
                }
                return false;
            }

             
        }
        public static void SupprimerEtudiant(string code)
        {

            using (MySqlConnection cnx = gestionConnection.getConnection())
            {
                // the reason why i added using () is bc my connection can be already in use exception happened
                
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "delete from eleves where codeElev='" + code + "';";

                cmd.Connection = cnx;
                // the state of my connection was closed sometimes so i added this line
                if (cnx.State == System.Data.ConnectionState.Closed)
                {
                    cnx.Open();
                }
                cmd.ExecuteNonQuery();
            }

              
        }
            public static MySqlDataAdapter ListerTtEtudiant()
            {
                using (MySqlConnection cnx = gestionConnection.getConnection())
                {
                    // the state of my connection was closed sometimes so i added this line
                    if (cnx.State == System.Data.ConnectionState.Closed)
                    {
                        cnx.Open();
                    }
                    MySqlDataAdapter sqlDa = new MySqlDataAdapter("select * from eleves;", cnx);
                    return sqlDa;
                }

                
            }

        public static MySqlDataAdapter RechercherUnEtudiant(string code)
        {
            using (MySqlConnection cnx = gestionConnection.getConnection())
            {
                // the state of my connection was closed sometimes so i added this line
                if (cnx.State == System.Data.ConnectionState.Closed)
                {
                    cnx.Open();
                }

                MySqlDataAdapter sqlDa = new MySqlDataAdapter("select * from eleves where codeElev='" + code + "';", cnx);

                return sqlDa;
            }
        }
        public static Etudiant RechercheE(string code)
        {
            using (MySqlConnection cnx = gestionConnection.getConnection())
            {
                Console.WriteLine("wssalt l hna 1 ");
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
                Console.WriteLine("wssalt l hna 2 ");

                return E;
            }
        }
        public static MySqlDataAdapter RechercheE(Etudiant Etu)
        {
            using (MySqlConnection cnx = gestionConnection.getConnection())
            {
                string codE = Etu.Code;
               string NomE = Etu.Nom;
              //  Etudiant E = new Etudiant();
                // the state of my connection was closed sometimes so i added this line
                if (cnx.State == System.Data.ConnectionState.Closed)
                {
                    cnx.Open();
                }
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select * from eleves where codeElev like '%" + Etu.Code + "%'" +
                    " and nom like '%" + Etu.Nom +"%' and prenom like '%" +Etu.Prenom+
                    "%' and code_Fil like '%"+Etu.Code_Fil+"%' and niveau like '%"+Etu.Niveau+"%'; ";

                cmd.Connection = cnx;
                Console.WriteLine(cnx.State);
                if (cnx.State == System.Data.ConnectionState.Closed)
                {
                    cnx.Open();
                }
                MySqlDataAdapter dtadapter = new MySqlDataAdapter(cmd.CommandText,cnx);
                //E.Code = code;
                //while (rd.Read())
                //{
                //    E.Nom = rd[1].ToString();
                //    E.Prenom = rd[2].ToString();
                //    E.Niveau = rd[3].ToString();
                //    E.Code_Fil = rd[4].ToString();
                //}


                return dtadapter;
            }
        }

        public static void UpdateE(Etudiant e)
        {
            using (MySqlConnection cnx = gestionConnection.getConnection())
            {
                
                // the state of my connection was closed sometimes so i added this line
                if (cnx.State == System.Data.ConnectionState.Closed)
                {
                    cnx.Open();
                }
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "update eleves set nom='"+e.Nom+ "',prenom='" + e.Prenom + "',niveau='" + e.Niveau + "'" +
                    ",code_Fil='" + e.Code_Fil + "' where codeElev='" + e.Code + "';";

                cmd.Connection = cnx;
                Console.WriteLine(cnx.State);
                if (cnx.State == System.Data.ConnectionState.Closed)
                {
                    cnx.Open();
                }
                cmd.ExecuteNonQuery();

            }
        }

        public static MySqlDataAdapter RechercheParFilière(string filière)
        {
            using (MySqlConnection cnx = gestionConnection.getConnection())
            {
                // the state of my connection was closed sometimes so i added this line
                if (cnx.State == System.Data.ConnectionState.Closed)
                {
                    cnx.Open();
                }

                MySqlDataAdapter sqlDa = new MySqlDataAdapter("select * from eleves where code_Fil='" + filière + "'" +
                    " ;", cnx);

                return sqlDa;
            }
        }
    }
}
