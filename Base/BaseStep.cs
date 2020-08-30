using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightTest.Base
{
    public abstract class BaseStep: Base
    {
        public virtual void NavigateSite(string URL)
        {
            DriverContext.Browser.GoToUrl(URL);
            Console.Write("Opened the browser !!!");
        }
    }
}
