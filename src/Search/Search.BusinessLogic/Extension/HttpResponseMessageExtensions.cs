using Newtonsoft.Json;

namespace Search.BusinessLogic.Extension;

public static class HttpResponseMessageExtensions
{
    public static async Task<T> DeserializeJsonContentAsync<T>(this HttpResponseMessage response)
    {
        if (response.IsSuccessStatusCode)
        {
            var jsonString = await response.Content.ReadAsStringAsync();
            try
            {
                var desarilizingResult = JsonConvert.DeserializeObject<T>(jsonString)!;
                return desarilizingResult;
            }
            catch (JsonReaderException ex)
            {
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
            }
            
        }

        throw new InvalidOperationException($"Failed to deserialize JSON. Status code: {response.StatusCode}");
    }
}

