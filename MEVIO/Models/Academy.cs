namespace MEVIO.Models
{
    public class Academy
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int? UserId { get; set; }//DirectorId
        public virtual User User { get; set; }

        public string AcademyName { get; set; }
        public int? RequisitesId { get; set; }
        public virtual Requisites Requisites { get; set; }
    }
}
