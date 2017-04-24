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
    class RegisterationViewModel : BindableBase//PrismMvvm
    {
        private PersonSet personToAdd;

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

        private string retryPassword;

        public string RetryPassword//Specjalna właściwość bindująca od prism
        {
            get { return retryPassword; }
            set { SetProperty(ref retryPassword, value); } // sprawdza czy się zmieniła wartośc jak tak to ustawia na nią
        }

        private IEventAggregator _eventAggregator;
        private readonly IRegionManager _regonManager;
        public RegisterationViewModel(IEventAggregator eventAggregator, IRegionManager regionManager)
        {
            _eventAggregator = eventAggregator;
            _regonManager = regionManager;
            NavigatedCommand = new DelegateCommand<string>(Navigate);
           RegisterMethod = new DelegateCommand(Execute, CanExecute).ObservesProperty(() => Login).ObservesProperty(() => Password).ObservesProperty(() => RetryPassword); //żeby obserowawło zmiany oczywiscie za sprawa prisma

        }
     

        private void Navigate(string uri)
        {
            _regonManager.RequestNavigate("ContentRegion", uri);

        }


        public DelegateCommand<string> NavigatedCommand { get; set; }
        public DelegateCommand RegisterMethod { get; set; }

        private bool CanExecute()
        {


            return !String.IsNullOrWhiteSpace(Login) && !String.IsNullOrWhiteSpace(Password)&& !String.IsNullOrWhiteSpace(RetryPassword)&& Password==RetryPassword;
        }

        private void Execute()
        {
            personToAdd = new PersonSet(Login, Password);
            using (Models.WorkOut2Container contex = new Models.WorkOut2Container())
            {
                try
                {
                    contex.PersonSetSet.Add(personToAdd);
                    contex.SaveChanges();
                    //MessageBox.Show("You are register "+ Login);
                    _eventAggregator.GetEvent<RegisterString>().Publish("You are register " + Login);
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.InnerException.Message);
                }
            }

        }




    }
}
