using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class PasswordValidator : IValidator
    {
        public bool Validate(UserData data, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (string.IsNullOrWhiteSpace(data.Password) || data.Password.Length < 8)
            {
                errorMessage = "Ошибка: Пароль слишком короткий (минимум 8 символов).";
                return false;
            }
            return true;
        }
    }
}
