using CSharpFunctionalExtensions;
using Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Responses
{
    public class Envelope
    {
        public bool Success { get; init; }

        public object? Data { get; init; }

        public List<ApiError> Errors { get; init; } = [];

        public static Envelope Ok(object? data = null) => new() { Success = true, Data = data };

        public static Envelope Fail(List<ApiError> apiErrors) => new() { Success = false, Errors = apiErrors };

        public static implicit operator ActionResult(Envelope result)
        {
            return new ObjectResult(result)
            {
                StatusCode = StatusCodes.Status200OK,
            };
        }
    }

    public record ApiError(string Code, string Message);
}
