using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Input;

using System.Windows.Forms;
using ProgramTreningowyWPF.Models;
using Prism.Events;
using ProgramTreningowyWPF.Events;

namespace ProgramTreningowyWPF.ViewModels
{
    class DzienNieTreningowyViewModel:BindableBase
    {

        //proba
        private PersonSet _selectedPerson; //włóaściwość prismowa
        public PersonSet SelectedPerson
        {
            get { return _selectedPerson; }

            set { SetProperty(ref _selectedPerson, value); }

        }

        private void UpdateDay(PersonSet obj)//super metodka która trigeruje się za każdym razem jak jest zmiana na dacie
        {
            SelectedPerson = (PersonSet)obj;
            

        }
      
        //proba

        private DateTime? selectedDate ;

        public DateTime? SelectedDate//Specjalna właściwość bindująca od prism
        {
            get { return selectedDate; }
            set { SetProperty(ref selectedDate, value); } // sprawdza czy się zmieniła wartośc jak tak to ustawia na nią
        }
        private double? wage;

        public double? Wage//Specjalna właściwość bindująca od prism
        {
            get { return wage; }
            set { SetProperty(ref wage, value); } // sprawdza czy się zmieniła wartośc jak tak to ustawia na nią
        }
        private string diete;

        public string Diete//Specjalna właściwość bindująca od prism
        {
            get { return diete; }
            set { SetProperty(ref diete, value); } // sprawdza czy się zmieniła wartośc jak tak to ustawia na nią
        }

        public DelegateCommand AddDay { get; set; }

        private IEventAggregator _eventAggregator;
        public DzienNieTreningowyViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

           AddDay = new DelegateCommand(Execute,CanExecute).ObservesProperty(()=>Diete); //żeby obserowawło zmiany oczywiscie za sprawa prisma
            eventAggregator.GetEvent<PersonEvent>().Subscribe(UpdateDay);
          
        }

        private bool CanExecute()
        {
            return !String.IsNullOrWhiteSpace(Diete);
        }

        private void Execute()
        {
          
            Models.PersonNoTreningDaySet Dzien;
            Dzien = new Models.PersonNoTreningDaySet(SelectedDate, Diete,SelectedPerson.Id, Wage);
            using (Models.WorkOut2Container contex = new Models.WorkOut2Container())
            {
                try
                {
                    contex.PersonNoTreningDaySetSet.Add(Dzien);
                     contex.SaveChanges();
                    //MessageBox.Show("Rest day was added! ");
                    _eventAggregator.GetEvent<WrongLoginString>().Publish("Rest day was added! ");
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.InnerException.Message);
                }
            }
        }

      
    }
}
