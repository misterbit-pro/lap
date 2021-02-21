namespace MovieManagement.Database
{
    public partial class MovieActor
    {
        public int MovActId { get; set; }
        public int MovId { get; set; }
        public int ActId { get; set; }

        public virtual Actor Act { get; set; }
        public virtual Movie Mov { get; set; }
    }
}
