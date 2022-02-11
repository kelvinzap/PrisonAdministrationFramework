using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PrisonAdministrationSystem.Core.Validations
{
    public class CorrectSentence :ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var result = Convert.ToString(value);
           result = result.ToLower();

           if (result.Any(char.IsDigit) || result.Contains("live") || result.Contains("life") || result.Contains("death"))
           {
               result = new string(Convert.ToString(value).Where(c => char.IsLetter(c)).ToArray());
               var query = (result.Contains("month") || result.Contains("year") || result.Contains("day") ||
                            result.Contains("live") || result.Contains("life") || result.Contains("death"))
                   ? true
                   : false;

               if (query)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }
           else
           {
               return false;
           }

        }
    }
}