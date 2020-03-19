using GestionEleve_11.Data;
using MySql.Data.MySqlClient;
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
    public partial class Form2 : Form
    {
        eleves E = new eleves();
        GererMatieres _Gmatières;
        GererNotes _Gnotes;
        public Form2(eleves E)
        {
            InitializeComponent();
            this.E = E;
            _Gmatières = new GererMatieres();
            _Gnotes = new GererNotes();
            label4.Text = E.codeElev;
            List<matieres> Listmat = _Gmatières.RechercheMs(E);
            
            foreach(matieres dr in Listmat)
            {
                comboBox1.Items.Add(dr.codeMat);
            }
            InitialiserGrid();
        }
        private void InitialiserGrid() // intitialisation de la liste afficher
        {
            _Gnotes = new GererNotes();
            List<notes> listn = _Gnotes.ListerNotes(E.codeElev);
      

            dataGridView1.DataSource = listn;
        }
        private void button5_Click(object sender, EventArgs e)  //rechercher
        {
            // Afficher dans Grid just la ligne de la matière séléctionnée 
            string matière = comboBox1.Text;
            if (matière == "")
            {
                MessageBox.Show("Entrez une matière pour rechercher");
                return;
            }
            notes N = new notes();
            N.codeElev = E.codeElev;
            N.codeMat = matière;
            N.note = 0;
            
            List<notes> n = _Gnotes.ListerUneNote(N);
           

            dataGridView1.DataSource = n;
        }

        private void button2_Click(object sender, EventArgs e) // Ajouter une note
        {
            string matière = comboBox1.Text;
            double Note = -1;
            
            if (matière == "") 
            {
                MessageBox.Show("Entrez la matière ");
                return;
            }
            if (Note == -1 && textBox1.Text=="")
            {
                MessageBox.Show("Entrez la note");
                return;
            }
            Note = Convert.ToDouble(textBox1.Text);
            if(Note<0 || Note > 20)
            {
                MessageBox.Show("La note doit être entre 0 et 20");
                return;
            }
            notes N = new notes();
            N.codeElev = E.codeElev;
            N.codeMat = matière;
            N.note = Note;
            // on doit premièrement voir si cette matière à déjà une note , dans ce cas on peut seulement la modifier, 
            Boolean noteExistedeja = _Gnotes.NoteExiste(N);
            if (noteExistedeja)
            {
                MessageBox.Show("la note de cette matière existe déjà , vous pouvez seulement la modifier!");
                return;
            }
            _Gnotes.AjouterNote(N);
            MessageBox.Show("Note ajoutée");
            InitialiserGrid();


        }

        private void button1_Click(object sender, EventArgs e) // nouveau
        {
            comboBox1.Text = "";
            textBox1.Text = "";
            InitialiserGrid();
        }

        private void button4_Click(object sender, EventArgs e)  //supprimer
        {

            DataGridViewRow drg1 = dataGridView1.CurrentRow;

            string codeE = drg1.Cells[0].Value.ToString();
            string codeM = drg1.Cells[1].Value.ToString();
            //message de confirmation
            var selectedoption = MessageBox.Show("Etes vous sure de vouloir supprimer cette note ?", "Confirmation", MessageBoxButtons.YesNo);
            if (selectedoption == DialogResult.No)
            {
                return;
            }

           
            notes N = new notes();
            N.codeElev = codeE;
            N.codeMat = codeM;
            N.note = 0;
            _Gnotes.SupprimerNote(N);
            InitialiserGrid();
            MessageBox.Show("Note supprimée");
            


        }

        private void button3_Click(object sender, EventArgs e) // modifier
        {
            DataGridViewRow drg1 = dataGridView1.CurrentRow;
            double Note = -1;
            string codeE = drg1.Cells[0].Value.ToString();
            string codeM = drg1.Cells[1].Value.ToString();
            if (Note == -1 && textBox1.Text == "")
            {
                MessageBox.Show("Entrez la note pour modifier");
                return;
            }
           
            Note = Convert.ToDouble(textBox1.Text);
            if (Note < 0 || Note > 20)
            {
                MessageBox.Show("La note doit être entre 0 et 20");
                return;
            }
            //message de confirmation
            var selectedoption = MessageBox.Show("Etes vous sure de vouloir modifer la note de la matière " + codeM + " ?", "Confirmation", MessageBoxButtons.YesNo);
            if (selectedoption == DialogResult.No)
            {
                return;
            }
            
            notes N = new notes();
            N.codeElev = codeE;
            N.codeMat = codeM;
            N.note = Note;
            _Gnotes.UpdateN(N);
            InitialiserGrid();
            MessageBox.Show("Note modifié");
        }
    }
}
