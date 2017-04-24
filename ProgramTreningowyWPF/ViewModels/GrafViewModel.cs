using Prism.Mvvm;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramTreningowyWPF.Events;
using System.Collections.ObjectModel;
using ProgramTreningowyWPF.Models;
using System.Windows;

namespace ProgramTreningowyWPF.ViewModels
{
    public class GrafViewModel : BindableBase
    {
       
      

        private PersonNoTreningDaySet _selectedDay; //włóaściwość prismowa
        public PersonNoTreningDaySet SelectedDay
        {
            get { return _selectedDay; }

            set { SetProperty(ref _selectedDay, value); }

        }

        private PersonSet _selectedPerson; //włóaściwość prismowa
        public PersonSet SelectedPerson
        {
            get { return _selectedPerson; }

            set { SetProperty(ref _selectedPerson, value); }

        }

        public GrafViewModel( IEventAggregator eventAggregator)
        {

            eventAggregator.GetEvent<DayEvent>().Subscribe(UpdateDay); //przyjmujemy wartośc wyslaną przez eventaggregatro
            eventAggregator.GetEvent<PersonEvent>().Subscribe((obj) => SelectedPerson = (PersonSet)obj);
            GrafData = new ObservableCollection<KeyValuePair<string, double?>>();
        }

        private void UpdateDay(PersonNoTreningDaySet obj)//super metodka która trigeruje się za każdym razem jak jest zmiana na dacie
        {

            SelectedDay = (PersonNoTreningDaySet)obj;
            Values = new ObservableCollection<PersonNoTreningDaySet>();//wreszcie sukces ;)
            Values.Add(SelectedDay);
           

            using (Models.WorkOut2Container contex = new Models.WorkOut2Container())
            {
                var listForGraf = (from c in contex.PersonNoTreningDaySetSet where c.PersonSetId == SelectedPerson.Id select c);
                var listForGraf1 = (from c in contex.PersonTreningDaySetSet where c.PersonSetId == SelectedPerson.Id select c);
                Dictionary<string, double?> dictionary =  new Dictionary<string, double?>();

                foreach (var graf in listForGraf)
                {
                    DateTime temp = (DateTime)graf.Date;
                    dictionary.Add(temp.ToShortDateString(), graf.Weight);
                }
                foreach (var graf in listForGraf1)
                {
                    DateTime temp = (DateTime)graf.Date;
                    dictionary.Add(temp.ToShortDateString(), graf.Weight);
                }

                var items = from pair in dictionary orderby pair.Key ascending select pair;
                foreach (var graf in items)
                {
                    GrafData.Add(new KeyValuePair<string, double?>(graf.Key, graf.Value));
                }
            
            }

        }


        private ObservableCollection<PersonNoTreningDaySet> values; //lista w której przechowywane sa obiekty przekazane w maina i jest połączona z dataGrid 
                                               
        public ObservableCollection<PersonNoTreningDaySet> Values
        {
            get { return values; }
            set { SetProperty(ref values, value); }
           
        }
        
        private ObservableCollection<KeyValuePair<string, double?>> grafData;
   public ObservableCollection<KeyValuePair<string, double?>> GrafData
        {
            get { return grafData; }
            set { SetProperty(ref grafData, value); }
        }

      


    }
}
