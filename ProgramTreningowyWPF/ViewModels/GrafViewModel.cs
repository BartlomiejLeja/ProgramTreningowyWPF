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
       
        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get { return _selectedDate; }

            set { SetProperty(ref _selectedDate, value); }

        }

        public GrafViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.GetEvent<DateEvent>().Subscribe(UpdateDate); //przyjmujemy wartośc wyslaną przez eventaggregatro
            Values = new ObservableCollection<p>();
            Values.Add(SerchForView(SelectedDate));
        }

        private void UpdateDate(DateTime? obj)
        {
            SelectedDate = (DateTime)obj;
        }

        public Models.p SerchForView(DateTime dataToSerch)
        {

            using (Models.WorkOutEntities contex = new Models.WorkOutEntities())
            {

               // var pToView = (from c in contex.p where c.Dzień == dataToSerch select c).FirstOrDefault(); //LING to Enitities FirstOrDefault() ponieważ to kolekcja enitis i to 
                var pToView = (from c in contex.p select c).FirstOrDefault();
                MessageBox.Show(pToView.Dieta);
                return pToView;
                //FirstOrDefault() ponieważ to kolekcja enitis ta metoda zamienia mi ti na moją klase
           
            }

        }


        private ObservableCollection<p> values;

        public ObservableCollection<p> Values
        {
            get { return values; }
            set { SetProperty(ref values, value); }
        }



    }
}
