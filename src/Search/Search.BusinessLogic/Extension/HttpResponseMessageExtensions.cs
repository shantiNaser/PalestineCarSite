using System;
using Newtonsoft.Json;

namespace Search.BusinessLogic.Extension;

public static class HttpResponseMessageExtensions
{
    public static async Task<T> DeserializeJsonContentAsync<T>(this HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonString)!;
        }

        throw new InvalidOperationException($"Failed to deserialize JSON. Status code: {response.StatusCode}");
    }
}

