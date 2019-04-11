using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PartitionGenerator
{
    class Program
    {
        static Config config;
        static void Main(string[] args)
        {
            try
            {
                config = new Config(args);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong in arguments. Arguments must have format ([prefix] [m, d] [16.01.2010] [07.12.2013])");
                return;
            }

            var partGen = new PartitionGenerator(config.TablePrefix, config.Duration, config.From, config.To);
            var partitions = partGen.GeneratePartitions();
            File.WriteAllLines(config.FileName, partitions, Encoding.UTF8);
        }
    }
}
