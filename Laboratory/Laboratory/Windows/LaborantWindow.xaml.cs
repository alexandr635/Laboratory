using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Laboratory.Windows
{
    /// <summary>
    /// Interaction logic for Laborant.xaml
    /// </summary>
    public partial class LaborantWindow : Window
    {

        public LaborantWindow()
        {
            InitializeComponent();
            laborantGrid.Background = new SolidColorBrush(Color.FromRgb(118, 227, 131));
            laborantImg.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath("..\\..\\Resources\\laborant_1.jpeg")));
  
            Classes.Timer timer = new Classes.Timer();
            timer.StartTimer(this);
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
            mainWindow.Focus();
            //mainWindow.BlockingEntrance(1);
        }

        private void AddPatientBtn_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddPatientWindow window = new AddPatientWindow();
            window.Show();
        }

        private void NewOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            NewOrderWindow newOrderWindow = new NewOrderWindow();
            newOrderWindow.Show();
        }
    }
}
