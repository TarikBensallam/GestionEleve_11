using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionEleve_11.Data;
using MySql.Data.MySqlClient;
namespace GestionEleve_11
{
    public partial class Form1 : Form
    {
        GererEtudiant _Getudiant;
        public Form1()
        {
            InitializeComponent();
            _Getudiant = new GererEtudiant();
            InitialiserGrid();
        }

        private void button2_Click(object sender, EventArgs e) //Ajouter Etudiant
        {
       
            string nom, prenom, code, niveau,fili;
           
            eleves E = new eleves();
            code = textBox1.Text;
            nom = textBox2.Text;
            prenom = textBox3.Text;
            fili = comboBox1.Text;
            niveau = comboBox2.Text;

            //I need to check if all textboxes are full 
            foreach(Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    if( ((TextBox)x).Text == String.Empty){
                        MessageBox.Show("Tous les champs doivent être remplies");
                        return;
                    }

                }
                if (x is ComboBox)
                {
                    if (((ComboBox)x).Text == String.Empty)
                    {
                        MessageBox.Show("Tous les champs doivent être remplies");
                        return;
                    }

                }
            }

            // i still need to check if the primary key exist 
            if (_Getudiant.EtudiantExiste(code))
            {
                MessageBox.Show("Ce code etudiant existe déjà , impossible d'ajouter");
                return;
            }
            E.codeElev = code;
            E.niveau = niveau;
            E.nom = nom;
            E.prenom = prenom;
            E.code_Fil = fili;

           _Getudiant.AjouterEtudiant(E);
            MessageBox.Show("Etudiant Insérer");
            SupprimerTtChamps();
            InitialiserGrid();

        }

        private void button1_Click(object sender, EventArgs e) //Nouveau , intialiser les champs [done]
        {
            textBox1.Text="";
            textBox2.Text="";
            textBox3.Text="";
            comboBox1.Text="";
            comboBox2.Text="";
            InitialiserGrid();
        }

        private void button4_Click(object sender, EventArgs e) // Supprimer [DONE]
        {
            string code;
            code = textBox1.Text;
            if (code == "")
            {
                MessageBox.Show("Entrez le code étudiant pour supprimer un étudiant !");
                return;
            }
            if (!_Getudiant.EtudiantExiste(code))
            {
                MessageBox.Show("cet étudiant n'existe pas !! ");
                return;
            }
            // Supprimer l'étudiant ,
            var selectedoption = MessageBox.Show("Etes vous sure de vouloir supprimer cet étudiant ?", "Confirmation", MessageBoxButtons.YesNo);
            if (selectedoption == DialogResult.No)
            {
                return;
            }
            eleves ee = _Getudiant.RechercherUnEtudiant(code);
            _Getudiant.SupprimerEtudiant(code);
            MessageBox.Show("Étudiant Supprimé ! ");
            InitialiserGrid();
            DeletingInXML dl = new DeletingInXML("D:\\ensat.xml");
            dl.AjouterEleveSupprimerAuFichierXML(ee);
        }
       

        private void button5_Click(object sender, EventArgs e) // Rechercher
        {
            
            string code="";
            string nom = "";
            string prenom = "";
            string fili = "";
            string niveau = "";
          
            if(!checkBox5.Checked && !checkBox4.Checked && !checkBox3.Checked && !checkBox2.Checked && !checkBox1.Checked)
            {
                MessageBox.Show("Choisissez un critère de recherche et entrez sa valeur !");
                return;
            }
            if (checkBox1.Checked)
            {
                code = textBox1.Text;
            }
            if (checkBox2.Checked)
            {
                 nom = textBox2.Text;
            }
            if (checkBox3.Checked)
            {
                prenom = textBox3.Text;
            }
            if (checkBox4.Checked)
            {
                fili = comboBox1.Text;
            }
            if (checkBox5.Checked)
            {
                niveau = comboBox2.Text;
            }
        
            
            eleves E = new eleves();
            E.codeElev = code;
            E.nom = nom;
            E.prenom = prenom;
            E.code_Fil = fili;
            E.niveau = niveau;
            List<eleves> listE = _Getudiant.RechercheE(E);
            
           
            dataGridView1.DataSource = listE;

        }
        private void InitialiserGrid() // intitialisation de la liste afficher
        {
            _Getudiant = new GererEtudiant(); 
            // j'ai ajouter cette ligne car quand je faisais la modification même quand j'intialisais , la modification
            //n'apparait pas dans grid 

            List<eleves> listE = _Getudiant.ListerTtEtudiant();

            dataGridView1.DataSource = listE;
        }

        private void button3_Click(object sender, EventArgs e) // Modifier
        {
            DataGridViewCell d = dataGridView1.SelectedCells[0];
            string code = d.Value.ToString();
            if (code == "")
            {
                MessageBox.Show("Sélectionnez un étudiant pour le modifier");
                return;
            }
            eleves eleve = _Getudiant.RechercherUnEtudiant(code);
            ComboBoxModif frm = new ComboBoxModif(eleve);
            frm.Show();  

        }

        private void SupprimerTtChamps()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fili = comboBox1.Text;
            List<eleves> l = _Getudiant.RechercheParFilière(fili);
           
            dataGridView1.DataSource = l;
        }

        private void button6_Click(object sender, EventArgs e) // gestion des notes
        {
            DataGridViewCell d0 = dataGridView1.SelectedCells[0];
       
            
            string code = d0.Value.ToString();
         
            if (code == "")
            {
                MessageBox.Show("Sélectionnez un étudiant pour le modifier");
                return;
            }
            eleves Eleve = _Getudiant.RechercherUnEtudiant(code);// we need etudiant with that code 
            Form2 frm2 = new Form2(Eleve);
            frm2.Show();
        }
    }
}
