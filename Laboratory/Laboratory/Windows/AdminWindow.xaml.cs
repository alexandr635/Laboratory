using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Laboratory.Windows
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private DataBase.User currentUser;
        public AdminWindow(DataBase.User user)
        {
            InitializeComponent();
            currentUser = user;
            adminGrid.Background = new SolidColorBrush(Color.FromRgb(118, 227, 131));
            adminImg.Source = new BitmapImage(new Uri(System.IO.Path.GetFullPath("..\\..\\Resources\\Администратор.png")));
            backBtn.Background = new SolidColorBrush(Color.FromRgb(73, 140, 81));
            showHistoryBtn.Background = new SolidColorBrush(Color.FromRgb(73, 140, 81));
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            Close();
            mainWindow.Show();
        }

        private void ShowHistoryBtn_Click(object sender, RoutedEventArgs e)
        {
            ShowHistoryLoginWindow window = new ShowHistoryLoginWindow(currentUser);
            window.Title = $"Admin({currentUser.Login})";
            Close();
            window.Show();
        }

        private void AdminWindow_Load(object sender, RoutedEventArgs e)
        {
            showHistoryBtn.Focus();
        }
    }
}
