using System.Linq;

namespace lab1
{
    public class NameValidator : IValidator
    {
        public bool Validate(UserData data, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(data.Name))
            {
                errorMessage = "Ошибка: Имя не может быть пустым.";
                return false;
            }

            if (!data.Name.All(char.IsLetter))
            {
                errorMessage = "Ошибка: Имя должно содержать только буквы.";
                return false;
            }

            return true;
        }
    }
}