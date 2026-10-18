using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class AgeValidator : IValidator
    {
        public bool Validate(UserData data, out string errorMessage)
        {
            errorMessage = string.Empty;
            if (data.Age < 18)
            {
                errorMessage = "Ошибка: Возраст должен быть 18+.";
                return false;
            }
            return true;
        }
    }
}
