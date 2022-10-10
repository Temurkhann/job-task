using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTask.Service.Exceptions
{
    public class JobTaskException : Exception
    {
        public int Code { get; set; }

        public JobTaskException(int code, string message) 
            : base(message)
        {
            this.Code = code;  
        }
    }
}
