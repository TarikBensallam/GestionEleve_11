using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleve_11
{
    class GererMatieres
    {

        public static MySqlDataAdapter RechercheMs(Etudiant Etu)
        {
            using (MySqlConnection cnx = gestionConnection.getConnection())
            {
                
                // the state of my connection was closed sometimes so i added this line
                if (cnx.State == System.Data.ConnectionState.Closed)
                {
                    cnx.Open();
                }
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select * from matieres where niveau like '%" + Etu.Niveau + "%'" +
                    " and code_Fil like '%" + Etu.Code_Fil + "%' ; ";

                cmd.Connection = cnx;
                Console.WriteLine(cnx.State);
                if (cnx.State == System.Data.ConnectionState.Closed)
                {
                    cnx.Open();
                }
                MySqlDataAdapter dtadapter = new MySqlDataAdapter(cmd.CommandText, cnx);

                return dtadapter;
            }
        }
    }
}
