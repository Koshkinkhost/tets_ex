using Project_Users_Managers.Validators;
using System.ComponentModel.DataAnnotations;

namespace Project_Users_Managers.DTO
{
    public class TaskDTO
    {
        public int id { get; set; }
        [Required]
        public string Description { get; set; } = null!;
        [Required,TimeMoreThanZero(ErrorMessage ="Затраченное время должно быть больше 0")]
        public TimeOnly TimeSpent { get; set; }
        [Required]
        public string? Executor { get; set; }
        [Required,OnlyTOday(ErrorMessage ="Дата должна быть сегодняшней")]
        public DateOnly Date { get; set; }
    }
}
