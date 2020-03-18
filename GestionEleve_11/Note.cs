using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleve_11
{
    class Note
    {
        string codeEl;
        string codeMat;
        double noteE;

        public Note(string code,string codeM,double noteE)
        {
            this.codeEl = code;
            this.codeMat = codeM;
            this.noteE = noteE;
        }
        public string CodeEl
        {
            get { return this.codeEl; }
            set { this.codeEl = value; }
        }
        public string CodeMat
        {
            get { return this.codeMat; }
            set { this.codeMat = value; }
        }
        public double NoteE
        {
            get { return this.noteE; }
            set { this.noteE = value; }
        }
    }
}
