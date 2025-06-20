using System.ComponentModel.DataAnnotations;

namespace Project_Users_Managers.Validators
{
    public class TimeMoreThanZero:ValidationAttribute
    {
        public TimeMoreThanZero()
        {
            ErrorMessage = "Время должно быть больше 0";
        }
        public override bool IsValid(object? value)
        {
            if (value is TimeOnly date)
            {
                return date.Minute+date.Hour > 0;
            }

            return false;
        }

    }
}
