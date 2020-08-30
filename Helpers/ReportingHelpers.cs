using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightTest.Helpers
{
    public class ReportingHelpers
    {
        static ReportingHelpers()
        {
            Console.WriteLine("**********************************************");
            Console.WriteLine("Test Report");
            Console.WriteLine("**********************************************");
        }

        private ReportingHelpers() { }

        public static void CreateTest(string name, string description)
        {
            Console.WriteLine(name + "\t" + description);
        }

        public static void CreateChildTest(string name)
        {
            Console.WriteLine("\t" + name);
        }

        public static void CreateFeature(String name, String description)
        {
            Console.WriteLine(name + "\t" + description);
        }

        public static void CreateScenario(String name)
        {
            Console.WriteLine(name);
        }

        
    }
}
