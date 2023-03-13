using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MEVIO.Models
{
    public class MeasureUsers
    {
        public int Id { get; set; }
        public int? MeasureId { get; set; }
        public virtual Measure Measure { get; set; }
        public int? UserId { get; set; }
       public virtual User User { get; set; }

        public bool IsCreator { get;set; }
        public int? UserMeasureAcceptStatusId { get; set; }
        public virtual UserMeasureAcceptStatus UserMeasureAcceptStatus{ get; set; }
        public MeasureUsers()
        {
           
        }
    }
}
