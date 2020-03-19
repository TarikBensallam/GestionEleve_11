using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionEleve_11.Data;
using MySql.Data.MySqlClient;

namespace GestionEleve_11
{
    class GererNotes
    {
        linqtpEntities myEntity { get; set; }
        public GererNotes()
        {
            myEntity = new linqtpEntities();
        }
        public  void AjouterNote(notes N)
        {
            myEntity.notes.Add(N);
            myEntity.SaveChanges();

        }
        public  void SupprimerNote(notes N)
        {
            var query = from n in myEntity.notes
                        where n.codeElev == N.codeElev && n.codeMat==N.codeMat
                        select n;
           notes  notesup = query.FirstOrDefault<notes>();
            myEntity.notes.Remove(notesup);
            myEntity.SaveChanges();

        }
        public List<notes> ListerNotes(string codeElev)
        {
            var query = from n in myEntity.notes
                        where n.codeElev.Contains(codeElev) 
                        select n;

            return query.ToList<notes>();

        }
        public  void UpdateN(notes N)
        {
            var noteToUpdate = from note in myEntity.notes
                                where note.codeElev == N.codeElev && note.codeMat== N.codeMat
                                select note;

            noteToUpdate.FirstOrDefault().note = N.note;

            myEntity.SaveChanges();
          
        }
        public  Boolean NoteExiste(notes N) 
        {
            return myEntity.notes.Any(a => a.codeElev ==N.codeElev && a.codeMat==N.codeMat);
            
        }
        public  List<notes> ListerUneNote(notes N)
        {
            var query = from n in myEntity.notes
                        where n.codeElev == N.codeElev && n.codeMat==N.codeMat
                        select n;
            
            return query.ToList<notes>();
           

        }
    }
}
