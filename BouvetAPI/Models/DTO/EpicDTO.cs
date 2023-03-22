namespace BouvetAPI.Models.DTO
{
    public class EpicDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public long ProjectId { get; set; }
    }
}
