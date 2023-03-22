using BouvetAPI.Models;
using BouvetAPI.Models.DTO;
using System.Threading.Tasks;

namespace BouvetAPI.Services
{
    public interface IScrumBoard
    {
        Task<List<ProjectDTO>> GetProjectsAsync();
        Task<ProjectDTO> GetProjectAsync(long id);
        Task<ProjectDTO> AddProjectAsync(ProjectDTO projectDTO);
        Task<ProjectDTO> UpdateProjectAsync(long id, ProjectDTO projectDTO);
        Task<(bool, string)> DeleteProjectAsync(long id);


        Task<List<Epic>> GetEpicsAsync();
        Task<Epic> GetEpicAsync(long id);
        Task<Epic> AddEpicAsync(Epic epic);
        Task<Epic> UpdateEpicAsync(long id, Epic epic);
        Task<(bool, string)> DeleteEpicAsync(Epic epic);


        Task<List<Worktask>> GetWorktasksAsync();
        Task<Worktask> GetWorktaskAsync(long id);
        Task<Worktask> AddWorktaskAsync(Worktask worktask);
        Task<Worktask> UpdateWorktaskAsync(long id, Worktask worktask);
        Task<(bool, string)> DeleteWorktaskAsync(Worktask worktask);
    }
}
