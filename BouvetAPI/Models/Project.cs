using BouvetAPI.Models.DTO;

namespace BouvetAPI.Models
{
    public class Project
    {    
        public Project() { }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Manager { get; set; }

        public List<Epic>? Epics { get; set; }

        public Project(ProjectDTO projectDTO) {
            Id = projectDTO.Id;
            Name = projectDTO.Name;
            Description = projectDTO.Description;
            Manager = projectDTO.Manager;
            Epics = projectDTO.Epics;
        }
    }
    }

