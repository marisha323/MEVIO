namespace MEVIO.Models
{
    public class PlaceForMeasure//Місце для проведення заходів
    {
        public int Id { get; set; }
        public string PlaceForMeasureName { get; set; }
        public bool IsFree { get; set; }// зайнята чи ні
        public int Capacity { get; set; }//вмістимість кімнати(кількість людей)
        public ICollection<MeasureBusyTable> MeasureBusyTables { get; set; }
        public ICollection<Measure> Measures { get; set; }

        public PlaceForMeasure() { 
        
            MeasureBusyTables= new List<MeasureBusyTable>();
            Measures= new List<Measure>();
        }
    }
}
