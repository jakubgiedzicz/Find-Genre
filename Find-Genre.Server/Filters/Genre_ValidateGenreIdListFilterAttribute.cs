using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Find_Genre.Server.Filters
{
    public class Genre_ValidateGenreIdListFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var genreIds = context.ActionArguments["tag"] as List<int>;
            foreach (int indexer in genreIds!)
            {
                if (indexer <= 0)
                {
                    context.ModelState.AddModelError("Id", "Genre Id is invalid");
                    var details = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest
                    };
                    context.Result = new BadRequestObjectResult(details);
                }
            }
        }
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var details = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status404NotFound
                };
                context.Result = new NotFoundObjectResult(details);
            }
        }
    }
}
