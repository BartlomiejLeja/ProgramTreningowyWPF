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
using System.Data.SqlClient;
using System.Data;
using System.Windows.Controls.DataVisualization.Charting;
using Microsoft.Win32;


namespace ProgramTreningowyWPF.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       // Zarzadca Z = new Zarzadca();
       // public List<p> ListTab = new List<p>();
       //private p ShowDay;
        //SqlConnection cn;
        //SqlDataAdapter da;
        //DataSet ds;
        public MainWindow()
        {
          
            InitializeComponent();
            //z.Children.Clear();
            ////DzienNieTreningowy DNT = new DzienNieTreningowy();
            //if (!z.Children.Contains(Graf.Instance))
            //{

            //    z.Children.Add(Graf.Instance);
            //}

            //cn = new SqlConnection(@"Data Source=bartekleja.database.windows.net;Initial Catalog=WorkOut;Persist Security Info=True;User ID=BartlomiejLeja;Password=Sim13vetson!");
            //cn.Open();
            //da = new SqlDataAdapter("Select *from p", cn);
            //ds = new DataSet();
            //da.Fill(ds);
            //dataGrid.ItemsSource = ds.Tables[0].DefaultView;
            //cn.Close();
        }

      

        private void MainCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
          
      // ListTab.Clear();
        
      //DateTime r = MainCalendar.SelectedDate.Value;
            
      //  ShowDay = Z.SerchForView(Z.SelectedDate);
      // ListTab.Add(ShowDay);
      //  CollectionViewSource itemCollectionViewSource;
      //  itemCollectionViewSource = (CollectionViewSource)(FindResource("ItemCollectionViewSource"));
      //    itemCollectionViewSource.Source = ListTab;
      //     dataGrid.Items.Refresh();

        }
    }
}
