﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PrisonAdministrationSystem.Models
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

               if (result.Contains("month") || result.Contains("year") || result.Contains("day") || result.Contains("live") || result.Contains("life") || result.Contains("death"))
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