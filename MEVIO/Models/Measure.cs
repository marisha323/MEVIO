using Microsoft.EntityFrameworkCore.Storage;

namespace MEVIO.Models
{
    public class Measure//Мероприятия
    {
        public int Id { get; set; }
        public string MeasureName { get; set; }
        public DateTime Begin { get; set; }
        public DateTime End { get; set; }
        public int UserId { get; set; }//CreaterId
        public virtual User User { get; set; }

        public int FreePlaces { get; set; }
        public ICollection<MeasureUsers> MeasureUsers { get; set; }
        public ICollection<MeasuresClients> MeasuresClients { get; set; }

        public int? MeasureChatId { get; set; }
        public virtual MeasureChat MeasureChat { get; set; }
        public int? PlaceForMeasureId { get; set; }
        public virtual PlaceForMeasure PlaceForMeasure { get; set; }
        public ICollection<MeasurePhotos> MeasurePhotos { get; set; }
        public ICollection<MeasureVideos> MeasureVideos { get; set; }
        public int MeasurePowerBiId { get; set; }
        public virtual MeasurePowerBi MeasurePowerBi { get; set; }
        public int? UserCalendarId { get; set; }
        public virtual UserCalendar UserCalendar { get; set; }
        public ICollection<UserMeasureAcceptStatus> UserMeasureAcceptStatuses { get; set; }
        public Measure()
        {
            MeasureUsers = new List<MeasureUsers>();
            MeasuresClients = new List<MeasuresClients>();
            MeasurePhotos=new List<MeasurePhotos>();
            MeasureVideos=new List<MeasureVideos>();
            UserMeasureAcceptStatuses = new List<UserMeasureAcceptStatus>();
        }

    }
}
