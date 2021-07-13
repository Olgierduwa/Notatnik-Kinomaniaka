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
    /// Logika interakcji dla klasy RateWindow.xaml
    /// </summary>
    public partial class RateWindow : Window
    {
        public Movie movie;
        public RateWindow(Movie movie)
        {
            InitializeComponent();

            this.movie = movie;
            if(this.movie.Review != "")
            {
                check_remind.IsChecked = true;
                ReviewText.IsEnabled = true;
                ReviewText.Text = this.movie.Review;
            }
            else
            {
                check_remind.IsChecked = false;
                ReviewText.IsEnabled = false;
                ReviewText.Text = "";
            }
            Rate.Value = this.movie.YourRate;
            if (movie.Rated == true) DeleteButton.Visibility = Visibility.Visible;
        }

        private void CheckRemind(object sender, RoutedEventArgs e)
        {
            if (check_remind.IsChecked == true) ReviewText.IsEnabled = true;
            else
            {
                if (ReviewText.Text != "")
                {
                    MessageBoxResult result = MessageBox.Show("Czy chcesz usunąć te opinię?","Twoja Opinia", MessageBoxButton.YesNo);
                    switch(result)
                    {
                        case MessageBoxResult.Yes: ReviewText.Text = ""; ReviewText.IsEnabled = false; break;
                        case MessageBoxResult.No: check_remind.IsChecked = true; break;
                    }
                }
                else ReviewText.IsEnabled = false;
            }
        }
        private void Save(object sender, RoutedEventArgs e)
        {
            movie.Review = ReviewText.Text;
            movie.YourRate = Rate.Value;
            movie.Rated = true;
            DialogResult = true;
        }
        private void Delete(object sender, RoutedEventArgs e)
        {
            movie.Review = "";
            movie.YourRate = 50;
            movie.Rated = false;
            DialogResult = true;
        }
        private void Cancel(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
