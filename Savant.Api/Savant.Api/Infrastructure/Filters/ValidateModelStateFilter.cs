﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Savant.Api.Infrastructure.Filters
{
    public class ValidateModelStateFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid)
                return;

            var validationErrors = context.ModelState
                .Keys
                .SelectMany(k => context.ModelState[k].Errors)
                .Select(e => e.ErrorMessage)
                .ToArray();

            context.Result = new BadRequestObjectResult(new
            {
                Messages = validationErrors
            });
        }
    }
}
