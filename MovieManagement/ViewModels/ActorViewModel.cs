namespace MovieManagement.ViewModels
{
    public class ActorViewModel
    {
        public string Movie { get; set; }
        public string Company { get; set; }

        public ActorViewModel(string movie, string company)
        {
            Movie = movie;            
            Company = company;
        }
    }
}
