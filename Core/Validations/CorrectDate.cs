using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace PrisonAdministrationSystem.Core.Validations
{
    public class CorrectDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "d MMM yyyy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out dateTime);
            return (isValid && dateTime <= DateTime.Now);

        }
    }
}