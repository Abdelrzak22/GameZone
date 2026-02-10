using System.ComponentModel.DataAnnotations;

namespace GameZone.Models
{
    public class Device:Base
    {

        [MaxLength(100)]
        public string Icon { get; set; } = string.Empty;

        public ICollection<GameDevice> Devices { get; set; } = new List<GameDevice>();

    }
}
