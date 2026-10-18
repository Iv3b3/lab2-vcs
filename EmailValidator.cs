using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class EmailValidator : IValidator
    {
        public bool Validate(UserData data, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (string.IsNullOrWhiteSpace(data.Email) || !data.Email.Contains("@"))
            {
                errorMessage = "Ошибка: Некорректный Email (должен содержать @).";
                return false;
            }
            return true;
        }
    }
}
