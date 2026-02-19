using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;

namespace GameZone.Attribute
{
    public class AllowedExtentionsAttribute : ValidationAttribute

    {
        private readonly string _AllowedExtentions;

        public AllowedExtentionsAttribute(string extentions)
        {
            _AllowedExtentions=extentions;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file=value as IFormFile;

            if (file != null)
            {
                var exten=Path.GetExtension(file.FileName);
                var isallow= _AllowedExtentions.Split(',').Contains(exten, StringComparer.OrdinalIgnoreCase);
                if (!isallow)
                {
                    return new ValidationResult("not allowed extention , the allowed is .png,.jpg,.jpng");
                }
            }

            return ValidationResult.Success;
        }
    }
}
