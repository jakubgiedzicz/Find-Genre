using Find_Genre.Server.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Find_Genre.Server.Filters
{
    public class Genre_ValidateGenreIdFilterAttribute : ActionFilterAttribute
    {
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var genreId = context.ActionArguments["id"] as int?;
            if (genreId <= 0)
            {
                context.ModelState.AddModelError("Id", "Genre Id is invalid");
                context.Result = new BadRequestObjectResult(context.ModelState);
            } else
            {
                await next();
                if (context.Result == null)
                {
                    context.ModelState.AddModelError("Id", "Genre does not exist");
                    context.Result = new NotFoundObjectResult(context.ModelState);
                }
            }
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            base.OnResultExecuted(context);
            if (context.Result == null)
            {
                context.ModelState.AddModelError("Id", "Genre does not exist");
            }
        }
    }
}
