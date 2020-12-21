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
using System.Windows.Shapes;

namespace Laboratory.Windows
{
    /// <summary>
    /// Interaction logic for NewOrderWindow.xaml
    /// </summary>
    public partial class NewOrderWindow : Window
    {
        private List<int> listOfIdServices = new List<int>();

        public NewOrderWindow()
        {
            InitializeComponent();
            servicesDtGrd.ItemsSource = Logic.DBQuery.GetListOfSerivces();
            
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            //servicesDtGrd.
        }

        private void SelectChckBx_Checked(object sender, RoutedEventArgs e)
        {
            var res = servicesDtGrd.SelectedItem;
            


        }
    }
}
