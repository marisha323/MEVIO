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
        public ICollection<Client>? Clients { get; set; }
        public int PlaceForMeasureId { get; set; }
        public ICollection<Photo>? Photos { get; set; }
        public ICollection<MeasureVideo>? Videos { get; set; }
    }
}
