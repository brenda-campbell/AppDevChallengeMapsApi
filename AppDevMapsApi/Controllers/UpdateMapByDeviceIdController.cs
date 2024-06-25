using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;


[ApiController]
[Route("[controller]")]
public class UpdateMapByDeviceIdController : ControllerBase
{

    // PUT: UpdateMapByDeviceId/5
    [HttpPut("{deviceId}")]
    public IActionResult Update(int deviceId)
    {
        var pinData = DataRepository.GetPinData().FirstOrDefault(p => p.DeviceId == deviceId);
        if (pinData == null)
        {
            return NotFound();
        }

        // Update the Name, Longitude, Latitude, Image, and Text of the pin data from location information obtained from clicking on a map
        pinData.Name = "Updated Name";
        pinData.Latitude = 37.7749;
        pinData.Longitude = -122.4194;
        pinData.Image = "Updated Image";
        pinData.Text = "Updated Text";

        // Update the status of the pin data
        pinData.Status = "Updated";

        return NoContent();
    }
}