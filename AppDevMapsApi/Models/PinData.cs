using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
public class PinData
{
    [JsonPropertyName("deviceid")]
    public int DeviceId { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("image")]
    public string? Image { get; set; }

    [JsonPropertyName("text")]
    public string? Text { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}

public static class DataRepository
{

    private static List<PinData> _pinData;
    public static List<PinData> GetPinData()
    {
        if (_pinData == null)
        {
            try
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "sampleData", "pindata.js");
                Console.WriteLine(filePath);
                // Check if the file exists
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"The file {filePath} was not found.");
                }

                var jsonData = File.ReadAllText(filePath);
                // output the json data to the console
                Console.WriteLine(jsonData);
                jsonData = jsonData.Substring(jsonData.IndexOf('[')); // Assuming the array starts immediately after the '=' sign.
                
                // Check if jsonData is not null or empty
                if (string.IsNullOrWhiteSpace(jsonData))
                {
                    throw new InvalidOperationException("The JSON data is empty or not properly formatted.");
                }

                _pinData = JsonSerializer.Deserialize<List<PinData>>(jsonData);
                if (_pinData == null)
                {
                    // Handle the case where deserialization returns null
                    throw new InvalidOperationException("Failed to deserialize the JSON data into a List<PinData>.");
                }
            }
            catch (FileNotFoundException ex)
            {
                // Handle file not found exception
                Console.WriteLine($"Error: {ex.Message}");
                // Consider logging the error or rethrowing the exception based on your error handling policy
            }
            catch (JsonException ex)
            {
                // Handle JSON parsing errors
                Console.WriteLine($"Error parsing JSON: {ex.Message}");
                // Consider logging the error or rethrowing the exception based on your error handling policy
            }
            catch (Exception ex)
            {
                // Handle other unforeseen errors
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Consider logging the error or rethrowing the exception based on your error handling policy
            }
        }

        return _pinData ?? new List<PinData>(); // Return an empty list if _pinData is null to avoid null reference errors
    }
}