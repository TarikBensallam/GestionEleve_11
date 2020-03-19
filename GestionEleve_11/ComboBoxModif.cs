using GestionEleve_11.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionEleve_11
{
    public partial class ComboBoxModif : Form
    {
        public string codeE;
        GererEtudiant _Getudiant;
        public ComboBoxModif(eleves e)
        {
            InitializeComponent();
            _Getudiant = new GererEtudiant();
            this.codeE=label2.Text = e.codeElev;
            textBox1.Text = e.nom;
            textBox2.Text = e.prenom;
            comboBox1.Text = e.code_Fil;
            textBox3.Text = e.niveau;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //I need to check if all textboxes are full 
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    if (((TextBox)x).Text == String.Empty)
                    {
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

            // Now i need to update 
            eleves et1 = new eleves();
            et1.codeElev = this.codeE;
            et1.nom = textBox1.Text;
            et1.prenom = textBox2.Text;
            et1.code_Fil = comboBox1.Text;
            et1.niveau = textBox3.Text;
            _Getudiant.UpdateE(et1);
            MessageBox.Show("Etudiant Modifié");
            this.Close();
            

        }
    }
}
