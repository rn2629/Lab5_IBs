using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Lab5.Command;
using Lab5.Model;
using Lab5.View;

namespace Lab5.ViewModel
{
    class MainViewModel : BaseViewModel, INotifyPropertyChanged
    {

        Personne pers;
        AjouterJeu ajouter;

        public MainViewModel() : base()
        {
            AjouterJ = new AjouterJeu();
            Pers = new Personne();
            // Connexion = new BaseCommand(Conn, obj => true);
            Inscription = new BaseCommand(Ins, obj => true);
            Ajouter = new BaseCommand(Ajout, obj => true);
            OpenInscription = new OpenCommand(this);
            OpenConnexion = new OpenConnexion(this);
            SeConnecter = new Connexion(this);
            AjoutJeux = new AjouterJeux(this);
        }

        public ICommand OpenInscription
        {
            get;
            private set;
        }
        public ICommand OpenConnexion
        {
            get;
            private set;
        }
        public ICommand SeConnecter
        {
            get;
            private set;
        }
        public ICommand AjoutJeux
        {
            get;
            private set;
        }
        public bool CanUpdate
        {
            get
            {
                if (pers == null)
                    return false;
                else
                    return true;
            }
        }
        public void SaveChanges()
        {
            Window fenetre2 = new Inscription();
            fenetre2.Show();
            fenetre2.DataContext = this;
        }
        public void Connecter()
        {
            Window fenetre2 = new MainWindow();
            fenetre2.Show();
            fenetre2.DataContext = this;
        }
        public void AJeux()
        {
            Window fenetre2 = new AjoutJeu();
            fenetre2.Show();
            fenetre2.DataContext = this;
        }

        public void SaveJeu()
        {
            int id = 0;
            if (Pers.AdresseCourriel == "")

            {
                MessageBox.Show("Veuillez entrer vos informations de connexion");
            }
            else
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT id FROM tblJoueur WHERE courriel = @param1 AND motDePasse = @param2", con);
                    cmd.Parameters.Add("@param1", SqlDbType.VarChar, 255).Value = Pers.AdresseCourriel;
                    cmd.Parameters.Add("@param2", SqlDbType.Int, 10).Value = Pers.Password;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet, "tblJoueur");


                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        id = Int32.Parse(row[0].ToString());
                    }
                    if (id != 0)
                    {
                        Window fenetre2 = new LancerJeu();
                        fenetre2.Show();
                        fenetre2.DataContext = this;
                    }
                    else
                    {
                        MessageBox.Show("Adresse Courriel ou Mot de Passe Erroné");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        public AjouterJeu AjouterJ { get => ajouter; set { ajouter = value; OnPropertyChanged("AjouterJ"); } }
        public ICommand Connexion { get; set; }
        public ICommand Ajouter { get; set; }
        public ICommand Inscription { get; set; }
        public Personne Pers { get => pers; set { pers = value; OnPropertyChanged("Pers"); } }


        private void Ajout(Object obj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tblJeu(nom,emplacement,idJoueur) VALUES(@param1,@param2,@param3)", con);
                cmd.Parameters.Add("@param", SqlDbType.VarChar, 255).Value = AjouterJ.NomJeu;
                cmd.Parameters.Add("@param2", SqlDbType.VarChar, 255).Value = AjouterJ.EmplacementJeu;
                cmd.Parameters.Add("@param3", SqlDbType.Int, 10).Value = AjouterJ.IdJoueur;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
              
            }

        }

        private void Ins(Object obj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tblJoueur(nom,prenom,courriel,motDePasse) VALUES(@param1,@param2,@param3,@param4)", con);
                cmd.Parameters.Add("@param1", SqlDbType.VarChar, 255).Value = Pers.Nom;
                cmd.Parameters.Add("@param2", SqlDbType.VarChar, 255).Value = Pers.Prenom;
                //  cmd.Parameters.Add("@param3", SqlDbType.Date, 255).Value = Pers.DateBirth;
                cmd.Parameters.Add("@param3", SqlDbType.VarChar, 255).Value = Pers.AdresseCourriel;
                cmd.Parameters.Add("@param4", SqlDbType.Int, 10).Value = Pers.Password;
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
