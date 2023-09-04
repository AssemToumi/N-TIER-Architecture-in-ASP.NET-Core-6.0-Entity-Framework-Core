using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Helper
{
    public class ValidateModelStateAttribute : ActionFilterAttribute
    {
        //
        // Summary:
        //     Called before the action method is invoked
        //
        // Parameters:
        //   context:
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            ControllerActionDescriptor? controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            if (controllerActionDescriptor != null)
            {
                ParameterInfo[] parameters = controllerActionDescriptor.MethodInfo.GetParameters();
                foreach (ParameterInfo parameterInfo in parameters)
                {
                    object? args = null;
                    if (context.ActionArguments.ContainsKey(parameterInfo.Name))
                    {
                        args = context.ActionArguments[parameterInfo.Name];
                    }

                    ValidateAttributes(parameterInfo, args, context.ModelState);
                }
            }

            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }

        private void ValidateAttributes(ParameterInfo parameter, object args, ModelStateDictionary modelState)
        {
            foreach (CustomAttributeData customAttribute2 in parameter.CustomAttributes)
            {
                Attribute customAttribute = parameter.GetCustomAttribute(customAttribute2.AttributeType);
                ValidationAttribute validationAttribute = customAttribute as ValidationAttribute;
                if (validationAttribute != null && !validationAttribute.IsValid(args))
                {
                    modelState.AddModelError(parameter.Name, validationAttribute.FormatErrorMessage(parameter.Name));
                }
            }
        }
    }
}