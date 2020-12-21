using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Laboratory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int attemptCounter = 0;
        private Logic.CaptchaHelper captchaHelper = new Logic.CaptchaHelper();

        public MainWindow()
        {
            InitializeComponent();
            string pathImage = System.IO.Path.GetFullPath("..\\..\\Resources");
            showPassImg.Source = new BitmapImage(new Uri($"{pathImage}\\eye.png"));
            reloadCaptchaImg.Source = new BitmapImage(new Uri($"{pathImage}\\reload.png"));
            authorizationBtn.Background = new SolidColorBrush(Color.FromRgb(73, 140, 81));
            showPassBtn.Background = new SolidColorBrush(Color.FromRgb(73, 140, 81));
            reloadCaptchaBtn.Background = new SolidColorBrush(Color.FromRgb(73, 140, 81));

            captchaHelper.GetCaptcha(200, 60);
            captchaImg.Source = captchaHelper.captchaImage;
        }

        private void MainWindow_Load(object sender, RoutedEventArgs e)
        {
            loginTxtBx.Focus();
        }

        private void EnterTheCabinet(DataBase.User user)
        {
            switch (user.Role)
            {
                case 1:
                    Windows.AdminWindow adminWindow = new Windows.AdminWindow(user);
                    adminWindow.Title = $"Admin({user.Login})";
                    Close();
                    adminWindow.Show();
                    break;
                case 2:
                    Windows.BookerWindow bookerWindow = new Windows.BookerWindow();
                    bookerWindow.Title = $"Booker({user.Login})";
                    Close();
                    bookerWindow.Show();
                    break;
                case 3:
                    Windows.LaborantWindow laborantWindow = new Windows.LaborantWindow();
                    laborantWindow.Title = $"Laborant({user.Login})";
                    Close();
                    laborantWindow.Show();
                    break;
                case 4:
                    Windows.SearcherWindow searcherWindow = new Windows.SearcherWindow();
                    searcherWindow.Title = $"Searcher({user.Login})";
                    Close();
                    searcherWindow.Show();
                    break;
                case 5:
                    Windows.PatientWindow patientWindow = new Windows.PatientWindow();
                    patientWindow.Title = $"Patient({user.Login})";
                    Close();
                    patientWindow.Show();
                    break;
            }
        }

        public void BlockingEntrance(int time)
        {
            IsEnabled = false;
            MessageBox.Show($"Вы заблокированы на {time} минут", "Блокировка");
            System.Threading.Thread.Sleep(time * 60000);
            IsEnabled = true;
        }

        private void AuthorizationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(loginTxtBx.Text) && (!string.IsNullOrEmpty(passwordTxtBx.Text) || !string.IsNullOrEmpty(passwordPswrdBx.Password)))
            {
                if (attemptCounter == 2 && captchaTxtBx.Text != captchaHelper.captchaText)
                {
                    BlockingEntrance(1);
                    return;
                }
                
                DataBase.User authorization;
                if (passwordPswrdBx.Visibility == Visibility.Hidden)
                    authorization = Logic.DBQuery.Authorization(loginTxtBx.Text, passwordTxtBx.Text);
                else
                    authorization = Logic.DBQuery.Authorization(loginTxtBx.Text, passwordPswrdBx.Password);

                if (authorization == null)
                    MessageBox.Show("В данный момент сервер недоступен!", "Ошибка сервера");
                else if (authorization.Login == null)
                {
                    if (attemptCounter == 2)
                    {
                        BlockingEntrance(1);
                        return;
                    }
                    MessageBox.Show("Такой записи не существует! Проверьте ваши данные", "Отсутствие данных");
                    attemptCounter++;
                }
                else
                {
                    var line = Logic.DBQuery.AddLoginHistory(authorization.Id);
                    if (line == null)
                        EnterTheCabinet(authorization);
                    else
                        MessageBox.Show(line.Message, "Ошибка");
                }

                if (attemptCounter == 2)
                {
                    captchaImg.Visibility = Visibility.Visible;
                    reloadCaptchaBtn.Visibility = Visibility.Visible;
                    captchaTxtBx.Visibility = Visibility.Visible;
                }
            }
            else
                MessageBox.Show("Сначала заполните все поля!", "Ошибка заполнения");
        }

        private void ShowPassBtn_Click(object sender, RoutedEventArgs e)
        {
            if (passwordPswrdBx.Visibility == Visibility.Visible)
            {
                passwordPswrdBx.Visibility = Visibility.Hidden;
                passwordTxtBx.Visibility = Visibility.Visible;
                passwordTxtBx.Text = passwordPswrdBx.Password;
            }
            else
            {
                passwordPswrdBx.Visibility = Visibility.Visible;
                passwordTxtBx.Visibility = Visibility.Hidden;
                passwordPswrdBx.Password = passwordTxtBx.Text;
            }
        }

        private void ReloadCaptchaBtn_Click(object sender, RoutedEventArgs e)
        {
            captchaHelper.GetCaptcha(200, 60);
            captchaImg.Source = captchaHelper.captchaImage;
        }
    }
}
