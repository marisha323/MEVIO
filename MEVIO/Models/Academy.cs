namespace MEVIO.Models
{
    public class Academy
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int DirectorId { get; set; }//UserId
        public string AcademyName { get; set; }
        public int RequisitesId { get; set; }
    }
}
