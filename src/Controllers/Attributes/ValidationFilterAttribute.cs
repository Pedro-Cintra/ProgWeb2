using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Shared.RequestFeatures;
using System.Dynamic;
using System.Text.Json.Serialization;

namespace Controllers.Attributes;

public class ValidationFilterAttribute : IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context) { }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var requiredParams = context.ActionArguments
                                    .Where(x => x.Value.ToString().Contains("Dto", StringComparison.InvariantCultureIgnoreCase)
                                             || x.Value.GetType().IsSubclassOf(typeof(PagingParameters)))
                                    .ToList();

        if (requiredParams.Any(x => x.Value == null))
        {
            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];

            context.Result = new BadRequestObjectResult($"Object is null. Controller: {controller}, action: {action}");
            return;
        }

        if (context.ModelState.IsValid)
            return;

        var rootModelType = requiredParams.FirstOrDefault().Value?.GetType(); //Get model type

        var expandoObj = new ExpandoObject();
        var expandoObjCollection = (ICollection<KeyValuePair<string, object>>)expandoObj; //Cannot convert IEnumrable to ExpandoObject

        var dictionary = context.ModelState.ToDictionary(k => k.Key, v => v.Value)
            .Where(v => v.Value.ValidationState == ModelValidationState.Invalid)
            .ToDictionary(
            k =>
            {
                if (rootModelType == null)
                    return k.Key;

                Type currentType = rootModelType;

                string[] propNavNames = k.Key.Split('.');
                for (int i = 0; i < propNavNames.Length; i++)
                {
                    string propName = propNavNames[i].Split('[').First();

                    var property = currentType.GetProperties().FirstOrDefault(p => p.Name == propName);
                    if (property == null)
                        continue;

                    //Try to get the attribute
                    var displayName = property.GetCustomAttributes(typeof(JsonPropertyNameAttribute), true).Cast<JsonPropertyNameAttribute>().SingleOrDefault()?.Name;
                    if (displayName != null)
                        propNavNames[i] = propNavNames[i].Replace(propName, displayName);

                    if (i == propNavNames.Length - 1)
                        continue;

                    Type innerType = property.PropertyType;
                    do
                    {
                        currentType = innerType;
                        innerType = innerType.GetElementType();
                    } while (innerType != null);
                }

                return string.Join(".", propNavNames);
            },
            v => v.Value.Errors.Select(e => e.ErrorMessage).ToList() as object); //Box String collection

        foreach (var keyValuePair in dictionary)
        {
            expandoObjCollection.Add(keyValuePair);
        }

        dynamic eoDynamic = expandoObj;
        context.Result = new UnprocessableEntityObjectResult(eoDynamic);
    }
}
