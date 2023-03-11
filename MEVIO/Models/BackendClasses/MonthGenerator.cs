namespace MEVIO.Models.BackendClasses
{
    public class MonthGenerator
    {
        public string Name { get; set; }
        public int DaysInMonth { get; set; }
        public string Season { get; set; }
        public static List<MonthGenerator> Fill()
        {
            List<MonthGenerator> months = new List<MonthGenerator>();

            months.Add(new MonthGenerator { Name = "Січень", DaysInMonth = 31, Season = "winter" });
            months.Add(new MonthGenerator { Name = "Лютий", DaysInMonth = 28, Season = "winter" });
            months.Add(new MonthGenerator { Name = "Березень", DaysInMonth = 31, Season = "spring" });
            months.Add(new MonthGenerator { Name = "Квітень", DaysInMonth = 30, Season = "spring" });
            months.Add(new MonthGenerator { Name = "Травень", DaysInMonth = 31, Season = "spring" });
            months.Add(new MonthGenerator { Name = "Червень", DaysInMonth = 30, Season = "summer" });
            months.Add(new MonthGenerator { Name = "Липень", DaysInMonth = 31, Season = "summer" });
            months.Add(new MonthGenerator { Name = "Серпень", DaysInMonth = 31, Season = "summer" });
            months.Add(new MonthGenerator { Name = "Вересень", DaysInMonth = 30, Season = "autumn" });
            months.Add(new MonthGenerator { Name = "Жовтень", DaysInMonth = 31, Season = "autumn" });
            months.Add(new MonthGenerator { Name = "Листопад", DaysInMonth = 30, Season = "autumn" });
            months.Add(new MonthGenerator { Name = "Грудень", DaysInMonth = 31, Season = "winter" });

            return months;
        }
    }
    
}
