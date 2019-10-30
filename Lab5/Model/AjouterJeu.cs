using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Model
{
    class AjouterJeu : INotifyPropertyChanged
    {
            
        string nomJeu = "";
        string emplacementJeu;

        public AjouterJeu()
        {
            NomJeu = nomJeu;
            EmplacementJeu = emplacementJeu;
        }

        public string EmplacementJeu { get => emplacementJeu; set { emplacementJeu = value; OnPropertyChanged("EmplacementJeu"); } }
        public string NomJeu { get => nomJeu; set { nomJeu = value; OnPropertyChanged("NomJeu"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
