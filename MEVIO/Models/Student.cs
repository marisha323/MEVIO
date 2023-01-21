namespace MEVIO.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string StudyEmail { get; set; }
        public string StudentCode { get; set; }
        public string? PassportNumber { get; set; }
        public string? DateOfIssuePassport { get; set; }
        public string? TIN { get; set; }
        public bool IsDiscount { get; set; }
        public string? Discount_Description { get; set; }
    }
}
