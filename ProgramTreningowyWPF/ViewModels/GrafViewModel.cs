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
       
      

        private p _selectedDay; //włóaściwość prismowa
        public p SelectedDay
        {
            get { return _selectedDay; }

            set { SetProperty(ref _selectedDay, value); }

        }
        public GrafViewModel(IEventAggregator eventAggregator, IEventAggregator eventAggregator1)
        {
            eventAggregator1.GetEvent<DayEvent>().Subscribe(UpdateDay); //przyjmujemy wartośc wyslaną przez eventaggregatro
            
          
        }

        private void UpdateDay(p obj)//super metodka która trigeruje się za każdym razem jak jest zmiana na dacie
        {
            SelectedDay = (p)obj;
            Values = new ObservableCollection<p>();//wreszcie sukces ;)
            Values.Add(SelectedDay);

        }


        private ObservableCollection<p> values; //lista w której przechowywane sa obiekty przekazane w maina i jest połączona z dataGrid 
                                               
        public ObservableCollection<p> Values
        {
            get { return values; }
            set { SetProperty(ref values, value); }
        }



    }
}
