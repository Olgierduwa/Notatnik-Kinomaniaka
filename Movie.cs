using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinemanote
{
    public class Movie
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public decimal Duration { get; set; }
        public string ReleaseDate { get; set; }
        public string ImagePath { get; set; }
        public string Review { get; set; }

        private List<int> Ratings;
        private List<string> CategoriesList;
        public string Categories
        {
            get
            {
                string cat = "";
                foreach (string c in CategoriesList) cat = cat + c + "\n";
                return cat;
            }
        }
        public double YourRate { get; set; }
        public double Rate { get; set; }
        public bool Rated { get; set; }
        public bool? Watched { get; set; }
        public bool? Favorite { get; set; }
        public bool Premiere { get; set; }
        public bool Scheduled { get; set; }
        public int[] ScheduleDate { get; set; }
        public int ScheduleRemindTimes { get; set; }
        public int ScheduleRemindWhen { get; set; }


        public Movie(string title, string director, decimal duration, string releaseDate, List<string> categories,
                    bool? watched = false, bool? favorite = false)
        {
            Title = title;
            Director = director;
            Duration = duration;
            ReleaseDate = releaseDate;
            ImagePath = title + ".jpg";

            Ratings = new List<int>();
            Review = "";
            YourRate = 50;
            CategoriesList = categories;
            Watched = watched;
            Favorite = favorite;
            ScheduleDate = new int[3];
            ScheduleRemindTimes = 0;
            ScheduleRemindWhen = 0;
            Scheduled = false;
            SetRate();
            Rated = false;
            if (duration == 0) Premiere = true;
            else Premiere = false;
        }

        public void AddRatings(List<int> ratings)
        {
            for (int i = 0; i < ratings.Count; i++)
                Ratings.Add(ratings[i]);
        }
        public void AddCategories(List<string> categories)
        {
            for (int i = 0; i < categories.Count; i++)
                CategoriesList.Add(categories[i]);
        }
        public bool FindCategory(string category)
        {
            return CategoriesList.Contains(category);
        }
        public void SetRate()
        {
            double sum = 0;
            foreach (int rate in Ratings) sum += rate;
            sum += YourRate;
            int count = 0;
            if (Rated == true) count = 1;
            if (Ratings.Count + count == 0) Rate = 0;
            else Rate = (sum / (Ratings.Count + count)/10);
        }
    }
}
