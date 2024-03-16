﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MovieInfo.api.Controllers.ActionFilters;

public class ValidationFilterAttribute : IActionFilter
{
	public void OnActionExecuting(ActionExecutingContext context)
	{
		if (!context.ModelState.IsValid)
			context.Result = new UnprocessableEntityObjectResult(context.ModelState);
	}
	
	public void OnActionExecuted(ActionExecutedContext context){}
}

