using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Model
{
    class Personne : INotifyPropertyChanged
    {
        string nom = "";
        string prenom ="";
        string adresseCourriel ="";
        int password;
      //  string dateBirth;
        

        public Personne()
        {
            Nom = nom;
            Prenom = prenom;
            AdresseCourriel = adresseCourriel;
            Password = password;
          // DateBirth = dateBirth;
        

        }


        public string Nom { get => nom; set { nom = value; OnPropertyChanged("Nom"); } }

        public string Prenom { get => prenom; set { prenom = value; OnPropertyChanged("Prenom"); } }

        public string AdresseCourriel { get => adresseCourriel; set { adresseCourriel = value; OnPropertyChanged("AdresseCourriel"); } }

        public int Password { get => password; set { password = value; OnPropertyChanged("Password"); } }

       // public string DateBirth { get => dateBirth; set { dateBirth = value; OnPropertyChanged("DateBirth"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
