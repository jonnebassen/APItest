namespace BouvetAPI.Models.DTO
{
    public class ProjectDTO
    {
        public ProjectDTO(){}
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Manager { get; set; }

        public List<Epic>? Epics { get; set; }

        public ProjectDTO(Project project)
        {
            Id = project.Id;
            Name = project.Name;
            Description = project.Description;
            Manager = project.Manager;
            Epics = project.Epics;
        }
    }
}
