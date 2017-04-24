using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Unity; //ważne
using System.Windows;
using ProgramTreningowyWPF.Views;
using Microsoft.Practices.Unity;
using Prism.Regions;

namespace ProgramTreningowyWPF
{
    public class Bootstrapper:UnityBootstrapper
    {
     
        protected override DependencyObject CreateShell() // tworzymy początek apki co się bedzie wyświetlało powłoke
        {
            return Container.Resolve<MainWindow>(); //pierwsze co się wyświetla View MainWindow
           
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();//Pokazuje MainWindow
            
         
        }

        protected override void ConfigureContainer() //zarządznie kontenerami co kolwiek to znaczy
        {
            base.ConfigureContainer();
           
            Container.RegisterTypeForNavigation<DzienNieTreningowy>("DzienNieTreningowy");//rejestrujemy View DzienNieTreningowy
            Container.RegisterTypeForNavigation<DzienTreningowy>("DzienTreningowy");//rejestrujemy View DzienTreningowy
            Container.RegisterTypeForNavigation<Graf>("Graf");//rejestrujemy View Graf
            Container.RegisterTypeForNavigation<Login>("Login");//rejestrujemy View Graf
            Container.RegisterTypeForNavigation<Registeration>("Registeration");//rejestrujemy View Graf
            Container.RegisterTypeForNavigation<GrafWorkOutDay>("GrafWorkOutDay");//rejestrujemy View Graf
            Container.RegisterTypeForNavigation<MainWindow>("MainWindow");

        }
    }

    
}
