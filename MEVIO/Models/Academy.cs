using Telegram.Bot.Types;

namespace MEVIO.Models
{
    public class Academy
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int UserRoleId { get; set; }
        public string AcademyName { get; set; }
        public int Requisites { get; set; }
    }
}
