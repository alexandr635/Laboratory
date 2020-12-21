using System;
using System.Windows;
using System.Windows.Threading;

namespace Laboratory.Classes
{
    public class Timer
    {
        private DispatcherTimer timer = new DispatcherTimer();
        private DateTime endTime;
        private Windows.LaborantWindow laborantWindow;
        private Windows.SearcherWindow searcherWindow;

        private void UpdateLabel(object sender, EventArgs e)
        {
            var time = endTime - DateTime.Now;
            string result = $"{time.Minutes}:{time.Seconds}";
            if (laborantWindow != null)
                laborantWindow.timerLbl.Content = result;
            else
                searcherWindow.timerLbl.Content = result;

            if (DateTime.Now >= endTime)
            {
                timer.Stop();
                MessageBox.Show("Время сеанса истекло!", "Ограничение времени");
                if (laborantWindow != null)
                    endSession(laborantWindow);
                else
                    endSession(searcherWindow);
            }
            else if (time.Minutes == 5 && time.Seconds == 0)
            {
                MessageBox.Show("Через 5 минут сеанс истечет!", "Ограничение времени");
            }
        }

        private void endSession(Windows.LaborantWindow window)
        {
            MainWindow mainWindow = new MainWindow();
            window.Close();
            mainWindow.Show();
        }

        private void endSession(Windows.SearcherWindow window)
        {
            MainWindow mainWindow = new MainWindow();
            window.Close();
            mainWindow.Show();
        }

        private void setDataTimer()
        {
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += UpdateLabel;
            endTime = DateTime.Now.AddMinutes(10);
            timer.Start();
        }

        public void StartTimer(Windows.LaborantWindow window)
        {
            laborantWindow = window;
            setDataTimer();
        }

        public void StartTimer(Windows.SearcherWindow window)
        {
            searcherWindow = window;
            setDataTimer();
        }
    }
}
