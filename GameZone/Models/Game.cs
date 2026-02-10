using System.ComponentModel.DataAnnotations;

namespace GameZone.Models
{
    public class Game:Base
    {
        [MaxLength(2500)]
        public string Description { get; set; }=string.Empty;

        [MaxLength(500)]

        public string Cover { get; set; }=string.Empty;

        public int  CategoreyId { get; set; } 
        public Categorey categorey { get; set; } = default!;
        public ICollection<GameDevice> Device { get; set; } = new List<GameDevice>();
        
    }
}
