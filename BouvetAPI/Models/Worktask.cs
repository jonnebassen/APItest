namespace BouvetAPI.Models
{
    public class Worktask
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Responsible { get; set; }

        public long EpicId { get; set; }

    }
}
