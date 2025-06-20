using System.ComponentModel.DataAnnotations;

namespace Project_Users_Managers.Validators
{
    public class OnlyTOdayAttribute : ValidationAttribute
    {
        public OnlyTOdayAttribute()
        {
            ErrorMessage = "Дата должна быть сегодняшней";
        }

        public override bool IsValid(object? value)
        {
            if (value is DateOnly date)
            {
                return date == DateOnly.FromDateTime(DateTime.UtcNow);
            }

            return false;
        }

       
    }
}
