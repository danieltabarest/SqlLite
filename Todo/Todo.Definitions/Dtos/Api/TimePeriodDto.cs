using System;
using NsuGo.Definition.Models;

namespace NsuGo.Definition.Dtos.Api
{
    public class TimePeriodDto : Base.JsonObject<TimePeriod>
    {
        public string StartDateTime
        {
            get;
            set;
        }

        public string EndDateTime
        {
            get;
            set;
        }

        public override TimePeriod ToDomainModel()
        {
            DateTime startDate;
            DateTime endDate;

            try
            {
                startDate = DateTime.Parse(StartDateTime);
                endDate = DateTime.Parse(EndDateTime);
            }
            catch (Exception)
            {
                startDate = DateTime.Now;
                endDate = DateTime.Now;
            }

            return new TimePeriod
            {
                Start = startDate,
                End = endDate
            };
        }
    }
}
