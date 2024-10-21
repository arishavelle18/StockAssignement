using System.ComponentModel.DataAnnotations;

namespace StockAssignment.ServiceContracts.Helpers
{
    public class DateTimeValidation : ValidationAttribute
    {
        private readonly DateTime _minDate;
        private readonly DateTime _maxDate;

        public DateTimeValidation(string minDate)
        {
            _minDate = DateTime.Parse(minDate);
            _maxDate = DateTime.Now;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime dateValue)
            {
                if (dateValue > _maxDate || dateValue < _minDate)
                {
                    return new ValidationResult($"{dateValue.ToShortDateString()} {dateValue.ToShortTimeString()} Datetime must be between {_minDate.ToShortDateString()} and {_maxDate.ToShortDateString()} {_maxDate.ToShortTimeString()}");
                }
            }
            return ValidationResult.Success;
        }
    }
}
