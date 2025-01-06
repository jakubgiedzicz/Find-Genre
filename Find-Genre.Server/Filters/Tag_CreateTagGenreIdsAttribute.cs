using Find_Genre.Server.DTO.Tag;
using System.ComponentModel.DataAnnotations;

namespace Find_Genre.Server.Filters
{
    public class Tag_CreateTagGenreIdsAttribute : ValidationAttribute
    {
        public string ErrorMessageT = "GenreId cant be lower than 0";
        protected override ValidationResult? IsValid(
        object? value, ValidationContext validationContext)
        {
            var dto = (CreateTagDTO)validationContext.ObjectInstance;
            if (dto.GenreIds!.Any(i => i <= 0))
            {
                return new ValidationResult(ErrorMessageT);
            }
            return ValidationResult.Success;
        }
    }
}
