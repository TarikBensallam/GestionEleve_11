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
        public ComboBoxModif(Etudiant e)
        {
            InitializeComponent();
            this.codeE=label2.Text = e.Code;
            textBox1.Text = e.Nom;
            textBox2.Text = e.Prenom;
            comboBox1.Text = e.Code_Fil;
            textBox3.Text = e.Niveau;
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
            Etudiant et1 = new Etudiant();
            et1.Code = this.codeE;
            et1.Nom = textBox1.Text;
            et1.Prenom = textBox2.Text;
            et1.Code_Fil = comboBox1.Text;
            et1.Niveau = textBox3.Text;
            GererEtudiant.UpdateE(et1);
            MessageBox.Show("Etudiant Modifié");
            this.Close();
            

        }
    }
}
