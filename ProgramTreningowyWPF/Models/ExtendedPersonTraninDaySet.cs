using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ProgramTreningowyWPF.Models
{
  public  class ExtendedPersonTraninDaySet:PersonTreningDaySet
    {
        public ExtendedPersonTraninDaySet(DateTime? date, string diet, int personSetId, double? weight, string exercises, string supplementation, BitmapImage image/*List<BitmapImage> listOfImages*/)
            :base(date,diet,personSetId,weight,exercises,supplementation)
        {
            Image = image;
           // ListOfImages = listOfImages;
        }

        public BitmapImage Image { get; set; }
        // public List<BitmapImage> ListOfImages { get; set; }
    }
}
