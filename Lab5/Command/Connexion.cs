using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Lab5.ViewModel;

namespace Lab5.Command
{
    class Connexion : ICommand
    {
        
        private MainViewModel mainViewModel;
        public Predicate<object> CanExecuteFunc
        {
            get;
            set;
        }

        public Action<object> ExecuteFunc
        {
            get;
            set;
        }

        public Connexion(MainViewModel _mainViewModel)
        {

            mainViewModel = _mainViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return mainViewModel.CanUpdate;
        }



        public void Execute(object parameter)
        {
            mainViewModel.Connecter();

        }

        #region ICommand Members

        public event System.EventHandler CanExecuteChanged // peut etre ajouter partt dans notre code
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #endregion
    }

}
