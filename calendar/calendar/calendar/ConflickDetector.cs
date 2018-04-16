using System;
using System.Collections.Generic;
using System.Text;

namespace calendar.Calendar
{
    public class ConflickDetector
    {
        /// <summary>
        /// date has intersetion
        /// </summary>
        /// <param name="model_1"></param>
        /// <param name="model_2"></param>
        /// <returns></returns>
        private static bool IfHasDateSpanIntersection(RepeatModel model_1, RepeatModel model_2)
        {
            if (model_1.EndDate == null && model_2.EndDate == null)
            {
                // both are no ending, then will conflick in some day
                return true;
            }
            else if (model_1.EndDate != null && model_2.EndDate == null)
            {
                return model_1.EndDate >= model_2.StartDate;
            }
            else if (model_1.EndDate == null && model_2.EndDate != null)
            {
                return model_2.EndDate >= model_1.StartDate;
            }
            else
            {
                // both have ending
                return model_1.StartDate <= model_2.EndDate && model_1.EndDate >= model_2.StartDate;
            }
        }

        /// <summary>
        /// timepan has intersetion
        /// </summary>
        /// <param name="model_1"></param>
        /// <param name="model_2"></param>
        /// <returns></returns>
        private static bool IfHasTimeSpanIntersection(RepeatModel model_1, RepeatModel model_2)
        {
            // both have ending
            DateTime startTime_1 = model_1.StartTime;
            DateTime endTime_1 = model_1.EndTime;
            DateTime startTime_2 = startTime_1.Date + model_2.StartTime.TimeOfDay;
            DateTime endTime_2 = startTime_1.Date + model_2.EndTime.TimeOfDay;

            return startTime_1 <= endTime_2 && endTime_1 >= startTime_2;
        }

        /// <summary>
        /// judge two repeat model will conflick in futhure
        /// </summary>
        /// <param name="model_1"></param>
        /// <param name="model_2"></param>
        /// <returns></returns>
        public static bool WillConflick(RepeatModel model_1, RepeatModel model_2)
        {
            bool willConflick = false;
            // first calculate two time span, if there is no intersection ,then no conflick
            if (IfHasTimeSpanIntersection(model_1, model_2) && IfHasDateSpanIntersection(model_1, model_2))
            {
                if (model_1.EndDate == null || model_2.EndDate == null) return true;

                DateTime beginSpan = model_1.StartTime;
            }

            return willConflick;
        }
    }
}
