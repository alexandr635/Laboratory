using System;
using System.Windows;
using System.Windows.Media;

namespace Laboratory.Windows
{
    /// <summary>
    /// Interaction logic for AddPatientWindow.xaml
    /// </summary>
    public partial class AddPatientWindow : Window
    {
        public DataBase.User newUser;

        public AddPatientWindow()
        {
            InitializeComponent();
            newUser = new DataBase.User();
            newUser.Patient = new DataBase.Patient();

            DataContext = newUser;
            companyCmbBx.ItemsSource = Logic.DBQuery.GetListInsuranceCompany();
            policyTypeCmbBx.ItemsSource = Logic.DBQuery.GetListTypeOfInsurancePolicy();

            addPatientBtn.Background = new SolidColorBrush(Color.FromRgb(73, 140, 81));
            backBtn.Background = new SolidColorBrush(Color.FromRgb(73, 140, 81));
        }

        private bool ValidationFields()
        {
            if (string.IsNullOrWhiteSpace(emailTxtBx.Text))
                return false;
            if (string.IsNullOrWhiteSpace(phoneTxtBx.Text))
                return false;
            if (string.IsNullOrWhiteSpace(loginTxtBx.Text))
                return false;
            if (string.IsNullOrWhiteSpace(nameTxtBx.Text))
                return false;
            if (string.IsNullOrWhiteSpace(passwordTxtBx.Text))
                return false;
            if (string.IsNullOrWhiteSpace(seriaTxtBx.Text))
                return false;
            if (string.IsNullOrWhiteSpace(numberTxtBx.Text))
                return false;
            if (string.IsNullOrWhiteSpace(policyNumberTxtBx.Text))
                return false;

            if (companyCmbBx.SelectedIndex == -1)
                return false;
            if (policyTypeCmbBx.SelectedIndex == -1)
                return false;

            if (string.IsNullOrWhiteSpace(dateOfBirtchDtPckr.Text))
                return false;

            return true;
        }

        private void AddPatientBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ValidationFields())
            {
                newUser.Patient.TypeOfPolicy = policyTypeCmbBx.SelectedIndex + 1;
                newUser.Patient.InsuranceCompany = companyCmbBx.SelectedIndex + 1;
                newUser.Role = 5;

                Exception exception = Logic.DBQuery.AddPatient(newUser);
                if (exception == null)
                    MessageBox.Show("Ok");
                else
                    MessageBox.Show(exception.Message, "Ошибка!");
            }
            else
                MessageBox.Show("Сначала заполните все поля!", "Ошибка заполнения");
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
