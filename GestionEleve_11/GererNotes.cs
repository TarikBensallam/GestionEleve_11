using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace GestionEleve_11
{
    class GererNotes
    {
        GererNotes()
        {

        }
        public static void AjouterNote(Note N)
        {
            using (MySqlConnection cnx = gestionConnection.getConnection())
            {

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "insert into notes values('" + N.CodeEl + "','" + N.CodeMat + "','" +
                    "+"+N.NoteE+"');";

                cmd.Connection = cnx;
                Console.WriteLine(cnx.State);
                if (cnx.State == System.Data.ConnectionState.Closed)
                {
                    cnx.Open();
                }

                cmd.ExecuteNonQuery();
            }

        }
        public static void SupprimerNote(Note N)
        {

            using (MySqlConnection cnx = gestionConnection.getConnection())
            {
                // the reason why i added using () is bc my connection can be already in use exception happened

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "delete from notes where codeElev='" + N.CodeEl + "' and codeMat ='" +
                    N.CodeMat +"';";

                cmd.Connection = cnx;
                // the state of my connection was closed sometimes so i added this line
                if (cnx.State == System.Data.ConnectionState.Closed)
                {
                    cnx.Open();
                }
                cmd.ExecuteNonQuery();
            }


        }
        public static MySqlDataAdapter ListerNotes(string codeElev)
        {
            using (MySqlConnection cnx = gestionConnection.getConnection())
            {
                // the state of my connection was closed sometimes so i added this line
                if (cnx.State == System.Data.ConnectionState.Closed)
                {
                    cnx.Open();
                }
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("select * from notes where codeElev ='" +
                   codeElev+ "' ;", cnx);
                return sqlDa;
            }

        }
        public static void UpdateN(Note N)
        {
            using (MySqlConnection cnx = gestionConnection.getConnection())
            {

                // the state of my connection was closed sometimes so i added this line
                if (cnx.State == System.Data.ConnectionState.Closed)
                {
                    cnx.Open();
                }
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "update notes set note='" + N.NoteE + "' where codeElev='" + N.CodeEl + "'" +
                    " AND codeMat='"+N.CodeMat+"';";

                cmd.Connection = cnx;
                Console.WriteLine(cnx.State);
                if (cnx.State == System.Data.ConnectionState.Closed)
                {
                    cnx.Open();
                }
                cmd.ExecuteNonQuery();

            }
        }
        public static Boolean NoteExiste(Note N) 
        {
            using (MySqlConnection cnx = gestionConnection.getConnection())
            {
                // the reason why i added using () is bc my connection can be already in use exception happened

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "select * from notes where codeElev='" + N.CodeEl + "' and codeMat ='" +
                    N.CodeMat + "';";

                cmd.Connection = cnx;
                // the state of my connection was closed sometimes so i added this line
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
        public static MySqlDataAdapter ListerUneNote(Note N)
        {
            using (MySqlConnection cnx = gestionConnection.getConnection())
            {
                // the state of my connection was closed sometimes so i added this line
                if (cnx.State == System.Data.ConnectionState.Closed)
                {
                    cnx.Open();
                }
                MySqlDataAdapter sqlDa = new MySqlDataAdapter("select * from notes where codeElev ='" +
                   N.CodeEl + "' and codeMat ='"+N.CodeMat+"' ;", cnx);
                return sqlDa;
            }

        }
    }
}
