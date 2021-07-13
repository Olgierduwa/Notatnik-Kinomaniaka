using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cinemanote
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Movie> Movies = new List<Movie>();
        private List<string> Categories = new List<string>();
        private List<string> Sorts = new List<string>();
        private ListCollectionView View { get { return (ListCollectionView)CollectionViewSource.GetDefaultView(Movies); } }
        public MainWindow()
        {
            InitializeComponent();

            Movies.Add(new Movie("Buntownik z wyboru", "Gus Van Sant", 121, "1997-12-02", new List<string> { "Dramatyczne", "Obyczajowe" }));
            Movies.Add(new Movie("Gladiator", "Ridley Scott", 155, "2000-05-05", new List<string> { "Dramatyczne", "Historyczne" }));
            Movies.Add(new Movie("Chłopaki nie płaczą", "Olaf Lubaszenko", 100, "2000-02-25", new List<string> { "Komediowe", "Sensacyjne" }));
            Movies.Add(new Movie("Kobiety mafii", "Patryk Vega", 138, "2018-02-20", new List<string> { "Sensacyjne" }));
            Movies.Add(new Movie("Parasite", "Joon-ho Bong", 132, "2019-05-21", new List<string> { "Komediowe", "Dramatyczne" }));
            Movies.Add(new Movie("Nie czas umierać", "Cary Joji Fukunaga", 0, "2021-04-02", new List<string> { "Sensacyjne", "Akcji" }));
            Movies.Add(new Movie("Czarna Wdowa", "Cate Shortland", 0, "2021-05-07", new List<string> { "Sci-Fi", "Akcji" }));
            Movies.Add(new Movie("Joker", "Todd Phillips", 122, "2019-08-31", new List<string> { "Dramatyczne", "Psychologiczne" }));
            Movies.Add(new Movie("Full Metal Jacket", "Stanley Kubrick", 116, "1998-06-17", new List<string> { "Wojenne", "Dramatyczne" }));
            Movies.Add(new Movie("Ojciec chrzestny", "Francis Ford Coppola", 175, "1972-03-15", new List<string> { "Gangsterskie", "Dramatyczne" }));
            Movies.Add(new Movie("Zielona mila", "Frank Darabont", 188, "1999-12-06", new List<string> { "Dramatyczne" }));
            Movies.Add(new Movie("Spirited Away: W krainie Bogów", "Hayao Miyazaki", 125, "2001-07-20", new List<string> { "Fantasy", "Przygodowe", "Anime" }));
            Movies.Add(new Movie("Pulp Fiction", "Quentin Tarantino", 154, "1994-05-12", new List<string> { "Gangsterskie", "Komediowe" }));
            Movies.Add(new Movie("Skazani na Shawshank", "Frank Darabont", 142, "1994-09-10", new List<string> { "Dramatyczne" }));
            Movies.Add(new Movie("Lśnienie", "Stanley Kubrick", 146, "1980-05-23", new List<string> { "Horrory" }));
            Movies.Add(new Movie("Mój sąsiad Totoro", "Hayao Miyazaki", 85, "1988-04-16", new List<string> { "Fantasy", "Anime" }));
            Movies.Add(new Movie("Taksówkarz", "Martin Scorsese", 113, "1976-02-07", new List<string> { "Dramatyczne" }));
            Movies.Add(new Movie("Shrek", "Andrew Adamson", 90, "2001-04-22", new List<string> { "Animowane", "Familijne", "Komediowe" }));
            Movies.Add(new Movie("American Beauty", "Sam Mendes", 122, "1999-09-08", new List<string> { "Dramatyczne", "Komediowe" }));
            Movies.Add(new Movie("Mulan", "Barry Cook", 88, "1998-06-05", new List<string> { "Animowane", "Familijne", "Przygodowe" }));
            Movies.Add(new Movie("Boże Ciało", "Jan Komasa", 115, "2019-07-29", new List<string> { "Obyczajowe", "Dramatyczne", "Psychologiczne" }));
            Movies.Add(new Movie("W głowie się nie mieści", "Pete Docter", 94, "2015-05-18", new List<string> { "Animowane", "Komediowe", "Familijne" }));
            Movies.Add(new Movie("Wilk z Wall Street", "Martin Scorsese", 179, "2013-12-17", new List<string> { "Biograficzne", "Komediowe", "Dramatyczne", "Kryminalne" }));
            Movies.Add(new Movie("Kiler", "Juliusz Machulski", 104, "1997-11-17", new List<string> { "Komediowe", "Sensacyjne" }));
            Movies.Add(new Movie("Złap mnie jeśli potrafisz", "Steven Spielberg", 141, "2002-12-16", new List<string> { "Komediowe", "Kryminalne" }));
            Movies.Add(new Movie("Diuna", "Denis Villenueve", 0, "2021-10-01", new List<string> { "Sci-Fi" }));
            Movies.Add(new Movie("Jojo Rabbit", "Taika Waititi", 108, "2019-09-08", new List<string> { "Dramatyczne", "Komediowe", "Wojenne" }));
            Movies.Add(new Movie("King's Man: Pierwsza misja", "Matthew Vaughn", 0, "2021-02-12", new List<string> { "Akcji", "Komediowe", "Kryminalne" }));
            Movies.Add(new Movie("Na rauszu", "Thomas Vinterberg", 0, "2021-01-22", new List<string> { "Dramatyczne", "Komediowe" }));
            Movies.Add(new Movie("Chłopcy z ferajny", "Martin Scorsese", 146, "1990-09-12", new List<string> { "Dramatyczne", "Gangsterskie" }));

            Categories.Add("Horrory");
            Categories.Add("Dramatyczne");
            Categories.Add("Przygodowe");
            Categories.Add("Gangsterskie");
            Categories.Add("Komediowe");
            Categories.Add("Fantasy");
            Categories.Add("Animowane");
            Categories.Add("Anime");
            Categories.Add("Wojenne");
            Categories.Add("Familijne");
            Categories.Add("Akcji");
            Categories.Add("Kryminalne");
            Categories.Add("Biograficzne");
            Categories.Add("Psychologiczne");
            Categories.Add("Historyczne");
            Categories.Add("Sensacyjne");
            Categories.Add("Obyczajowe");
            Categories.Add("Sci-Fi");
            Categories.Add("Gangsterskie");

            Sorts.Add("wg Tytułu");
            Sorts.Add("wg Oceny");

            combo_sort.ItemsSource = Sorts;
            filtr_category.ItemsSource = Categories;
            lista.ItemsSource = Movies;
        }
        private void SelectionListItem(object sender, SelectionChangedEventArgs e)
        {
            var movie = lista.SelectedItem as Movie;

            if (movie != null)
            {
                if (movie.Scheduled == false) ScheduleButton.Content = "Zaplanuj Oglądanie";
                else ScheduleButton.Content = "Zarządzaj Planem";
                if (movie.Rated == false) RateButton.Content = "Oceń Produkcję";
                else RateButton.Content = "Zarządzaj Oceną";
                MovieRate.Content = movie.Rate.ToString();
                if (movie.Duration > 0)
                {
                    check_watched.IsEnabled = true;
                    check_favorite.IsEnabled = true;
                    check_watched.IsChecked = movie.Watched;
                    check_favorite.IsChecked = movie.Favorite;
                    RateButton.IsEnabled = true;
                }
                else
                {
                    check_watched.IsChecked = movie.Watched;
                    check_favorite.IsChecked = movie.Favorite;
                    check_watched.IsEnabled = false;
                    check_favorite.IsEnabled = false;
                    RateButton.IsEnabled = false;
                }
            }
        }


        private void Filtrowanie(object sender, RoutedEventArgs e) { UstawFiltr(); }
        private void Filtrowanie(object sender, SelectionChangedEventArgs e) { UstawFiltr(); }
        private void UstawFiltr()
        {
            View.Filter = delegate (object item)
            {
                bool cat = true, dir = true, prem = true, fav = true, wat = true, sche = true;
                Movie movie = item as Movie;
                if (movie != null)
                {
                    if (filtr_director.Text != "" && movie.Director != filtr_director.Text) dir = false;
                    if (filtr_category.SelectedItem != null && movie.FindCategory(filtr_category.SelectedItem.ToString()) == false) cat = false;
                    if (filtr_premiere.IsChecked == true && movie.Duration != 0) prem = false;
                    if (filtr_favorite.IsChecked == true && movie.Favorite == false) fav = false;
                    if (filtr_watched.IsChecked == true && movie.Watched == false) wat = false;
                    if (filtr_scheduled.IsChecked == true && movie.Scheduled == false) sche = false;
                    return (dir == true && cat == true && prem == true && fav == true && wat == true && sche == true);
                }
                return false;
            };
        }
        private void WyczyscFiltr(object sender, RoutedEventArgs e)
        {
            View.Filter = delegate (object item) { return true; };
            filtr_category.SelectedItem = null;
            filtr_director.Text = "";
            filtr_premiere.IsChecked = false;
            filtr_watched.IsChecked = false;
            filtr_favorite.IsChecked = false;
            filtr_scheduled.IsChecked = false;
        }
        private void Sortowanie(object sender, SelectionChangedEventArgs e)
        {
            string sort = combo_sort.SelectedItem.ToString();

            switch (sort)
            {
                case "wg Tytułu":
                    View.SortDescriptions.Clear();
                    View.CustomSort = null;
                    View.SortDescriptions.Add(new SortDescription("Title", ListSortDirection.Ascending));
                    break;

                case "wg Oceny":
                    View.GroupDescriptions.Clear();
                    View.CustomSort = null;
                    View.SortDescriptions.Add(new SortDescription("Rate", ListSortDirection.Descending));
                    break;
            }
        }
        private void ResetCategory(object sender, RoutedEventArgs e)
        {
            filtr_category.SelectedItem = null;
        }
        private void ResetDirector(object sender, RoutedEventArgs e)
        {
            filtr_director.Text = "";
        }


        private void CheckFavorite(object sender, RoutedEventArgs e)
        {
            var movie = lista.SelectedItem as Movie;
            movie.Favorite = check_favorite.IsChecked;
            if (movie.Favorite == true)
            {
                movie.Watched = true;
                check_watched.IsChecked = true;
            }
        }
        private void CheckWatched(object sender, RoutedEventArgs e)
        {
            var movie = lista.SelectedItem as Movie;
            movie.Watched = check_watched.IsChecked;
            if (movie.Watched == false)
            {
                movie.Favorite = false;
                check_favorite.IsChecked = false;
            }
        }
        private void ScheduledWatching(object sender, RoutedEventArgs e)
        {
            ScheduleWindow window = new ScheduleWindow((Movie)lista.SelectedItem);
            window.Owner = this;
            Movie movie = lista.SelectedItem as Movie;
            if (window.ShowDialog() == true)
            {
                movie.Scheduled = window.movie.Scheduled;
                movie.ScheduleDate = new int[] { window.movie.ScheduleDate[0], window.movie.ScheduleDate[1], window.movie.ScheduleDate[2] };
                movie.ScheduleRemindTimes = window.movie.ScheduleRemindTimes;
                movie.ScheduleRemindWhen = window.movie.ScheduleRemindWhen;

                if (movie.Scheduled == false) ScheduleButton.Content = "Zaplanuj Oglądanie";
                else ScheduleButton.Content = "Zarządzaj Planem";

                lista.Items.Refresh();
            }
        }
        private void RateTheMovie(object sender, RoutedEventArgs e)
        {
            RateWindow window = new RateWindow((Movie)lista.SelectedItem);
            window.Owner = this;
            Movie movie = lista.SelectedItem as Movie;
            if (window.ShowDialog() == true)
            {
                movie.Review = window.movie.Review;
                movie.YourRate = window.movie.YourRate;
                movie.Rated = window.movie.Rated;
                if (movie.Rated == false) RateButton.Content = "Oceń Produkcję";
                else RateButton.Content = "Zarządzaj Oceną";
                movie.SetRate();
                MovieRate.Content = movie.Rate.ToString();
            }
        }
        private void Hide(object sender, RoutedEventArgs e) { lista.SelectedItem = null; }
    }
}
