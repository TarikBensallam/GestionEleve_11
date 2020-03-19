using GestionEleve_11.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GestionEleve_11
{
    class DeletingInXML
    {
        string pathToXmlFile;
        public DeletingInXML(string path="D:\\ensat.xml")
        {
            this.pathToXmlFile = path;
        }
        public  void AjouterEleveSupprimerAuFichierXML(eleves e)
        {
           

            XmlDocument doc = new XmlDocument();
            doc.Load(pathToXmlFile);

            XmlElement ParentNode = doc.CreateElement("Eleve");
            

            XmlElement codeElev = doc.CreateElement("CodeEleve");
            codeElev.InnerText = e.codeElev;
            XmlElement Nom = doc.CreateElement("Nom");
            Nom.InnerText = e.nom;
            XmlElement Prenom = doc.CreateElement("Prenom");
            Prenom.InnerText = e.prenom;
            XmlElement CodeFilière = doc.CreateElement("CodeFilière");
            CodeFilière.InnerText = e.code_Fil;
            XmlElement niveau = doc.CreateElement("niveau");
            niveau.InnerText = e.niveau;

            ParentNode.AppendChild(codeElev);
            ParentNode.AppendChild(Nom);
            ParentNode.AppendChild(Prenom);
            ParentNode.AppendChild(CodeFilière);
            ParentNode.AppendChild(niveau);

            doc.LastChild.AppendChild(ParentNode);

            doc.Save(pathToXmlFile); 

           
        }
    }
}
