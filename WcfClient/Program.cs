using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfClient.SixthImpulse.SimpleWcf.WcfService;

namespace WcfClient {
    class Program {
        static void Main(string[] args) {

            ISimpleWcfService svc = new SimpleWcfServiceClient();
            TimeWithTimezone ttz = svc.GetServerDateWithTzInfo("");
            Console.WriteLine(string.Format("Server Local Time Is: {0} {1} GMT+{2}", ttz.TheTime, ttz.TimezoneName, ttz.TimezoneGmtOffset));

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();

            return;
        }
    }
}
