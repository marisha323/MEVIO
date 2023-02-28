namespace MEVIO.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string MyStatLogin { get; set; }
        public string Login365 { get; set; }
        public string StudentCode { get; set; }
        public string PersonalDocumentNumber { get; set; }
        public DateTime DateOfIssuePassport { get; set; }
        public string TIN { get; set; }
        public bool IsDicount { get; set; }
        public string Discount_Description { get; set; }
        public double? DiscountSum { get; set; }
        public DateTime Birthdate { get; set; }
        //public int? ContractId { get; set; }
        //public virtual Contract? Contract { get; set; }
    }
}
