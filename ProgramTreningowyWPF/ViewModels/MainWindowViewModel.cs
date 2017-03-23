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
using System.Windows;
using System.Windows.Data;
using Prism.Events;
using ProgramTreningowyWPF.Events;

namespace ProgramTreningowyWPF.ViewModels
{
   public class MainWindowViewModel:BindableBase//PrismMvvm
    {
        public MainWindowViewModel(IRegionManager regionManager, IEventAggregator eventAggregator,IEventAggregator eventAggregator1) //regiony żebyśmy mogli manipulowac view
        {
            _eventAggregator1 = eventAggregator;                                                                                 //IEventAggregator do event aggregator czyli do przekazywania wartości pomiedzy viewmodelami
            _eventAggregator = eventAggregator;
            _regonManager = regionManager; // typiarz manipuluje regionami
            NavigatedCommand = new DelegateCommand<string>(Navigate);// manipuluje stringami powinnienem obietkami
            Proba = new DelegateCommand(Execute,CanExecute).ObservesProperty(()=>SelectedDate);//using Prism.Commands nowy prismowy sposób na komendy łatwiejszy
        }                                                                  //ObserveProperty żeby patrzyło czy się zmienia włąściwośc i na to reagowało można pare po . każde

        private IEventAggregator _eventAggregator1;
        private IEventAggregator _eventAggregator;
        private readonly IRegionManager _regonManager;
        public DelegateCommand<string> NavigatedCommand { get; set; }

        private void Navigate(string uri)
        {
            _regonManager.RequestNavigate("ContentRegion", uri);
          
          
            using (Models.WorkOutEntities contex = new Models.WorkOutEntities())
            {
                var pToView = (from c in contex.p where c.Dzień == SelectedDate select c).FirstOrDefault();
                _eventAggregator1.GetEvent<DayEvent>().Publish(pToView);//wysłam event czyli przesyłam wartość pToView tam gdzie będzie subscribe
            }
         
        }


        private bool CanExecute()//Mówi kiedy możemy uzyć; fajny sposób na walidacje np stringa IsNulleble 
        {
           return true;
        }

        private void Execute()//tu rzeczy które będziemy robić 
        {
            
        }

        private DateTime? selectedDate;
        

        public  DateTime? SelectedDate//Specjalna właściwość bindująca od prism
        {
            get { return selectedDate; }
            set { SetProperty(ref selectedDate, value);  } // sprawdza czy się zmieniła wartośc jak tak to ustawia na nią
        }


       public DelegateCommand Proba { get; set; } //using system.windows.input

       

    }
}
