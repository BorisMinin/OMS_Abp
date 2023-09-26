using System;
using System.ComponentModel.DataAnnotations;

namespace OMS_Demo_Sample.CustomAttributes
{
    /// <summary>
    /// Кастомный атрибут, который проверяет, начинается ли свойство с определенной строки,
    /// не является ли свойство равное null
    /// не состоит ли свойство из пробельных символов
    /// https://learn.microsoft.com/en-us/dotnet/standard/attributes/writing-custom-attributes
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false)
        ]
    public class StartsWithAttribute : ValidationAttribute
    {
        private int _startsWith;

        public StartsWithAttribute(int startWith)
        {
            _startsWith = startWith;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyValue = value.ToString();

            if (propertyValue.StartsWith(_startsWith.ToString()) && string.IsNullOrWhiteSpace(_startsWith.ToString())) 
                return ValidationResult.Success; 
            else
                throw new NotImplementedException();
            //return new ValidationResult($"Свойство {validationContext.DisplayName} должно начинаться с {_startsWith}.");
        }
    }
}