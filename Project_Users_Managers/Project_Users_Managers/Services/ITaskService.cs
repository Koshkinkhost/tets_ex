using Project_Users_Managers.DTO;
using Project_Users_Managers.Models;
using Project_Users_Managers.Repositories;
using Project_Users_Managers.Exceptions;
using System;

namespace Project_Users_Managers.Services
{
    public interface IServiceTask
    {
        Task AddTaskAsync(TaskDTO taskDTO);
        Task<bool> DeleteTaskAsyncById(int id);
        Task<List<TaskDTO>> GetAllTasksAsync();
        Task<TaskDTO> GetTaskById(int id);
    }

    public class TaskService : IServiceTask
    {
        private readonly ITaskRepository taskRepository;

        public TaskService(ITaskRepository repository)
        {
            taskRepository = repository;
        }

        public async Task AddTaskAsync(TaskDTO taskDTO)
        {
            if (taskDTO == null)
                throw new InvalidTaskException("Объект задачи не может быть null");


            if (taskDTO.Date != DateOnly.FromDateTime(DateTime.UtcNow))
                throw new InvalidTaskException("Дата должна быть сегодняшней");

            var task = new UserTask
            {
                Executor = "demo",
                Date = taskDTO.Date, 
                TimeSpent = taskDTO.TimeSpent,
                Description = taskDTO.Description
            };

            await taskRepository.AddTask(task);
        }

        public async Task<bool> DeleteTaskAsyncById(int id)
        {

            return await taskRepository.DeleteTask(id);
        }

        public async Task<List<TaskDTO>> GetAllTasksAsync()
        {
            var tasks = await taskRepository.GetAllTasks();
            return tasks.Select(t => new TaskDTO
            {
                Date = t.Date,
                Description = t.Description,
                Executor = t.Executor,
                TimeSpent = t.TimeSpent
            }).ToList();
        }

        public async Task<TaskDTO> GetTaskById(int id)
        {
            var t=await taskRepository.GetTaskById(id);
            if (t is null)
                throw new NullReferenceException("Task was null");
            return new TaskDTO() { id = t.Id, Date = t.Date, Description = t.Description, Executor = t.Executor, TimeSpent = t.TimeSpent };
        }
    }
}
