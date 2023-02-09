namespace MEVIO.Models
{
    public class MeasureBusyTable
    {
        public int Id { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public int PlaceForMeasureId { get; set; }
        public virtual PlaceForMeasure PlaceForMeasure { get; set; }


    }
}
