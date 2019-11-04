using DDDSample.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace DDDSample.WebApi.Extensions
{
    public abstract class DDDSampleControllerBase : ControllerBase
    {
        [NonAction]
        public OkObjectResult Success()
        {
            return base.Ok(Result.Success());
        }

        [NonAction]
        public OkObjectResult Success<TData>(TData data)
        {
            return base.Ok(Result<TData>.Success(data));
        }

        [NonAction]
        public OkObjectResult Fail(string message)
        {
            return base.Ok(Result.Fail(message));
        }

        [NonAction]
        public OkObjectResult Fail(int code, string message)
        {
            return base.Ok(Result.Fail(code, message));
        }
    }
}
