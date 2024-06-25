using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("[controller]")]

public class GetMapByDeviceIdController : ControllerBase
{
    [HttpGet("{deviceId}")]
    public ActionResult<PinData> GetByDeviceId(int deviceId)
    {
        var pinData = DataRepository.GetPinData().FirstOrDefault(p => p.DeviceId == deviceId);
        if (pinData == null)
        {
            return NotFound();
        }
        return pinData;
    }
}