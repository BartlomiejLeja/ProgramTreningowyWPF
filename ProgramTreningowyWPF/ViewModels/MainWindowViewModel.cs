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
using ProgramTreningowyWPF.Models;

namespace ProgramTreningowyWPF.ViewModels
{
   public class MainWindowViewModel:BindableBase//PrismMvvm
    {

        private string _loginString; //włóaściwość prismowa
        public string LoginString
        {
            get { return _loginString; }

            set { SetProperty(ref _loginString, value); }

        }

        private string _errorString; //włóaściwość prismowa
        public string ErrorString
        {
            get { return _errorString; }

            set { SetProperty(ref _errorString, value); }

        }



        private PersonSet _selectedPerson; //włóaściwość prismowa
        public PersonSet SelectedPerson
        {
            get { return _selectedPerson; }

            set { SetProperty(ref _selectedPerson, value); }

        }

        private bool _isActive; //włóaściwość prismowa
        public bool isActive
        {
            get { return _isActive; }

            set { SetProperty(ref _isActive, value); }

        }



        public DelegateCommand Login { get; set; } //using system.windows.input
        public DelegateCommand NavigateToGraf { get; set; } //using system.windows.input
        public DelegateCommand NavigateNoWorkOutDay { get; set; } //using system.windows.input
        public DelegateCommand NavigateWorkOutDay { get; set; } //using system.windows.input
        public DelegateCommand LogOut { get; set; } //using system.windows.input
        public DelegateCommand Register { get; set; } //using system.windows.input
        private IEventAggregator _eventAggregator;
        private readonly IRegionManager _regonManager;
        public DelegateCommand<string> NavigatedCommand { get; set; }
        public MainWindowViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) //regiony żebyśmy mogli manipulowac view
        {
            LoginString = "You are not login, please login to see your data";
            isActive = false; 
            _regonManager = regionManager; // typiarz manipuluje regionami
            //Comends
            NavigatedCommand = new DelegateCommand<string>(Navigate);// manipuluje stringami powinnienem obietkami
            NavigateToGraf = new DelegateCommand(Execute,CanExecute).ObservesProperty(()=>SelectedDate);//using Prism.Commands nowy prismowy sposób na komendy łatwiejszy
            NavigateNoWorkOutDay = new DelegateCommand(ExecuteNavigateNoWorkOutDay, CanExecuteNavigateNoWorkOutDay).ObservesProperty(() => isActive);
            NavigateWorkOutDay = new DelegateCommand(ExecuteNavigateWorkOutDay, CanExecuteNavigateWorkOutDay).ObservesProperty(() => isActive);
            Login = new DelegateCommand(ExecuteLogin, CanExecuteLogin).ObservesProperty(() => isActive);
            LogOut=new DelegateCommand(ExecuteLogOut, CanExecuteLogOut).ObservesProperty(() => isActive);
            Register = new DelegateCommand(ExecuteRegister);
            //Eventy
            _eventAggregator = eventAggregator;   //IEventAggregator do event aggregator czyli do przekazywania wartości pomiedzy viewmodelami
            _eventAggregator.GetEvent<IsActive>().Subscribe((obj) => isActive = (bool)obj);
            _eventAggregator.GetEvent<LoginString>().Subscribe((obj) => LoginString = (string)obj);
            _eventAggregator.GetEvent<ErrorString>().Subscribe((obj) => ErrorString = (string)obj);
            _eventAggregator.GetEvent<WrongLoginString>().Subscribe((obj) => ErrorString = (string)obj);
            _eventAggregator.GetEvent<RegisterString>().Subscribe((obj) => ErrorString = (string)obj);
            _eventAggregator.GetEvent<RestDayAddString>().Subscribe((obj) => ErrorString = (string)obj);
            _eventAggregator.GetEvent<PersonEvent>().Subscribe((obj) => SelectedPerson = (PersonSet)obj); //ObserveProperty żeby patrzyło czy się zmienia włąściwośc i na to reagowało można pare po . każde

        }

        private void ExecuteRegister()
        {
            Navigate("Registeration");
        }

        private bool CanExecuteLogOut()
        {
            return isActive;
        }

        private void ExecuteLogOut()
        {
            isActive = false;
            LoginString = "You are not login";
            Navigate("Login");
        }

        private bool CanExecuteLogin()
        {
            return !isActive;
        }

        private void ExecuteLogin()
        {
            Navigate("Login");
        }

        private bool CanExecuteNavigateWorkOutDay()
        {
            return isActive;
        }

        private void ExecuteNavigateWorkOutDay()
        {
            Navigate("DzienTreningowy");
        }

        private bool CanExecuteNavigateNoWorkOutDay()
        {
            return isActive;
        }

        private void ExecuteNavigateNoWorkOutDay()
        {
            Navigate("DzienNieTreningowy");
        }

        private void Navigate(string uri)
        {
            _regonManager.RequestNavigate("ContentRegion", uri);
        }


        private bool CanExecute()//Mówi kiedy możemy uzyć; fajny sposób na walidacje np stringa IsNulleble 
        {
           return true;
        }

        private void Execute()//tu rzeczy które będziemy robić 
        {
           
            using (Models.WorkOut2Container contex = new Models.WorkOut2Container())
            {
                if (SelectedPerson != null)
                {
                    var noTreningDayToSend = (from c in contex.PersonNoTreningDaySetSet where c.Date == SelectedDate && c.PersonSetId == SelectedPerson.Id select c).FirstOrDefault();
                    var treningDayToSend = (from c in contex.PersonTreningDaySetSet where c.Date == SelectedDate && c.PersonSetId == SelectedPerson.Id select c).FirstOrDefault();
                    if (noTreningDayToSend != null)
                    {
                        _eventAggregator.GetEvent<DayEvent>().Publish(noTreningDayToSend);//wysłam event czyli przesyłam wartość pToView tam gdzie będzie subscribe
                        this.Navigate("Graf");
                    }
                    else if (treningDayToSend != null)
                    {
                        this.Navigate("GrafWorkOutDay");
                        _eventAggregator.GetEvent<WorkOutDayEvent>().Publish(treningDayToSend);//wysłam event czyli przesyłam wartość pToView tam gdzie będzie subscribe


                    }
                    else
                    {
                        //MessageBox.Show("W tym dniu nie było ani treningu ani odpoczynku!");
                        ErrorString = "You haven't got any data on this day";

                    }
                }
                else
                {
                   // MessageBox.Show("You must be login to show the data");
                    ErrorString = "You must be login to show the data";
                }

            
            }
            
        }

        private DateTime? selectedDate;
        

        public  DateTime? SelectedDate//Specjalna właściwość bindująca od prism
        {
            get { return selectedDate; }
            set { SetProperty(ref selectedDate, value);  } // sprawdza czy się zmieniła wartośc jak tak to ustawia na nią
        }


      

       

    }
}
