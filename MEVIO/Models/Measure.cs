using Telegram.Bot.Types;

namespace MEVIO.Models
{
    public class Measure
    {
        public int Id { get; set; }
        public string MeasureName { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public int CreatorId { get; set; }
        public int FreePlaces { get; set; }
        public ICollection<User>? Users { get; set; }
        //public ICollection<Client>? Clients { get; set; }
        public int PlaceForMeasure { get; set; }
        public ICollection<MeasurePhotos> MeasurePhotos { get; set; }
        public ICollection<MeasureVideos>? MeasureVideos { get; set; }
    }
}
