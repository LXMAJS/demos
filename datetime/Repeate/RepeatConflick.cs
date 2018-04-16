using System;

namespace datetime
{
    public class RepeatConflick
    {

        public static bool IfHasIntersection(RepeatModel model_1, RepeatModel model_2)
        {
            if(model_1.EndDate null && model_2.EndDate == null)
            {
                // both are no ending
                return false;
            }
            else if(model_1.EndDate != null && model_2.EndDate == null)
            {
                return model_1.EndDate >= model_2.StartDate;
            }
            else if(model_1.EndDate == null && model_2.EndDate != null)
            {
                return model_2.EndDate >= model_1.StartDate;
            }
            else
            {
                // both have ending
                return model_1.StartDate <= model_2.EndDate && model_1.EndDate >= model_2.StartDate;
            }
        }


        public static bool WillConflick(RepeatModel model_1, RepeatModel model_2)
        {
            // first calculate two time span, if there is no intersection ,then no conflick
            if()

        }
    }
}