namespace MEVIO.Models
{
    public class PlaceForMeasures
    {
        public int Id { get; set; }
        public string PlaceForMeasureName{get; set; }
        public int Capacity { get; set; }
        public bool IsFree { get; set; }
        public ICollection<MeasureBusyTable> MeasureBusyTables { get; set; }
    }
}
