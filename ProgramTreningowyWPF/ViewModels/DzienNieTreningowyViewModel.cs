﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Input;
using System.Windows;

namespace ProgramTreningowyWPF.ViewModels
{
    class DzienNieTreningowyViewModel:BindableBase
    {

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
        public DzienNieTreningowyViewModel()
        {
            AddDay = new DelegateCommand(Execute,CanExecute).ObservesProperty(()=>Diete); //żeby obserowawło zmiany oczywiscie za sprawa prisma
        }

        private bool CanExecute()
        {
            return !String.IsNullOrWhiteSpace(Diete);
        }

        private void Execute()
        {
            
            p Dzien;
            Dzien = new p(SelectedDate, Diete, Wage);
            using (WorkOutEntities contex = new WorkOutEntities())
            {
                try
                {
                    contex.p.Add(Dzien);

                    contex.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.InnerException.Message);
                }
            }
        }

      
    }
}
