using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Laboratory.Windows
{
    /// <summary>
    /// Interaction logic for ShowHistoryLoginWindow.xaml
    /// </summary>
    public partial class ShowHistoryLoginWindow : Window
    {
        private DataBase.User currentUser;
        public ShowHistoryLoginWindow(DataBase.User user)
        {
            InitializeComponent();
            currentUser = user;
            loginDtGrd.ItemsSource = Logic.DBQuery.GetListOfHistory();
            backBtn.Background = new SolidColorBrush(Color.FromRgb(73, 140, 81));
            sortCmbBx.ItemsSource = new List<string>() { "Id", "Логин", "Дата входа" };
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow(currentUser);
            Close();
            adminWindow.Show();
        }

        private void ShowHistoryLoginWindow_Load(object sender, RoutedEventArgs e)
        {
            backBtn.Focus();
        }

        private void SortCmbBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (sortCmbBx.SelectedIndex)
            {
                case 0:
                    loginDtGrd.ItemsSource = Logic.DBQuery.GetListOfHistory().OrderBy(u => u.IdUser);
                    break;
                case 1:
                    loginDtGrd.ItemsSource = Logic.DBQuery.GetListOfHistory().OrderBy(u => u.User.Login);
                    break;
                case 2:
                    loginDtGrd.ItemsSource = Logic.DBQuery.GetListOfHistory().OrderBy(u => u.LoginDate);
                    break;
            }
        }
    }
}
