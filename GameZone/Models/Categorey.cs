namespace GameZone.Models
{
    public class Categorey:Base
    {
        public ICollection<Game> Games{ get; set; } = new List<Game>();

    }
}
