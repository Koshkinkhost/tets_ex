using Microsoft.EntityFrameworkCore;
using Project_Users_Managers.Data;
using Project_Users_Managers.DTO;
using Project_Users_Managers.Models;

namespace Project_Users_Managers.Repositories
{
    public interface ITaskRepository
    {
        Task<List<TaskDTO>> GetAllTasks();
        Task<bool> DeleteTask(int id);
        Task AddTask(UserTask task);
        Task<UserTask> GetTaskById(int id);
    }
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _appDbContext;
        public TaskRepository(AppDbContext context) { _appDbContext = context; }

        public async Task AddTask(UserTask task)
        {

            await _appDbContext.Tasks.AddAsync(task);
            await _appDbContext.SaveChangesAsync();

        }

        public async Task<bool> DeleteTask(int id)
        {
            var task=await _appDbContext.Tasks.FirstOrDefaultAsync(u=>u.Id==id);
            if (task  is not  null)
            {
                _appDbContext.Tasks.Remove(task);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            return false;

        }

        public async Task<List<TaskDTO>> GetAllTasks()
        {
            return await _appDbContext.Tasks.Select(t=>new TaskDTO
            {
                id = t.Id,
                Date = t.Date,
                TimeSpent=t.TimeSpent,
                Description=t.Description,
                Executor=t.Executor,
                
            }).ToListAsync();    
        }

        public async Task<UserTask> GetTaskById(int id)
        {
           return  await _appDbContext.Tasks.FirstOrDefaultAsync(t => t.Id == id);

        }
    }
}
