using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Users_Managers.DTO;
using Project_Users_Managers.Exceptions;
using Project_Users_Managers.Services;

namespace Project_Users_Managers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private IServiceTask service;
        public TaskController(IServiceTask taskService)
        {
            service = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            var tasks=await service.GetAllTasksAsync();
            return Json(tasks);
        }
        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] TaskDTO task)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(e => e.Value.Errors.Count > 0)
                    .Select(e => new
                    {
                        Field = e.Key,
                        Message = e.Value.Errors.First().ErrorMessage
                    });

                return BadRequest(errors); 
            }
            try
            {
                await service.AddTaskAsync(task);

            }
            catch(InvalidTaskException ex)
            {
                return BadRequest(ex.Message);
            }


            return CreatedAtAction(nameof(AddTask), new { Executor = task.Executor, DateCreated = task.Date });

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            try
            {
                
                    await service.DeleteTaskAsyncById(id);
                    return CreatedAtAction(nameof(DeleteTask), new { Id = id });
                
            }
            catch (NullReferenceException ex)
            {
                return BadRequest(ex.Message);

            }
            


        }
    }
}
