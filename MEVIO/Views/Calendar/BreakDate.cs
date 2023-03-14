using MEVIO.Models;

namespace MEVIO.Views.Calendar
{
    public class BreakDate
    {
        public string year { get; set; }
        public string month { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string EventName { get; set; }

        public BreakDate(Event eventt)
        {
            // Convert the Begin property to a string and split it into year, month, date, and time
            EventName = eventt.EventName;
            string[] beginParts = eventt.Begin.ToString().Split(' ');
            string[] dateParts = beginParts[0].Split('/');

            year = dateParts[2];
            month = dateParts[0];
            date = dateParts[1];
            time = beginParts[1];
        }
    }
}
