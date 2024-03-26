using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace WebApi.Middleware
{
	public class CustomExceptionHandlerMiddleware(RequestDelegate next)
	{
		private readonly RequestDelegate _next = next;
		
		public async Task Invoke(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception exception)
			{
				await HandleExceptionAsync(context, exception);
			}
		}

		private Task HandleExceptionAsync(HttpContext context, Exception exception)
		{
			var code = HttpStatusCode.InternalServerError;
			var result = string.Empty;

			switch(exception)
			{
				case ValidationException validationException:
					code = HttpStatusCode.BadRequest;
					result = JsonSerializer.Serialize(validationException.Errors);
					break;
			}

			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)code;

			if(result == String.Empty)
			{
				result = JsonSerializer.Serialize(new { error = exception.Message });
			}

			return context.Response.WriteAsync(result);
		}
	}
}
