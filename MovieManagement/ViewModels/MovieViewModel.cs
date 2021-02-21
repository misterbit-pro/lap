using System;

namespace MovieManagement.ViewModels
{
    public class MovieViewModel
    {
        public string Title { get; set; }
        public string Release { get; set; }
        public string Company { get; set; }

        public MovieViewModel(string title, DateTime release, string company)
        {
            Title = title;
            Release = release.ToString("dd.MM.yyyy");
            Company= company;
        }
    }
}
