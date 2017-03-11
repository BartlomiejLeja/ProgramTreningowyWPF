using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using Prism.Mvvm;
using System.Windows.Input;
using Prism.Commands;
using Prism.Regions;

namespace ProgramTreningowyWPF.ViewModels
{
   public class MainWindowViewModel:BindableBase//PrismMvvm
    {
        public MainWindowViewModel(IRegionManager regionManager) //regiony żebyśmy mogli manipulowac view
        {
            _regonManager = regionManager; // typiarz manipuluje regionami
            NavigatedCommand = new DelegateCommand<string>(Navigate);// manipuluje stringami powinnienem obietkami
            DodajDzienTreningowy = new DelegateCommand(Execute,CanExecute).ObservesProperty(()=>SelectedDate);//using Prism.Commands nowy prismowy sposób na komendy łatwiejszy
        }                                                                  //ObserveProperty żeby patrzyło czy się zmienia włąściwośc i na to reagowało można pare po . każde

        
        private readonly IRegionManager _regonManager;
        public DelegateCommand<string> NavigatedCommand { get; set; }

        private void Navigate(string uri) 
        {
            _regonManager.RequestNavigate("ContentRegion", uri);
        }



        private bool CanExecute()//Mówi kiedy możemy uzyć; fajny sposób na walidacje np stringa IsNulleble 
        {
            throw new NotImplementedException();
        }

        private void Execute()//tu rzeczy które będziemy robić 
        {
            throw new NotImplementedException();
        }

        private DateTime selectedDate;

        public  DateTime SelectedDate//Specjalna właściwość bindująca od prism
        {
            get { return selectedDate; }
            set { SetProperty(ref selectedDate, value);  } // sprawdza czy się zmieniła wartośc jak tak to ustawia na nią
        }

       public DelegateCommand DodajDzienTreningowy { get; set; } //using system.windows.input


    }
}
