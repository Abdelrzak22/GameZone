using System.ComponentModel.DataAnnotations;

namespace GameZone.Attribute
{
    public class MaxsizeAttribute:ValidationAttribute
    {
        private readonly int _maxlenthg;

        public MaxsizeAttribute(int  maxlength)
        {
            _maxlenthg = maxlength;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file != null)
            {
               if(file.Length>_maxlenthg)
                {
                    return new ValidationResult("the size should be small than this");
                }
            }

            return ValidationResult.Success;
        }
    }

}
