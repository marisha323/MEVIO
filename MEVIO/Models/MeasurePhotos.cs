namespace MEVIO.Models
{
    public class MeasurePhotos //Not Sure which one you wanted to make
    {
        public int Id { get; set; }

        public int MeasureId { get; set; }
        public virtual Measure Measure { get; set; }

        public string PhotoPath { get; set; }
    }
}
