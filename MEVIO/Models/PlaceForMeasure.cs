﻿namespace MEVIO.Models
{
    public class PlaceForMeasure
    {
        public int Id { get; set; }
        public string PlaceForMeasureName { get; set; }
        public bool IsFree { get; set; }
        public ICollection<MeasureBusyTable> MeasureBusyTables { get; set; }
    }
}