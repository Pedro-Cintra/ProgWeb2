using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace WebAPI.Extensions;

public static class JsonConverterConfiguration
{
    public static JsonOptions ConfigureJson(this JsonOptions options)
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

        return options;
    }
}
