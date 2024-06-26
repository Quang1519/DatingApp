using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
namespace API.Helpers
{
    public class LogUserActivity : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();

            if (!resultContext.HttpContext.User.Identity.IsAuthenticated) return;

            var userId = resultContext.HttpContext.User.GetUserId();

            // var repo = resultContext.HttpContext.RequestServices.GetRequiredService<IUserRespository>();
            var uow = resultContext.HttpContext.RequestServices.GetRequiredService<IUnitOfWork>();
            var user = await uow.UserRespository.GetUserByIdAsync(userId);
            user.LastActive = DateTime.UtcNow;
            // await repo.SaveAllAsync();
            await uow.Complete();
        }
    }
}