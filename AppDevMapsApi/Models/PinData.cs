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
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "sampleData", "pindata.js");
            var jsonData = File.ReadAllText(filePath);
            jsonData = jsonData.Substring(jsonData.IndexOf('[')); // Assuming the array starts immediately after the '=' sign.
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
            _pinData = JsonSerializer.Deserialize<List<PinData>>(jsonData);  
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
        }

#pragma warning disable CS8603 // Possible null reference return.
        return _pinData;
#pragma warning restore CS8603 // Possible null reference return.
    }
}