using System;
using System.ComponentModel.DataAnnotations;

namespace PrisonAdministrationFramework.Core.Validations
{
    public class SideProfileRequired : ValidationAttribute
    {
        public string ConditionId { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherProperty = validationContext.ObjectType.GetProperty(ConditionId);

            if (otherProperty == null)
                return new ValidationResult(String.Format("Unknown property: {0}.", ConditionId));
            var otherPropertyValue = otherProperty.GetValue(validationContext.ObjectInstance, null);

            if (otherPropertyValue == null)
            {
                if (value == null)
                    return new ValidationResult("SideProfile Required");
                else
                    return null;
            }


            return null;


        }
    }
}