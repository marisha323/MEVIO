using Microsoft.EntityFrameworkCore.Storage;

namespace MEVIO.Models
{
    public class Measure
    {
        public int Id { get; set; }
        public string MeasureName { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public int UserId { get; set; }//CreaterId
        public virtual User User { get; set; }

        public int FreePlaces { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Client>? Clients { get; set; }

        public int PlaceForMeasureId { get; set; }
        public virtual PlaceForMeasure PlaceForMeasure { get; set; }
        public ICollection<MeasurePhotos>? MeasurePhotos { get; set; }
        public ICollection<MeasureVideos>? MeasureVideos { get; set; }

        public Measure()
        {
            Users = new List<User>();
            Clients = new List<Client>();
            MeasurePhotos=new List<MeasurePhotos>();
            MeasureVideos=new List<MeasureVideos>();

        }

    }
}
