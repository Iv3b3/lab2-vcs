using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    public class ValidationService
    {
        private readonly IEnumerable<IValidator> _validators;

        public ValidationService(IEnumerable<IValidator> validators)
        {
            _validators = validators;
        }

        public bool ValidateAll(UserData data, out List<string> errors)
        {
            errors = new List<string>();
            bool isValid = true;

            foreach (var validator in _validators)
            {
                if (!validator.Validate(data, out string error))
                {
                    isValid = false;
                    errors.Add(error);
                }
            }
            return isValid;
        }
    }
}
