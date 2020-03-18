using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleve_11
{
    class Matière
    {
        string codeMat;
        string designation;
        string niveau;
        string semestre;
        string code_Fil;

        public Matière(string codeMat, string designation, string niveau, string semestre, string code_Fil)
        {
            this.CodeMat = codeMat;
            this.Designation = designation;
            this.Niveau = niveau;
            this.Semestre = semestre;
            this.Code_Fil = code_Fil;
        }

        public string CodeMat { get => codeMat; set => codeMat = value; }
        public string Designation { get => designation; set => designation = value; }
        public string Niveau { get => niveau; set => niveau = value; }
        public string Semestre { get => semestre; set => semestre = value; }
        public string Code_Fil { get => code_Fil; set => code_Fil = value; }
    }
}
