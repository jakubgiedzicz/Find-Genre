using Find_Genre.Server.Models;
using System.ComponentModel.DataAnnotations;

namespace Find_Genre.Server.Filters
{
    public class Validate_CreateGenreTagIdsAttribute : ValidationAttribute
    {
        public string ErrorMessageT = "TagId cant be lower than 0";
        public string ErrorMessageP = "ParentId cant be lower than 0";
        protected override ValidationResult? IsValid(
        object? value, ValidationContext validationContext)
        {
            var dto = (CreateGenreDTO)validationContext.ObjectInstance;
            if (dto.TagsId!.Any(i => i<=0))
            {
                return new ValidationResult(ErrorMessageT);
            } else if (dto.ParentGenresId!.Any(i => i<=0))
            {
                return new ValidationResult(ErrorMessageP);
            }
            return ValidationResult.Success;
        }
    }
}
