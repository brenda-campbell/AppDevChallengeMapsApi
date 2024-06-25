using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class GetMapController : ControllerBase
{
    [HttpGet(Name = "GetMap")]
    public IEnumerable<PinData> GetMap()
    {
        // Create sample data similar to the one in the pindata.js file to return as Json payload
        var pinDataList = DataRepository.GetPinData();
        return pinDataList;
    }
}