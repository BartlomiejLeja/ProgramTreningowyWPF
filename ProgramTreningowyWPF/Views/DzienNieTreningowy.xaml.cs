using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgramTreningowyWPF.Views
{
    /// <summary>
    /// Interaction logic for DzienNieTreningowy.xaml
    /// </summary>
    
    public partial class DzienNieTreningowy : UserControl
    {
       Zarzadca Z = new Zarzadca();
        private static DzienNieTreningowy instance;
        public static DzienNieTreningowy Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DzienNieTreningowy();

                }
                return instance;
            }
        }
        public DzienNieTreningowy()
        {
            InitializeComponent();
        }

        private void AddPhoto_Click(object sender, RoutedEventArgs e)
        {
            string myDietaText = new TextRange(RichTextBoxDieta.Document.ContentStart, RichTextBoxDieta.Document.ContentEnd).Text; // aby dostać stringa z richtexboxa
            string myWaga = TextBoxWaga.Text; //żeby dostac czystą wartość stringa
           double numer;
            Double.TryParse(myWaga, out numer);
            DateTime myData=  DataPickerUserControl.SelectedDate.Value.Date;
            //Z.AddRecord( myData,myDietaText,numer) ;
           
        }
    }
}
