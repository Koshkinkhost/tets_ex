using System.Collections.Generic;
namespace Project_Users_Managers.DTO
{
    public class AnswerTaskDTO
    {
        public bool Success { get; set; }
        public string? Data { get; set; }
        public List<string>? Errors { get; set; }
    }
}
