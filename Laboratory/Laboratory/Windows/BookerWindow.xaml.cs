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
    /// Interaction logic for BookerWindow.xaml
    /// </summary>
    public partial class BookerWindow : Window
    {
        public BookerWindow()
        {
            InitializeComponent(); 
            bookerGrid.Background = new SolidColorBrush(Color.FromRgb(118, 227, 131));
            bookerImg.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath("..\\..\\Resources\\Бухгалтер.jpeg")));
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }
    }
}
