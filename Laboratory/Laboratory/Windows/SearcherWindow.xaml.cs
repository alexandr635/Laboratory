using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Laboratory.Windows
{
    /// <summary>
    /// Interaction logic for Searcher.xaml
    /// </summary>
    public partial class SearcherWindow : Window
    {
        public SearcherWindow()
        {
            InitializeComponent();
            searcherGrid.Background = new SolidColorBrush(Color.FromRgb(118, 227, 131));
            searcherImg.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath("..\\..\\Resources\\laborant_2.png")));

            Classes.Timer timer = new Classes.Timer();
            timer.StartTimer(this);
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }
    }
}
