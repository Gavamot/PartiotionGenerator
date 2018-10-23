using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartiotionGenerator
{
    class Config
    {
        public Config(string[] args)
        {
            TablePrefix = args[0];
            Duration = (Duration)Enum.Parse(typeof(Duration), args[1]);
            From = DateTime.ParseExact(args[2], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            To = DateTime.ParseExact(args[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
            if (args.Length > 4)
                FileName = args[4];
        }

        public Duration Duration { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string TablePrefix { get; set; }
        public string FileName { get; set; } = "result.txt";
    }
}
