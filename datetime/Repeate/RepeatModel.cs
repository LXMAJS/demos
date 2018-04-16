using System;

namespace datetime
{
    public class RepeatModel
    {
        ///<Summary>
        /// Repeate Type of all
        ///</Summary>
        public enum ERepeatType
        {
            NoRepeat = -1,
            Day = 1,
            Week = 2,
            Weekday = 3,
            Month = 4
        }
        
        public DateTime StartTime{get;set;}

        public DateTime EndTime {get;set;}

        public DateTime StartDate {get;set;}

        public DateTime? EndDate{get;set;}

        public ERepeatType RepeatType{get;set;}

        public int RepeatFrequence{get;set;}
        
    }
}
