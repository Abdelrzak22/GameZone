using GameZone.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameZone.services
{
    public class DevicesServices : IDeviceServices
    {

        private readonly ApplicationDbcontext _context;

        public DevicesServices(ApplicationDbcontext contrxt)
        {
            _context = contrxt;
        }
        public IEnumerable<SelectListItem> GetDevices()
        {
            return _context.Devices.Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name }).OrderBy(x => x.Text).ToList();
        }
    }
}
