namespace BouvetAPI.Models
{
    public class Epic
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public long ProjectId { get; set; }

        public List<Worktask>? Worktasks { get; set; }
    }
}