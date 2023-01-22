namespace MEVIO.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int StudentId { get; set; }
        public DateTime DateStamp { get; set; }
        public int EducationFormId { get; set; }
        public int AcademyId { get; set; }
        public int SeasonId { get; set; }
    }
}
