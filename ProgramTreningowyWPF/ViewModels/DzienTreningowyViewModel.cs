using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;
using System.Windows;
using System.Windows.Forms;

namespace ProgramTreningowyWPF.ViewModels
{
    class DzienTreningowyViewModel : BindableBase
    {
        private byte[] photo;
        public byte[] Photo//Specjalna właściwość bindująca od prism
        {
            get { return photo; }
            set { SetProperty(ref photo, value); } // sprawdza czy się zmieniła wartośc jak tak to ustawia na nią
        }
        private DateTime? selectedDate;

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

        private string suplementation;

        public string Suplementation//Specjalna właściwość bindująca od prism
        {
            get { return suplementation; }
            set { SetProperty(ref suplementation, value); } // sprawdza czy się zmieniła wartośc jak tak to ustawia na nią
        }

        private string workOut;

        public string WorkOut//Specjalna właściwość bindująca od prism
        {
            get { return workOut; }
            set { SetProperty(ref workOut, value); } // sprawdza czy się zmieniła wartośc jak tak to ustawia na nią
        }

        public DelegateCommand AddPhoto { get; set; }

        public DelegateCommand AddDay { get; set; }
        public DzienTreningowyViewModel()
        {
            AddDay = new DelegateCommand(Execute, CanExecute).ObservesProperty(() => Diete); //żeby obserowawło zmiany oczywiscie za sprawa prisma
            AddPhoto = new DelegateCommand(ExecutePhoto);
        }

        private void ExecutePhoto()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Jpg|*.jpg|Bitmaps | *.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                photo = System.IO.File.ReadAllBytes(openFileDialog.FileName);

            }
        }

        private bool CanExecute()
        {
            return !String.IsNullOrWhiteSpace(Diete);
        }

        private void Execute()
        {

            Models.p Dzien;
            Dzien = new Models.p(SelectedDate, Diete, Wage,Suplementation,WorkOut,Photo);
            using (Models.WorkOutEntities contex = new Models.WorkOutEntities())
            {
                try
                {
                    contex.p.Add(Dzien);
                    contex.SaveChanges();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.InnerException.Message);
                }
            }
        }

    }
}
