using CSharpFunctionalExtensions;
using Domain.Shared;
using Microsoft.AspNetCore.Mvc;
using Presentation.Responses;

namespace Presentation.Extensions
{
    public static class ResponseExtensions
    {
        public static ActionResult ToResponse(this Errors errors)
        {
            if (!errors.Any())
            {
                return new ObjectResult(Envelope.Fail([]))
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                };
            }

            var distinctErrorTypes = errors.Select(e => e.ErrorType).Distinct().ToList();

            var statusCode = distinctErrorTypes.Count() > 1 ?
                StatusCodes.Status500InternalServerError :
                GetStatusCodeForErrorType(distinctErrorTypes.First());

            var apiErrors = errors.Select(e => new ApiError(e.Code, e.Message)).ToList();

            return new ObjectResult(Envelope.Fail(apiErrors))
            {
                StatusCode = statusCode,
            };
        }

        private static int GetStatusCodeForErrorType(ErrorType type)
            => type switch
            {
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Failure => StatusCodes.Status500InternalServerError,
                ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
                _ => StatusCodes.Status500InternalServerError
            };
    }
}
