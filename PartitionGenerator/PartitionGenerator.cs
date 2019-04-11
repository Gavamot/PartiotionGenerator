using System;
using System.Collections.Generic;

namespace PartitionGenerator
{
    class PartitionGenerator
    {
        private string prefix;
        private DateTime from;
        private DateTime to;
        private IEnumerable<DateTime> generator;
        public PartitionGenerator(string prefix, Duration duration, DateTime from, DateTime to)
        {
            this.prefix = prefix;
            this.@from = from;
            this.to = to;

            if (duration == Duration.d)
                generator = EachDay();
            else if (duration == Duration.m)
                generator = EachMonth();
            else
                throw new ArgumentException();
        }

        private string GeneratePartitionName(DateTime dt)
        {
            return $"{prefix}_{dt.Day}_{dt.Month}_{dt.Year}";
        }

        public List<string> GeneratePartitions()
        {
            var res = new List<string>();
            foreach (DateTime dt in generator)
            {
                string str = $"PARTITION {GeneratePartitionName(dt)} VALUES LESS THAN(TO_DATE('{dt.Day}/{dt.Month}/{dt.Year}','DD/MM/YYYY'))";
                res.Add(str);
            }
            return res;
        }

        IEnumerable<DateTime> EachDay()
        {
            for (var day = from.Date; day.Date <= to.Date; day = day.AddDays(1))
                yield return day;
        }

        IEnumerable<DateTime> EachMonth()
        {
            for (var mounth = from.Date; mounth.Date <= to.Date; mounth = mounth.AddMonths(1))
                yield return mounth;
        }
    }
}
