namespace MEVIO.Models
{
    public class Contract
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public virtual Client Client { get; set; }

        public int? StudentId { get; set; }
        public virtual Student Student { get; set; }

        public DateTime DateStamp { get; set; }

        public int? EducationFormId { get; set; }
        public virtual EducationForm EducationForm { get; set; }

        public int AcademyId { get; set; }
        public virtual Academy Academy { get; set; }

        public int? SeasonOfBeginningId { get; set; }
        public virtual SeasonOfBeginning SeasonOfBeginning { get; set; }
    }
}
