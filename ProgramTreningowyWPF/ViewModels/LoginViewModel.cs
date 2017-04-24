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
    class LoginViewModel : BindableBase
    {
        private bool isActive;
        private PersonSet person;
        private string login;
      
        public string Login//Specjalna właściwość bindująca od prism
        {
            get { return login; }
            set { SetProperty(ref login, value); } // sprawdza czy się zmieniła wartośc jak tak to ustawia na nią
        }

        private string password;

        public string Password//Specjalna właściwość bindująca od prism
        {
            get { return password; }
            set { SetProperty(ref password, value); } // sprawdza czy się zmieniła wartośc jak tak to ustawia na nią
        }

        private IEventAggregator _eventAggregator;
        public LoginViewModel(IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            _eventAggregator = eventAggregator;
            _regonManager = regionManager;
            NavigatedCommand = new DelegateCommand<string>(Navigate);
            LoginMethod = new DelegateCommand(Execute, CanExecute).ObservesProperty(() => Login).ObservesProperty(() => Password); //żeby obserowawło zmiany oczywiscie za sprawa prisma

        }
        private readonly IRegionManager _regonManager;


        private void Navigate(string uri)
        {
            _regonManager.RequestNavigate("ContentRegion", uri);
        }

        
        public DelegateCommand<string> NavigatedCommand { get; set; }
        public DelegateCommand LoginMethod { get; set; }

        private bool CanExecute()
        {
            return !String.IsNullOrWhiteSpace(Login) && !String.IsNullOrWhiteSpace(Password);
        }

        private void Execute()
        {
            using (Models.WorkOut2Container contex = new Models.WorkOut2Container())
            {
                person = (from c in contex.PersonSetSet where c.Login == Login select c).FirstOrDefault();

                if (person.Password == Password)
                {
                   // System.Windows.MessageBox.Show("You are login " + person.Login);
                    this.Navigate("DzienNieTreningowy");
                    this.Navigate("DzienTreningowy");
                    this.Navigate("Graf");
                    this.Navigate("GrafWorkOutDay");
                    this.Navigate("Login");
                    _eventAggregator.GetEvent<PersonEvent>().Publish(person);
                    isActive = true;
                    _eventAggregator.GetEvent<IsActive>().Publish(isActive);
                    _eventAggregator.GetEvent<LoginString>().Publish("Hello "+person.Login+", select date to see your data ");
                    _eventAggregator.GetEvent<ErrorString>().Publish("");
                    Password = null;
                    Login = null;
                }
                else
                {
                    //System.Windows.MessageBox.Show("Wrong password or login ");
                    _eventAggregator.GetEvent<WrongLoginString>().Publish("Wrong password or login ");
                }
            }
          
        }
     
        

    }

    
}