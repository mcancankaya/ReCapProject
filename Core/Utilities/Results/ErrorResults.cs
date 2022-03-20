using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorResults:Result
    {
        public ErrorResults(string message):base(false,message)
        {

        }
        public ErrorResults():base(false)
        {

        }
    }
}
