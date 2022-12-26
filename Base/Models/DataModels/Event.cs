using System.ComponentModel.DataAnnotations;

namespace Models.DataModels
{
    public class Event
    {
        public string Title { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public string StartDate { get; set; }

        [DataType(DataType.Time)]
        public string StartTime { get; set; }

        [DataType(DataType.Date)]
        public string EndDate { get; set; }

        [DataType(DataType.Time)]
        public string EndTime { get; set; }
        public bool IsFullDay { get; set; }
        public string Location { get; set; }
    }
}