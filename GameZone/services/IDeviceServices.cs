using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.services
{
    public interface IDeviceServices
    {
        IEnumerable<SelectListItem> GetDevices();
    }
}
