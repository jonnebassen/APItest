using Microsoft.EntityFrameworkCore;
using BouvetAPI.Models;
using BouvetAPI.Infrastructure.Contexts;
using BouvetAPI.Models.DTO;

namespace BouvetAPI.Services
{
    public class ScrumBoard : IScrumBoard
    {
        private readonly ProjectContext _db;

        public ScrumBoard(ProjectContext db)
        {
            _db = db;
        }



        public async Task<List<ProjectDTO>> GetProjectsAsync()
        {
            try
            {
                var projects = await _db.Projects.ToListAsync();
                return projects.Select(x => new ProjectDTO(x)).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<ProjectDTO> GetProjectAsync(long id)
        {
            try
            {
                var project = await _db.Projects.Include(x => x.Epics).FirstOrDefaultAsync(i => i.Id == id);
                if (project != null) { return new ProjectDTO(project); }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ProjectDTO> AddProjectAsync(ProjectDTO projectDTO)
        {
            try
            {
                await _db.Projects.AddAsync(new Project(projectDTO));
                await _db.SaveChangesAsync();
                return new ProjectDTO(await _db.Projects.FindAsync(projectDTO.Id));
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ProjectDTO> UpdateProjectAsync(long id, ProjectDTO projectDTO)
        {
            try
            {
                var dbProject = await _db.Projects.FindAsync(id);

                if (dbProject == null)
                {
                    return null;
                }

                dbProject.Name = projectDTO.Name;
                dbProject.Description = projectDTO.Description;
                dbProject.Manager = projectDTO.Manager;
                dbProject.Epics = projectDTO.Epics;

                await _db.SaveChangesAsync();

                return new ProjectDTO(dbProject);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<(bool, string)> DeleteProjectAsync(long id)
        {
            try
            {
                var dbProject = await _db.Projects.FindAsync(id);

                if (dbProject == null)
                {
                    return (false, "Project could not be found");
                }

                _db.Projects.Remove(dbProject);
                await _db.SaveChangesAsync();

                return (true, "Project got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }









        public async Task<List<Epic>> GetEpicsAsync()
        {
            try
            {
                return await _db.Epics.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Epic> GetEpicAsync(long id)
        {
            try
            {
                return await _db.Epics.Include(x => x.Worktasks).FirstOrDefaultAsync(i => i.Id == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Epic> AddEpicAsync(Epic epic)
        {
            try
            {
                await _db.Epics.AddAsync(epic);
                await _db.SaveChangesAsync();
                return await _db.Epics.FindAsync(epic.Id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Epic> UpdateEpicAsync(long id, Epic epic)
        {
            try
            {
                var dbEpic = await _db.Epics.FindAsync(id);

                if (dbEpic == null)
                {
                    return null;
                }

                dbEpic.Name = epic.Name;
                dbEpic.Description = epic.Description;
                dbEpic.ProjectId = epic.ProjectId;
                dbEpic.Worktasks = epic.Worktasks;

                await _db.SaveChangesAsync();

                return epic;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<(bool, string)> DeleteEpicAsync(Epic epic)
        {
            try
            {
                var dbEpic = await _db.Epics.FindAsync(epic.Id);

                if (dbEpic == null)
                {
                    return (false, "Epic could not be found");
                }

                _db.Epics.Remove(epic);
                await _db.SaveChangesAsync();

                return (true, "Epic got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }








        public async Task<List<Worktask>> GetWorktasksAsync()
        {
            try
            {
                return await _db.Worktasks.ToListAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Worktask> GetWorktaskAsync(long id)
        {
            try
            {
                return await _db.Worktasks.FirstOrDefaultAsync(i => i.Id == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Worktask> AddWorktaskAsync(Worktask worktask)
        {
            try
            {
                await _db.Worktasks.AddAsync(worktask);
                await _db.SaveChangesAsync();
                return await _db.Worktasks.FindAsync(worktask);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<Worktask> UpdateWorktaskAsync(long id, Worktask worktask)
        {
            try
            {
                var dbWorktask = await _db.Worktasks.FindAsync(worktask);

                if (dbWorktask == null)
                {
                    return null;
                }

                dbWorktask.Name = worktask.Name;
                dbWorktask.Description = worktask.Description;
                dbWorktask.Responsible = worktask.Responsible;

                await _db.SaveChangesAsync();

                return worktask;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<(bool, string)> DeleteWorktaskAsync(Worktask worktask)
        {
            try
            {
                var dbWorktask = await _db.Worktasks.FindAsync(worktask.Id);

                if (dbWorktask == null)
                {
                    return (false, "Worktask could not be found");
                }

                _db.Worktasks.Remove(worktask);
                await _db.SaveChangesAsync();

                return (true, "Worktask got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }
        }
    }
}
