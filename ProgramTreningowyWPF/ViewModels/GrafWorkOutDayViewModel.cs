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
using System.Windows.Media.Imaging;
using System.IO;
using Prism.Commands;

namespace ProgramTreningowyWPF.ViewModels
{
    class GrafWorkOutDayViewModel : BindableBase
    {

       private int howManyImage;
        private int _howManyImage;
      private  int firstIdOfImage;
        private int _firstIdOfImage;
        public DelegateCommand ChangeImage{ get; set; }
       private ExtendedPersonTraninDaySet tmp;
        //Test
        private BitmapImage _convertetPhoto; //właściwość prismowa
        public BitmapImage ConvertetPhoto
        {
            get { return _convertetPhoto; }

            set { SetProperty(ref _convertetPhoto, value); }

        }


        private  byte[] _photo; //właściwość prismowa
        public byte[] Photo
        {
            get { return  _photo; }

            set { SetProperty(ref _photo, value); }

        }

        private PersonTreningDaySet _selectedDay; //właściwość prismowa
        public PersonTreningDaySet SelectedDay
        {
            get { return _selectedDay; }

            set { SetProperty(ref _selectedDay, value); }

        }

        private PersonSet _selectedPerson; //właściwość prismowa
        public PersonSet SelectedPerson
        {
            get { return _selectedPerson; }

            set { SetProperty(ref _selectedPerson, value); }

        }

        public GrafWorkOutDayViewModel(IEventAggregator eventAggregator)
        {

            eventAggregator.GetEvent<WorkOutDayEvent>().Subscribe(UpdateDay); //przyjmujemy wartośc wyslaną przez eventaggregatro
            eventAggregator.GetEvent<PersonEvent>().Subscribe((obj) => SelectedPerson = (PersonSet)obj);
            GrafData = new ObservableCollection<KeyValuePair<string, double?>>();
            ChangeImage = new DelegateCommand(Execute, CanExecute);

        }

        private bool CanExecute()
        {
            return true;
        }

        private void Execute()
        {
            
            Values = new ObservableCollection<ExtendedPersonTraninDaySet>();
            if (_howManyImage > 1)
            {

                using (Models.WorkOut2Container contex = new Models.WorkOut2Container())
                {
                    if (_howManyImage > 0)
                    {
                        _firstIdOfImage++;
                        var imageToShow = (from c in contex.PersonPhotoSetSet where c.PersonTreningDaySetId == SelectedDay.Id && c.Id == _firstIdOfImage select c.Photo).FirstOrDefault();
                        ConvertetPhoto = this.LoadImage(imageToShow);
                        tmp = new ExtendedPersonTraninDaySet(SelectedDay.Date, SelectedDay.Diet, SelectedDay.PersonSetId, SelectedDay.Weight, SelectedDay.Exercises, SelectedDay.Supplementation, ConvertetPhoto);
                        Values.Add(tmp);
                        _howManyImage--;
                    }

                }
            }
            else
            {
                _howManyImage = howManyImage;
                _firstIdOfImage = firstIdOfImage;
                Values = new ObservableCollection<ExtendedPersonTraninDaySet>();//wreszcie sukces ;)
                Photo = SelectedDay.PersonPhotoSet.FirstOrDefault().Photo;
                ConvertetPhoto = this.LoadImage(Photo);
                tmp = new ExtendedPersonTraninDaySet(SelectedDay.Date, SelectedDay.Diet, SelectedDay.PersonSetId, SelectedDay.Weight, SelectedDay.Exercises, SelectedDay.Supplementation, ConvertetPhoto);
                Values.Add(tmp);
            }
        }

        private void UpdateDay(PersonTreningDaySet obj)//super metodka która trigeruje się za każdym razem jak jest zmiana na dacie
        {

            SelectedDay = (PersonTreningDaySet)obj;

            using (Models.WorkOut2Container contex = new Models.WorkOut2Container())
            {
                firstIdOfImage = (from c in contex.PersonPhotoSetSet where c.PersonTreningDaySetId == SelectedDay.Id select c.Id).FirstOrDefault();
                howManyImage = (from c in contex.PersonPhotoSetSet where c.PersonTreningDaySetId == SelectedDay.Id select c.Id).Count();
                _howManyImage = howManyImage;
                _firstIdOfImage = firstIdOfImage;
            }
           
            Values = new ObservableCollection<ExtendedPersonTraninDaySet>();//wreszcie sukces ;)
          
            if (SelectedDay.PersonPhotoSet.FirstOrDefault()!= null)
            {
               Photo = SelectedDay.PersonPhotoSet.FirstOrDefault().Photo;
                 ConvertetPhoto = this.LoadImage(Photo);
                
              tmp = new ExtendedPersonTraninDaySet(SelectedDay.Date,SelectedDay.Diet,SelectedDay.PersonSetId, SelectedDay.Weight,SelectedDay.Exercises,SelectedDay.Supplementation, ConvertetPhoto);
            Values.Add(tmp);

            }

            tmp = new ExtendedPersonTraninDaySet(SelectedDay.Date, SelectedDay.Diet, SelectedDay.PersonSetId, SelectedDay.Weight, SelectedDay.Exercises, SelectedDay.Supplementation, null);
            Values.Add(tmp);
            using (Models.WorkOut2Container contex = new Models.WorkOut2Container())
            {
                var listForGraf = (from c in contex.PersonNoTreningDaySetSet where c.PersonSetId == SelectedPerson.Id select c);
               var listForGraf1 = (from c in contex.PersonTreningDaySetSet where c.PersonSetId == SelectedPerson.Id select c);
                Dictionary<string, double?> dictionary = new Dictionary<string, double?>();

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


        private ObservableCollection<ExtendedPersonTraninDaySet> values; //lista w której przechowywane sa obiekty przekazane w maina i jest połączona z dataGrid 

        public ObservableCollection<ExtendedPersonTraninDaySet> Values
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

        private  BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }


    }
}
