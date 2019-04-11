using System;
using System.Globalization;
using PartitionGenerator;

namespace PartitionGenerator
{
    class Config
    {
        private const string DateFormat = "dd.MM.yyyy";
        public Config(string[] args)
        {
            TablePrefix = args[0];
            Duration = (Duration)Enum.Parse(typeof(Duration), args[1]);
            From = DateTime.ParseExact(args[2], DateFormat, CultureInfo.InvariantCulture);
            To = DateTime.ParseExact(args[3], DateFormat, CultureInfo.InvariantCulture);
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
