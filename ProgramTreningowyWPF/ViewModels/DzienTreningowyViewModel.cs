using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Commands;

using System.Windows.Forms;
using ProgramTreningowyWPF.Models;
using Prism.Events;
using ProgramTreningowyWPF.Events;

namespace ProgramTreningowyWPF.ViewModels
{
    class DzienTreningowyViewModel : BindableBase
    {
        private PersonTreningDaySet DayToAdd;

        private PersonSet _selectedPerson; //włóaściwość prismowa
        public PersonSet SelectedPerson
        {
            get { return _selectedPerson; }

            set { SetProperty(ref _selectedPerson, value); }

        }

      
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
        public DzienTreningowyViewModel(IEventAggregator eventAggregator)
        {

            eventAggregator.GetEvent<PersonEvent>().Subscribe((obj)=> SelectedPerson = (PersonSet)obj);// ładna lambda;)
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
                if (DayToAdd != null)
                {
                    PersonPhotoSet photoToAdd = new PersonPhotoSet(DayToAdd.Id, photo);
                    using (WorkOut2Container contex = new WorkOut2Container())
                    {
                        try
                        {
                            contex.PersonPhotoSetSet.Add(photoToAdd);
                            contex.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.InnerException.Message);
                        }
                    }
                }
                else MessageBox.Show("You should add workout parameters first");

            }
        }

        private bool CanExecute()
        {
            return !String.IsNullOrWhiteSpace(Diete);
        }

        private void Execute()
        {
            DayToAdd = new PersonTreningDaySet(SelectedDate, Diete, SelectedPerson.Id, Wage, WorkOut, Suplementation);
            using (WorkOut2Container contex = new Models.WorkOut2Container())
            {
                try
                {
                    contex.PersonTreningDaySetSet.Add(DayToAdd);
                    contex.SaveChanges();
                    MessageBox.Show("Workout was added if you want add to this workout picture press add picture!");
                    
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.InnerException.Message);
                }
            }
        }
      

    }
}
