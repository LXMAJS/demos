using System;
using System.Collections.Generic;
using System.Text;

namespace calendar.Calendar
{
    public class RepeatModel
    {
        /// <summary>
        /// repeat type
        /// </summary>
        public enum ERepeatType
        {
            NoRepeat = -1,
            Day = 1,
            Week = 2,
            Weekday = 3,
            Month = 4
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ERepeatType RepeatType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int RepeatFrequence { get; set; }
    }
}
