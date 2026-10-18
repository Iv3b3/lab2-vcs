using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class PhoneValidator : IValidator
    {
        public bool Validate(UserData data, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (string.IsNullOrWhiteSpace(data.Phone) || data.Phone.Length < 10)
            {
                errorMessage = "Ошибка: Некорректный номер телефона.";
                return false;
            }
            return true;
        }
    }
}
