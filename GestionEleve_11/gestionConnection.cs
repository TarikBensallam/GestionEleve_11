using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleve_11
{
    class gestionConnection
    {
        static MySqlConnection cnx;

        private gestionConnection()
        {
           
            cnx = new MySqlConnection(@"server=localhost;database=biblio;userid=root;password=");
            cnx.Open();
       
        }
        public static MySqlConnection getConnection()
        {
            if (cnx == null)
               new gestionConnection();
            return cnx;
        }
    }
}
