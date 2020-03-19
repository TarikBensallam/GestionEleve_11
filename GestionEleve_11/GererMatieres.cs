using GestionEleve_11.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Linq.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleve_11
{
    class GererMatieres
    {
        linqtpEntities myEntity { get; set; }
        public GererMatieres()
        {
            myEntity = new linqtpEntities();

        }
        public  List<matieres> RechercheMs(eleves Etu)
        {
            var query = from e in myEntity.matieres
                        where  e.code_Fil== Etu.code_Fil && e.niveau== Etu.niveau
                        select e;

            return query.ToList<matieres>();
          
        }
    }
}
