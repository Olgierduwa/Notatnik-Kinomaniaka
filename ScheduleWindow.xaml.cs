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

namespace Cinemanote
{
    /// <summary>
    /// Logika interakcji dla klasy ScheduleWindow.xaml
    /// </summary>
    public partial class ScheduleWindow : Window
    {
        public Movie movie;
        public List<int> YearItem = new List<int>();
        public List<int> MonthItem = new List<int>();
        public List<int> DayItem = new List<int>();
        public List<string> When = new List<string>();
        public List<string> Times = new List<string>();
        public ScheduleWindow(Movie movie)
        {
            InitializeComponent();

            When.Add("1 Dzień Wcześniej");
            When.Add("2 Dni Wcześniej");
            When.Add("3 Dni Wcześniej");

            Times.Add("0 Razy");
            Times.Add("1 Raz");
            Times.Add("2 Razy");
            Times.Add("3 Razy");

            when_box.ItemsSource = When;
            times_box.ItemsSource = Times;
            Title.Content = movie.Title;

            this.movie = movie;
            SetDate(0);
            YearBox.SelectedItem = movie.ScheduleDate[0];
            MonthBox.SelectedItem = movie.ScheduleDate[1];
            DayBox.SelectedItem = movie.ScheduleDate[2];

            if (movie.ScheduleRemindTimes != 0)
            {
                check_remind.IsChecked = true;
                when_box.SelectedItem = When[movie.ScheduleRemindWhen];
                times_box.SelectedItem = Times[movie.ScheduleRemindTimes];
            }
            else
            {
                when_box.SelectedItem = When[0];
                times_box.SelectedItem = Times[0];
                check_remind.IsChecked = false;
                RemindGroup.IsEnabled = false;
            }

            if(movie.Scheduled == true)
                DeleteButton.Visibility = Visibility.Visible;
            else DeleteButton.Visibility = Visibility.Hidden;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            movie.Scheduled = true;
            movie.ScheduleDate = new int[] { Convert.ToInt32(YearBox.SelectedItem), Convert.ToInt32(MonthBox.SelectedItem), Convert.ToInt32(DayBox.SelectedItem) };
            movie.ScheduleRemindTimes = Convert.ToInt32(times_box.SelectedIndex);
            movie.ScheduleRemindWhen = Convert.ToInt32(when_box.SelectedIndex);
            DialogResult = true;
        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            movie.Scheduled = false;
            movie.ScheduleDate = new int[] { 0, 0, 0 };
            movie.ScheduleRemindTimes = Convert.ToInt32(times_box.SelectedIndex);
            movie.ScheduleRemindWhen = Convert.ToInt32(when_box.SelectedIndex);
            DialogResult = true;
        }
        private void Cancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        private void CheckRemind(object sender, RoutedEventArgs e)
        {
            if (check_remind.IsChecked == true)
            {
                RemindGroup.IsEnabled = true;
                when_box.SelectedItem = When[0];
                times_box.SelectedItem = Times[1];
            }
            else
            {
                when_box.SelectedItem = When[0];
                times_box.SelectedItem = Times[0];
                RemindGroup.IsEnabled = false;
            }
        }

        private void SelectYear(object sender, SelectionChangedEventArgs e) { SetDate(1); }
        private void SelectMonth(object sender, SelectionChangedEventArgs e) { SetDate(2); }
        private void SetDate(int select)
        {
            DateTime now = DateTime.Now;

            if (select == 0)
            {
                YearItem = new List<int>();
                for (int i = 0; i <= 10; i++) YearItem.Add(now.Year + i);
                YearBox.ItemsSource = YearItem;
                YearBox.SelectedIndex = 0;
            }
            if (select == 1)
            {
                if (DateTime.Now.Year != Convert.ToInt32(YearBox.SelectedItem))
                    now = new DateTime(Convert.ToInt32(YearBox.SelectedItem), 1, 1);

                MonthItem = new List<int>();
                for (int i = 0; i <= 12 - now.Month; i++) MonthItem.Add(now.Month + i);
                MonthBox.ItemsSource = MonthItem;
                MonthBox.SelectedIndex = 0;
            }
            if (select == 2)
            {
                if (DateTime.Now.Year != Convert.ToInt32(YearBox.SelectedItem)) // jest wiekszy
                    now = new DateTime(Convert.ToInt32(YearBox.SelectedItem), Convert.ToInt32(MonthBox.SelectedItem), 1);
                else // rok = 2020
                {
                    if (DateTime.Now.Month < Convert.ToInt32(MonthBox.SelectedItem)) // miesiac wiekszy
                        now = new DateTime(Convert.ToInt32(YearBox.SelectedItem), Convert.ToInt32(MonthBox.SelectedItem), 1);
                }

                DayItem = new List<int>();
                for (int i = 0; i <= DateTime.DaysInMonth(now.Year, now.Month) - now.Day; i++) DayItem.Add(now.Day + i);
                DayBox.ItemsSource = DayItem;
                DayBox.SelectedIndex = 0;
            }
        }
    }
}
